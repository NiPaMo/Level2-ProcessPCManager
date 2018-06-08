using System;
using System.Windows;
using System.Management;

namespace Process_PC_Manager
{
    public partial class ManageWindow : Window
    {
        string hostName;

        public ManageWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            hostName = HostName.Text;

            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
            options.Username = "automation";
            options.Password = "automation";

            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + hostName + "\\root\\cimv2", options);
                scope.Connect();

                // Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    foreach (PropertyData prop in m.Properties)
                    {
                        Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
                    }

                    // Display the remote computer information
                    Details.Text = "Computer Name     : " + m["CSName"] + "\n" +
                                   "Windows Directory : " + m["WindowsDirectory"] + "\n" +
                                   "Operating System  : " + m["Caption"] + "\n" +
                                   "Version           : " + m["Version"] + "\n" +
                                   "Manufacturer      : " + m["Manufacturer"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
