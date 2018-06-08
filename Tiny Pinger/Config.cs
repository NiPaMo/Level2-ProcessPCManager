using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Process_PC_Manager
{
    public class Config
    {
        private static string configPath = "\\\\Mamafil01\\Automatn_Pub\\Level 2 Utilities\\Process PC Manager\\Configurations\\List.txt";
        private static string filePath = "\\\\Mamafil01\\Automatn_Pub\\Level 2 Utilities\\Process PC Manager\\Configurations\\";
        private static string fileName;
        private static string[] configs = new string[10];
        private static string[] namesH = new string[25];
        private static string[] namesN = new string[25];
        
        public Config()
        {
            GetConfigList();
            GetConfig();
        }

        public void GetConfig()
        {
            if (fileName == null)
                fileName = configs[0];

            string file = filePath + fileName + ".txt";

            try
            {
                // Read the current configuration
                using (StreamReader sr = new StreamReader(file))
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
            string file = filePath + fileName + ".txt";

            try
            {
                // Write the current configuration
                using (StreamWriter sw = new StreamWriter(file))
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

        public void GetConfigList()
        {
            try
            {
                // Read the current configuration list
                using (StreamReader sr = new StreamReader(configPath))
                {
                    int i = 0;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        configs[i] = line;
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetHostName_Length()
        {
            return namesH.Count(s => s != null);
        }

        public int GetConfigs_Length()
        {
            return configs.Count(s => s != null);
        }

        public string GetHostName(int i)
        {
            return namesH[i];
        }

        public string GetConfigs(int i)
        {
            return configs[i];
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

        public void SetFileName(String str)
        {
            fileName = str;
        }

        public string GetFileName()
        {
            return fileName;
        }
    }
}
