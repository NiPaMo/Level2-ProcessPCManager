using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Process_PC_Manager
{
    public class Config
    {
        private static string configPath = "\\\\Mamafil01\\Automatn_Pub\\Level 2 Utilities\\Process PC Manager\\Configurations\\List.txt";
        private static string filePath = "\\\\Mamafil01\\Automatn_Pub\\Level 2 Utilities\\Process PC Manager\\Configurations\\";
        private static string fileName;
        private static List<String> configs = new List<string>();
        private static List<String> namesH = new List<string>();
        private static List<String> namesN = new List<string>();
        
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
                    namesH.Clear();
                    namesN.Clear();

                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        namesH.Add(line.Substring(0, line.IndexOf(' ')));
                        namesN.Add(line.Substring(line.IndexOf(' ') + 1));
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
                    configs.Clear();

                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        configs.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SetConfigList()
        {
            // Add the new configuration name to the list and sort alphabetically
            configs.Add(fileName);
            configs.Sort();

            try
            {
                // Write the current configuration list
                using (StreamWriter sw = new StreamWriter(configPath))
                {
                    int i = 0;
                    string line;

                    while ((configs[i] != null))
                    {
                        line = configs[i];
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

        public void RemoveConfigList()
        {
            // Add the new configuration name to the list and sort alphabetically
            configs.Remove(fileName);
            configs.Sort();

            try
            {
                // Write the current configuration list
                using (StreamWriter sw = new StreamWriter(configPath))
                {
                    int i = 0;
                    string line;

                    while ((configs[i] != null))
                    {
                        line = configs[i];
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
            try
            {
                return namesH[i];
            }
            catch
            {
                return null;
            }
        }

        public string GetNickName(int i)
        {
            try
            {
                return namesN[i];
            }
            catch
            {
                return null;
            }
        }

        public string GetConfigs(int i)
        {
            try
            {
                return configs[i];
            }
            catch
            {
                return null;
            }
        }

        public List<String> GetHostName()
        {
            return namesH;
        }

        public List<String> GetNickName()
        {
            return namesN;
        }

        public List<String> GetConfigs()
        {
            return configs;
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
