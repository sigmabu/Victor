//using SuhwooUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Victor
{

    public class CRecipe : SingleTone<CRecipe>
    {
        public string m_sGrp = "";

        public string Group { get; private set; }

        public string Name { get; private set; }

        private CRecipe()
        {

        }

        public int InitRecipe(out tRecipe Dev)
        {
            Dev = new tRecipe();

            Dev.sDeviceName = "Default";

            Dev.nSaveValue = 0;
            Dev.dSaveValue = 0.0;

            DateTime datetime = DateTime.Now;
            Dev.dtEditLast = datetime.ToString();

            //ToDo : Add

            return 0;
        }

        public int Save(string group, string name)
        {
            string path = GetPath(group, name);
            return Save(path, ref CData.Recipe);
        }

        public int Save(string sPath)
        {
            return Save(sPath, ref CData.Recipe);
        }

        public int Save(string sPath, ref tRecipe rcp)
        {
            string oldData = CCheckFile.ReadOldFile(sPath);
            int iRet = 0;
            CData.RecipeCur = sPath;


            IniFile ini = new IniFile();
            ini["Information"]["Name"] = rcp.sDeviceName;

            ini["Common Data"]["Bool Value"] = rcp.bSaveValue;
            ini["Common Data"]["Integer Value"] = rcp.nSaveValue;
            ini["Common Data"]["Double Value"] = rcp.dSaveValue;

            ini.Save(sPath);

            // Last Status Save
            CLast.Save();

            return iRet;
        }

        public string GetPath(string group, string recipe)
        {
            return CGvar.PATH_DEVICE + group + "\\" + recipe + ".dev";
        }


        public int Load(string sPath, bool Init = false)
        {
            int iRet = 0;
            string sSc = "";
            string Temp = "";

            if (File.Exists(sPath) == false)
            { return -1; } // Error code

            // 불러오기전 디바이스 구조체 초기화 (배열 메모리 할당)
            if (Init)
            {
                InitRecipe(out CData.Recipe);
            }
            CIni mIni = new CIni(sPath);
            int FindDot = sPath.LastIndexOf(".");
            int Lastsp = sPath.LastIndexOf("\\");

            Temp = sPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);

            sSc = "Information";

            CData.Recipe.sDeviceName = Temp;
            CData.Recipe.dtEditLast = File.GetLastWriteTime(sPath).ToString();

            sSc = "Common Strip Information";
            bool.TryParse(mIni.Read(sSc, "Bool Value"), out CData.Recipe.bSaveValue);
            int.TryParse(mIni.Read(sSc, "Integer Value"), out CData.Recipe.nSaveValue);
            double.TryParse(mIni.Read(sSc, "Double Value"), out CData.Recipe.dSaveValue);

            return iRet;
        }

        //....
    }
}
