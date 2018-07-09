using System.Windows;

namespace Process_PC_Manager
{
    public partial class ListNamePromptWindow : Window
    {
        private static string listName;
        private static bool? copy;

        public ListNamePromptWindow()
        {
            InitializeComponent();
        }

        public string GetListName()
        {
            return listName;
        }

        public bool? GetCopy()
        {
            return copy;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            listName = ListName.Text;
            copy = Copy.IsChecked;

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            listName = null;

            this.Close();
        }
    }
}
