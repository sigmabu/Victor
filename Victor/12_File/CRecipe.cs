//using SuhwooUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Victor
{

    public class CRecipe : SingleTone<CRecipe>
    {
        public string m_sGrp = "";

        public string FullPath { get; set; }
        public string Group { get; set; }

        public string Name { get; set; }



        private CRecipe()
        {

        }

        public void CreateRecipe(string sPath)
        {

            IniFile ini = new IniFile();
            mRecipe rcp = new mRecipe();
            CRecipe.It.InitRecipe(out rcp);

            string sSection = "Information";
            ini[sSection]["Name"] = rcp.sDeviceName = sPath;
            ini[sSection]["Bool Value"]     = rcp.bSaveValue;
            ini[sSection]["Integer Value"]  = rcp.nSaveValue;
            ini[sSection]["Double Value"]   = rcp.dSaveValue;
            ini[sSection]["Last Update"]    = rcp.dtEditLast;

            sSection = eRecipGroup.Common.ToString();
            ini[sSection]["Bool Value"]     = rcp.C_Data.bCValue;
            ini[sSection]["Integer Value"]  = rcp.C_Data.nCValue;
            ini[sSection]["Double Value"]   = rcp.C_Data.dCValue;
            ini[sSection]["string Value"]   = rcp.C_Data.sCValue;

            sSection = eRecipGroup.Loader.ToString();
            ini[sSection]["Bool Value"]     = rcp.L_Data.bLValue;
            ini[sSection]["Integer Value"]  = rcp.L_Data.nLValue;
            ini[sSection]["Double Value"]   = rcp.L_Data.dLValue;
            ini[sSection]["string Value"]   = rcp.L_Data.sLValue;

            sSection = eRecipGroup.Unloader.ToString();
            ini[sSection]["Bool Value"]     = rcp.Ul_Data.bULValue;
            ini[sSection]["Integer Value"]  = rcp.Ul_Data.nULValue;
            ini[sSection]["Double Value"]   = rcp.Ul_Data.dULValue;
            ini[sSection]["string Value"]   = rcp.Ul_Data.sULValue;

            ini.Save(sPath);
            CLast.Save();
        }

        public int InitRecipe(out mRecipe rcp)
        {
            rcp = new mRecipe();

            //rcp.sDeviceName = (string.IsNullOrEmpty(rcp.sDeviceName)) ? "Default" : rcp.sDeviceName;
            rcp.bSaveValue = false;
            rcp.nSaveValue = 0;
            rcp.dSaveValue = 0.0;
            DateTime datetime = DateTime.Now;
            rcp.dtEditLast = datetime.ToString();

            rcp.C_Data.bCValue = false;
            rcp.C_Data.nCValue = 1;
            rcp.C_Data.dCValue = 1.0;
            rcp.C_Data.sCValue = "Common = 1.0";

            rcp.L_Data.bLValue = false;
            rcp.L_Data.nLValue = 2;
            rcp.L_Data.dLValue = 2.0;
            rcp.L_Data.sLValue = "Loader = 2.0";

            rcp.Ul_Data.bULValue = false;
            rcp.Ul_Data.nULValue = 3;
            rcp.Ul_Data.dULValue = 3.0;
            rcp.Ul_Data.sULValue = "UnLoader = 3.0";

            return 0;
        }

        public int Save(string group, string name)
        {
            string path = GetPath(group, name);
            return Save(path, ref CData.tRecipe);
        }

        public int Save(string sPath)
        {
            return Save(sPath, ref CData.tRecipe);
        }

        public int Save(string sPath, ref mRecipe rcp)
        {
            string oldData = CCheckFile.ReadOldFile(sPath);
            int iRet = 0;
            string sSection = string.Empty;
            CData.RecipeCur = sPath;
            DateTime datetime = DateTime.Now;
            rcp.dtEditLast = datetime.ToString();

            IniFile ini = new IniFile();
            sSection = GVar.ini_RecipeSection[0];
            ini[sSection][GVar.RecipeKeyName[0][0]] = rcp.sDeviceName;
            ini[sSection][GVar.RecipeKeyName[0][1]] = rcp.bSaveValue;
            ini[sSection][GVar.RecipeKeyName[0][2]] = rcp.nSaveValue;
            ini[sSection][GVar.RecipeKeyName[0][3]] = rcp.dSaveValue;
            ini[sSection][GVar.RecipeKeyName[0][4]] = rcp.dtEditLast;

            sSection = GVar.ini_RecipeSection[1];
            ini[sSection][GVar.RecipeKeyName[1][0]] = rcp.C_Data.bCValue;
            ini[sSection][GVar.RecipeKeyName[1][1]] = rcp.C_Data.nCValue;
            ini[sSection][GVar.RecipeKeyName[1][2]] = rcp.C_Data.dCValue;
            ini[sSection][GVar.RecipeKeyName[1][3]] = rcp.C_Data.sCValue;

            sSection = GVar.ini_RecipeSection[2];
            ini[sSection][GVar.RecipeKeyName[2][0]] = rcp.L_Data.bLValue;
            ini[sSection][GVar.RecipeKeyName[2][1]] = rcp.L_Data.nLValue;
            ini[sSection][GVar.RecipeKeyName[2][2]] = rcp.L_Data.dLValue;
            ini[sSection][GVar.RecipeKeyName[2][3]] = rcp.L_Data.sLValue;

            sSection = GVar.ini_RecipeSection[3];
            ini[sSection][GVar.RecipeKeyName[3][0]] = rcp.Ul_Data.bULValue;
            ini[sSection][GVar.RecipeKeyName[3][1]] = rcp.Ul_Data.nULValue;
            ini[sSection][GVar.RecipeKeyName[3][2]] = rcp.Ul_Data.dULValue;
            ini[sSection][GVar.RecipeKeyName[3][3]] = rcp.Ul_Data.sULValue;

            ini.Save(sPath);
            CLast.Save();

            return iRet;
        }

        public string GetPath(string group, string recipe)
        {
            return GVar.PATH_DEVICE + group + "\\" + recipe + ".dev";
        }


        public int Load(string sPath, bool Init = false)
        {
            int iRet = 0;
            string sSection = string.Empty;
            string Temp = string.Empty;

            if (File.Exists(sPath) == false)
            { return -1; } // Error code

            // 불러오기전 디바이스 구조체 초기화 (배열 메모리 할당)
            if (Init)
            {
                InitRecipe(out CData.tRecipe);
            }
            CIni mIni = new CIni(sPath);
            int FindDot = sPath.LastIndexOf(".");
            int Lastsp = sPath.LastIndexOf("\\");

            Temp = sPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);

            CData.tRecipe.sDeviceName = Temp;
            CData.tRecipe.dtEditLast = File.GetLastWriteTime(sPath).ToString();

            sSection = GVar.ini_RecipeSection[0];
            CData.tRecipe.sDeviceName = mIni.Read(sSection, GVar.RecipeKeyName[0][0]);
            bool.TryParse  (mIni.Read(sSection, GVar.RecipeKeyName[0][1]), out CData.tRecipe.bSaveValue);
            int.TryParse   (mIni.Read(sSection, GVar.RecipeKeyName[0][2]), out CData.tRecipe.nSaveValue);
            double.TryParse(mIni.Read(sSection, GVar.RecipeKeyName[0][3]), out CData.tRecipe.dSaveValue);
            CData.tRecipe.dtEditLast = mIni.Read(sSection, GVar.RecipeKeyName[0][4]);

            sSection = GVar.ini_RecipeSection[1];
            bool.TryParse   (mIni.Read(sSection, GVar.RecipeKeyName[1][0]), out CData.tRecipe.C_Data.bCValue);
            int.TryParse    (mIni.Read(sSection, GVar.RecipeKeyName[1][1]), out CData.tRecipe.C_Data.nCValue);
            double.TryParse (mIni.Read(sSection, GVar.RecipeKeyName[1][2]), out CData.tRecipe.C_Data.dCValue);
            CData.tRecipe.C_Data.sCValue = mIni.Read(sSection, GVar.RecipeKeyName[1][3]);

            sSection = GVar.ini_RecipeSection[2];
            bool.TryParse   (mIni.Read(sSection, GVar.RecipeKeyName[2][0]), out CData.tRecipe.L_Data.bLValue);
            int.TryParse    (mIni.Read(sSection, GVar.RecipeKeyName[2][1]), out CData.tRecipe.L_Data.nLValue);
            double.TryParse (mIni.Read(sSection, GVar.RecipeKeyName[2][2]), out CData.tRecipe.L_Data.dLValue);
            CData.tRecipe.L_Data.sLValue = mIni.Read(sSection, GVar.RecipeKeyName[2][3]);

            sSection = GVar.ini_RecipeSection[3];
            bool.TryParse   (mIni.Read(sSection, GVar.RecipeKeyName[3][0]), out CData.tRecipe.Ul_Data.bULValue);
            int.TryParse    (mIni.Read(sSection, GVar.RecipeKeyName[3][1]), out CData.tRecipe.Ul_Data.nULValue);
            double.TryParse (mIni.Read(sSection, GVar.RecipeKeyName[3][2]), out CData.tRecipe.Ul_Data.dULValue);
            CData.tRecipe.Ul_Data.sULValue = mIni.Read(sSection, GVar.RecipeKeyName[3][3]);
            return iRet;
        }
    }
}
