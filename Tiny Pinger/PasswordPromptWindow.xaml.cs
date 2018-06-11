using System.Windows;

namespace Process_PC_Manager
{
    public partial class PasswordPromptWindow : Window
    {
        private static string username;
        private static string password;

            public PasswordPromptWindow()
        {
            InitializeComponent();
        }


        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            username = Username.Text;
            password = Password.Text;

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
