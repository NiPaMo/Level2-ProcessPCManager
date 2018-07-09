using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Process_PC_Manager
{
    public partial class ConfigurationWindow : Window
    {
        Config config = new Config();
        List<TextBox> tbsHostName;
        List<TextBox> tbsNickName;

        public ConfigurationWindow()
        {
            InitializeComponent();

            LoadConfig();
        }

        private void LoadConfig()
        {
            ChildControls ccChildren = new ChildControls();
            tbsHostName = new List<TextBox>();
            tbsNickName = new List<TextBox>();

            int i;

            foreach (object o in ccChildren.GetChildren(Parent, 5))
            {
                if (o.GetType() == typeof(TextBox))
                {
                    switch (((TextBox)o).Uid)
                    {
                        case "HOSTNAME":
                            tbsHostName.Add((TextBox)o);
                            break;

                        case "NICKNAME":
                            tbsNickName.Add((TextBox)o);
                            break;

                        default:
                            break;
                    }
                }
            }

            List.Content = config.GetFileName();

            i = 0;
            foreach (var text in tbsHostName)
            {
                if (config.GetHostName(i) != null)
                    text.Text = config.GetHostName(i);
                else
                    text.Text = "";
                i++;
            }

            i = 0;
            foreach (var text in tbsNickName)
            {
                if (config.GetNickName(i) != null)
                    text.Text = config.GetNickName(i);
                else
                    text.Text = "";
                i++;
            }
        }

        private void ApplyConfig()
        {
            config.SetFileName(List.Content.ToString());

            int i = 0;
            foreach (var text in tbsHostName)
            {
                config.SetHostName(text.Text, i);
                i++;
            }

            i = 0;
            foreach (var text in tbsNickName)
            {
                config.SetNickName(text.Text, i);
                i++;
            }
        }

        private void ClearConfig()
        {
            List.Content = config.GetFileName();

            foreach (var text in tbsHostName)
            {
                text.Text = "";
            }

            foreach (var text in tbsNickName)
            {
                text.Text = "";
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            ApplyConfig();
            config.SetConfig();
            this.Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            config.GetConfig();
            LoadConfig();
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            ListNamePromptWindow listNamePrompt = new ListNamePromptWindow();
            listNamePrompt.ShowDialog();

            string listName = listNamePrompt.GetListName();

            if (listName != null)
            {
                config.SetFileName(listName);

                if (!(bool)listNamePrompt.GetCopy())
                    ClearConfig();
                else
                    List.Content = config.GetFileName();

                config.SetConfigList();
            }
        }
    }
}
