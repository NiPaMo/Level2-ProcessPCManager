using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tiny_Pinger
{
    public class Config
    {
        private static string fileName = "\\\\Mamafil01\\Automatn_Pub\\Level 2 PC List\\Config.txt";
        private static string[] namesH = new string[25];
        private static string[] namesN = new string[25];

        public Config()
        {
            GetConfig();
        }

        public void GetConfig()
        {
            try
            {
                // Read the current configuration
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int i = 0;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        namesH[i] = line.Substring(0, line.IndexOf(' '));
                        namesN[i] = line.Substring(line.IndexOf(' ') + 1);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SetConfig()
        {
            try
            {
                // Write the current configuration
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    int i = 0;
                    string line;

                    while ((namesH[i] != null) && (namesN[i] != null))
                    {
                        line = namesH[i] + ' ' + namesN[i];
                        sw.WriteLine(line);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetHostName(int i)
        {
            return namesH[i];
        }


        public string GetNickName(int i)
        {
            return namesN[i];
        }

        public void SetHostName(String str, int i)
        {
            namesH[i] = str;
        }


        public void SetNickName(String str, int i)
        {
            namesN[i] = str;
        }
    }
}
