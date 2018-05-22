using System;
using System.IO;
using System.Windows;

namespace Tiny_Pinger
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        static string fileName = "\\\\Mamafil01\\Automatn_Pub\\Level 2 PC List\\Config.txt";
        static string[] namesH = new string[20];
        static string[] namesN = new string[20];
        static int pos = 0;

        public ConfigurationWindow()
        {
            InitializeComponent();

            GetConfig();
            ApplyConfig();
        }

        private void GetConfig()
        {
            try
            {
                // Read the current configuration
                using (StreamReader sr = new StreamReader(fileName)) {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        namesH[pos] = line.Substring(0, line.IndexOf(' '));
                        namesN[pos] = line.Substring(line.IndexOf(' ') + 1);
                        pos++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SetConfig()
        {
            try
            {
                // Read the current configuration
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    int i = 0;
                    string line;

                    while (i < pos)
                    {
                        line = namesH[pos] + ' ' + namesN[pos];
                        sw.WriteLine();
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ApplyConfig()
        {
            PC1_HostName.Text = namesH[0];
            PC1_NickName.Text = namesN[0];
            PC2_HostName.Text = namesH[1];
            PC2_NickName.Text = namesN[1];
            PC3_HostName.Text = namesH[2];
            PC3_NickName.Text = namesN[2];
            PC4_HostName.Text = namesH[3];
            PC4_NickName.Text = namesN[3];
            PC5_HostName.Text = namesH[4];
            PC5_NickName.Text = namesN[4];
            PC6_HostName.Text = namesH[5];
            PC6_NickName.Text = namesN[5];
            PC7_HostName.Text = namesH[6];
            PC7_NickName.Text = namesN[6];
            PC8_HostName.Text = namesH[7];
            PC8_NickName.Text = namesN[7];
            PC9_HostName.Text = namesH[8];
            PC9_NickName.Text = namesN[8];
            PC10_HostName.Text = namesH[9];
            PC10_NickName.Text = namesN[9];
            PC11_HostName.Text = namesH[10];
            PC11_NickName.Text = namesN[10];
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            namesH[0] = PC1_HostName.Text;
            namesN[0] = PC1_NickName.Text;
            namesH[1] = PC2_HostName.Text;
            namesN[1] = PC2_NickName.Text;
            namesH[2] = PC3_HostName.Text;
            namesN[2] = PC3_NickName.Text;
            namesH[3] = PC4_HostName.Text;
            namesN[3] = PC4_NickName.Text;
            namesH[4] = PC5_HostName.Text;
            namesN[4] = PC5_NickName.Text;
            namesH[5] = PC6_HostName.Text;
            namesN[5] = PC6_NickName.Text;
            namesH[6] = PC7_HostName.Text;
            namesN[6] = PC7_NickName.Text;
            namesH[7] = PC8_HostName.Text;
            namesN[7] = PC8_NickName.Text;
            namesH[8] = PC9_HostName.Text;
            namesN[8] = PC9_NickName.Text;
            namesH[9] = PC10_HostName.Text;
            namesN[9] = PC10_NickName.Text;
            namesH[10] = PC11_HostName.Text;
            namesN[10] = PC11_NickName.Text;

            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pos = 0;

            GetConfig();
            ApplyConfig();
        }
    }
}
