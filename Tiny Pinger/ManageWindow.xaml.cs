using System;
using System.Windows;
using System.Management;

namespace Process_PC_Manager
{
    public partial class ManageWindow : Window
    {
        Config config = new Config();
        PasswordPromptWindow prompt = new PasswordPromptWindow();

        string hostName;

        public ManageWindow()
        {
            prompt.ShowDialog();

            if (prompt.GetCancel())
                this.Close();

            InitializeComponent();

            foreach (var name in config.GetHostName())
            {
                HostName.Items.Add(name);
            }

            HostName.SelectedIndex = 0;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            hostName = HostName.Text;

            ConnectionOptions options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Packet,
                EnablePrivileges = true,
                Username = hostName + "\\" + prompt.GetUsername(),
                Password = prompt.GetPassword()
            };

            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + hostName + ".maprocess.corp.aksteel.com\\root\\cimv2", options);
                scope.Connect();

                // Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Details.Text = "Computer Name\t:  " + m["CSName"] + "\n" +
                                   "Status       \t:  " + m["Status"] + "\n" +
                                   "OS Name      \t:  " + m["Caption"] + "\n" +
                                   "Service Pack \t:  " + m["CSDVersion"] + "\n" +
                                   "Version      \t:  " + m["Version"] + "\n" +
                                   "Build Number \t:  " + m["BuildNumber"] + "\n" +
                                   "Architecture \t:  " + m["OSArchitecture"] + "\n" +
                                   "Serial Number\t:  " + m["SerialNumber"];
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Display error to user
                MessageBox.Show("Error connecting to " + hostName + "\nCheck username and password", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
