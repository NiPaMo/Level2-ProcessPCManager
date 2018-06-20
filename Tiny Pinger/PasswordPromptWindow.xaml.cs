using System.Windows;
using System.Windows.Input;

namespace Process_PC_Manager
{
    public partial class PasswordPromptWindow : Window
    {
        private static string username;
        private static string password;
        private static bool cancel;

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

        public bool GetCancel()
        {
            return cancel;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            username = Username.Text;
            password = Password.Text;
            cancel = false;

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel = true;

            this.Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                username = Username.Text;
                password = Password.Text;
                cancel = false;

                this.Close();
            }
        }
    }
}
