using System.IO;
using System.Text;
using System;
using static System.Windows.Forms.AxHost;

namespace Victor
{
    public struct TLastStatus
    {
        public string group;
        public string recipe;

        public string[] sArrayString;

        public string[] whlName;
        public string[] whlRfid;

        public double[] whlBf;
        public double[] whlAf;
        
        public double[] drsBf;
        public double[] drsAf;
    }

    public class CLast
    {
        private static string _path = GVar.PATH_CONFIG + "LastStatus.cfg";
        private static TLastStatus tLast = new TLastStatus();

        private static void _Init()
        {
            tLast = new TLastStatus();
            tLast.sArrayString = new string[2];
        }

        public static void SaveRfid(int stage)
        {
            IniFile ini = new IniFile();

            ini.Save(_path);
        }

        public static void Save()
        {
            IniFile ini = new IniFile();
           

            ini.Save(_path);
        }

        public static void Save2()
        {
            IniFile ini = new IniFile();

            ini["tRecipe"]["Group"] = CRecipe.It.m_sGrp;
            ini["tRecipe"]["Name"] = CData.RecipeCur;


            ini.Save(_path);
        }

        public static void Save_LastConfig()
        {
            IniFile ini = new IniFile();

            ini["tRecipe"]["Path"] = CRecipe.It.FullPath;
            ini["tRecipe"]["Group"] = CRecipe.It.Group;
            ini["tRecipe"]["Name"] = CRecipe.It.Name;

            ini.Save(_path);
        }

        public static void Load_LastConfig()
        {
            string temp;
            if (File.Exists(_path) == false)
            {
                Save();
                return;
            }

            IniFile ini = new IniFile();
            ini.Load(_path);

            CRecipe.It.FullPath = ini["tRecipe"]["Path"].ToString();
            CRecipe.It.Group    = ini["tRecipe"]["Group"].ToString();
            CRecipe.It.Name     = ini["tRecipe"]["Name"].ToString();

            temp = CRecipe.It.FullPath;
            if (temp != "")
            {
                // 마지막 디바이스 파일 실제 존재 유무 판단
                // 없으면 디바이스 파일 로딩 안함 

                if (File.Exists(temp))
                {
                    CRecipe.It.Load(temp, true);
                }
                else
                { temp = ""; }
            }
        }

        public static void Load()
        {
            string temp = "";
            eMsg em;
            string sHead = "";
            string sMsg = "";

            if (File.Exists(_path) == false)
            {
                Save();
                return;
            }

            IniFile ini = new IniFile();
            ini.Load(_path);

            CRecipe.It.m_sGrp = ini["Device File"]["Group"].ToString();
            temp = ini["Device File"]["Path"].ToString();
            CData.RecipeCur = temp;
            CData.RecipeGr = CRecipe.It.m_sGrp; 
            if (temp != "") 
            {
                // 마지막 디바이스 파일 실제 존재 유무 판단
                // 없으면 디바이스 파일 로딩 안함 

                if (File.Exists(temp))
                {
                    CRecipe.It.Load(temp, true);
                }
                else
                { temp = ""; }
            }
        }
    }
}
