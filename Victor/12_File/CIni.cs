using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Victor
{
    public class CIni
    {
        private string m_sPath = "";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
                            string section,
                            string key,
                            string val,
                            string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
                            string section,
                            string key,
                            string def,
                            StringBuilder retVal,
                            int size,
                            string filePath);

        [DllImport("kernel32")] 
        private static extern int GetPrivateProfileString(
                            string Section, 
                            int Key, 
                            string Value, 
                            [MarshalAs(UnmanagedType.LPArray)] byte[] Result, 
                            int Size, 
                            string FileName);
        [DllImport("kernel32")] 
        private static extern int GetPrivateProfileString(
                            int Section, 
                            string Key, 
                            string Value, 
                            [MarshalAs(UnmanagedType.LPArray)] byte[] Result, 
                            int Size, 
                            string FileName);

        public CIni(string sPath)
        {
            //if (strPath.Contains(".ini") == false)
            //    strPath += ".ini";

            int nCount = 0;
            m_sPath = sPath;
            if (ExistINI() == false) return;

            GVar.ini_RecipeSection = GetSectionNames(m_sPath);
            foreach (string str in GVar.ini_RecipeSection)
            {
                GVar.ini_RecipeKey = GetEntryNames(m_sPath, str);
                GVar.RecipeKeyName[nCount] = new string[] { };
                GVar.RecipeKeyName[nCount] = GetEntryNames(m_sPath, str);

                nCount++;
            }
        }

        public bool ExistINI()
        {
            return File.Exists(m_sPath);
        }

        public void Write(string sSection, string sKey, int iVal)
        {
            Write(sSection, sKey, iVal.ToString());
        }

        public void Write(string sSection, string sKey, double dVal)
        {
            Write(sSection, sKey, dVal.ToString());
        }

        public void Write(string sSection, string sKey, string sVal)
        {
            WritePrivateProfileString(sSection, sKey, sVal, m_sPath);
        }

        public void DeleteSection(string sSection)
        {
            WritePrivateProfileString(sSection, null, null, m_sPath);
        }

        public string[] GetSectionNames(string sPath)  // ini 파일 안의 모든 section 이름 가져오기       
        {
            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileString(0, "", "", bytes, maxsize, sPath);
                if (size < maxsize - 2)
                {
                    string Selected = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    return Selected.Split(new char[] { '\0' });
                }
            }
        }

        public string[] GetEntryNames(string sPath,string section)   // 해당 section 안의 모든 키 값 가져오기       
        {
            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileString(section, 0, "", bytes, maxsize, sPath);

                if (size < maxsize - 2)
                {
                    string entries = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    return entries.Split(new char[] { '\0' });
                }
            }
        }


        public string Read(string sSection, string sKey)
        {
            StringBuilder sValue = new StringBuilder(255);
            int i = GetPrivateProfileString(sSection, sKey, "", sValue, 255, m_sPath);
            return sValue.ToString();
        }

        /// <summary>
        /// Read 후 Int형으로 반환
        /// </summary>
        /// <param name="sSection"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public int ReadI(string sSection, string sKey)
        {
            try
            {
                string sVal = Read(sSection, sKey);
                if (sVal == "")
                    sVal = "0";
                return Convert.ToInt32(sVal);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }
        }

        /// <summary>
        /// Read 후 Double형으로 반환
        /// </summary>
        /// <param name="sSection"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public double ReadD(string sSection, string sKey)
        {
            try
            {
                string sVal = Read(sSection, sKey);
                if (sVal == "")
                    sVal = "0";
                return Convert.ToDouble(sVal);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }
        }
    }
}

