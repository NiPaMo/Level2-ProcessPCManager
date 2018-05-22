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
        private static string[] namesH = new string[20];
        private static string[] namesN = new string[20];
        private static int pos;

        public Config()
        {
            GetConfig();
        }

        public void GetConfig()
        {
            pos = 0;

            try
            {
                // Read the current configuration
                using (StreamReader sr = new StreamReader(fileName))
                {
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

        public void SetConfig()
        {
            try
            {
                // Write the current configuration
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    int i = 0;
                    string line;

                    while (i < pos)
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
