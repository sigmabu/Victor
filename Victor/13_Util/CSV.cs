using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace Victor
{
    public class CSV
    {
        public static string CSV_DATA_PATH = Path.Combine(Environment.CurrentDirectory, "Data");

        private static StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 경로에 폴더가 없으면 생성
        /// </summary>
        /// <param name="path"></param>
        public static void CreatePathFolder(string path)
        {
            string[] folderNames = path.Split('\\');
            string fullPath = string.Empty;
            for (int i = 0; i < folderNames.Length - 1; i++)
            {
                fullPath += folderNames[i] + '\\';
                DirectoryInfo di = new DirectoryInfo(fullPath);
                if (!di.Exists) di.Create();
            }
        }

        /// <summary>
        /// 컬렉션 CSV 파일 만들기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">컬렉션</param>
        /// <param name="path">파일 위치</param>
        /// <param name="overwrite">덮어쓰기 여부</param>
        /// <param name="writeHeader">헤더 작성 여부</param>
        /// <returns>작업 완료 여부</returns>
        public static bool CreateCSVFile<T>(ICollection<T> collection, string path, bool overwrite = true, bool writeHeader = true)
        {
            try
            {
                if (collection.Count > 0)
                {
                    CreatePathFolder(path);

                    sb.Length = 0;
                    path += ".csv";
                    if (!File.Exists(path) || overwrite)
                    {
                        // 텍스트 파일 생성
                        using (var writer = File.CreateText(path + ".temp"))
                        {
                            var enumerator = collection.GetEnumerator();
                            if (writeHeader)
                            {
                                // 1. 헤더 입력
                                if (enumerator.MoveNext())
                                {
                                    FieldInfo[] fieldInfos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                                    for (int i = 0; i < fieldInfos.Length; i++)
                                    {
                                        if (sb.Length > 0)
                                            sb.Append(',');
                                        sb.Append(fieldInfos[i].Name);
                                    }
                                    writer.WriteLine(sb);
                                }
                            }

                            // 2. 데이터 입력
                            enumerator = collection.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                FieldInfo[] fieldInfos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                                for (int i = 0; i < fieldInfos.Length; i++)
                                {
                                    if (i > 0) sb.Append(',');
                                    sb.Append(fieldInfos[i].GetValue(enumerator.Current));
                                }
                                sb.Append('\n');
                            }
                            sb.Length -= 1;

                            writer.Write(sb);
                            writer.Close();
                        }
                        try
                        {
                            File.Delete(path);
                        }
                        catch { }
                        File.Move(path + ".temp", path);
                        return true;
                    }
                    else
                        Console.WriteLine("이미 파일이 존재합니다.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// 텍스트 파일 열기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[,] OpenCSVFile(string path)
        {
            try
            {
                if (path.Contains(".csv") == false)
                {
                    path += ".csv";
                }

                if (File.Exists(path))
                {
                    string[] strs = System.IO.File.ReadAllLines(path, Encoding.Default);
                    if ( strs != null && strs.Length > 0)
                    {
                        int col = strs[0].Split(',').Length;
                        int row = strs.Length;

                        string[,] result = new string[row, col];
                        for (int i = 0; i < result.GetLength(0); i++)
                        {
                            string[] split = strs[i].Split(',');
                            int FindDot = strs[i].LastIndexOf(",");

                            if ((FindDot < 1) && (strs[i] != "EOF")) 
                            {
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < result.GetLength(1); j++)
                                {
                                    result[i, j] = split[j];
                                    if (strs[i] == "EOF") break;
                                }
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        /// <summary>
        /// 텍스트 파일 열기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[,] OpenMotorCSVFile(string path, out int nRowCnt)
        {
            nRowCnt = 0;
            try
            {
                if (path.Contains(".csv") == false)
                {
                    path += ".csv";
                }

                if (File.Exists(path))
                {
                    string[] strs = System.IO.File.ReadAllLines(path, Encoding.Default);
                    if (strs != null && strs.Length > 0)
                    {
                        int col = strs[0].Split(',').Length;
                        int row = strs.Length;

                        string[,] result = new string[row, col];
                        for (int i = 0; i < result.GetLength(0); i++)
                        {
                            string[] split = strs[i].Split(',');
                            int FindDot = strs[i].LastIndexOf(",");

                            if ((strs[i] == "EOF"))
                            {
                                result[i, 0] = strs[i];
                            }
                            else if ((strs[i] == "endList"))
                            {
                                result[i, 0] = strs[i];
                            }
                            else if (strs[i].Contains("#"))
                            {
                                result[i, 0] = strs[i];
                            }
                            else if ((FindDot < 1))
                            {
                                result[i,0] = strs[i];
                            }
                            else
                            {
                                for (int j = 0; j < result.GetLength(1); j++)
                                {
                                    result[i, j] = split[j];
                                    //if (strs[i] == "EOF") break;
                                }
                                nRowCnt = i;
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        /// <summary>
        /// CSV 텍스트 파일 열기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[,] Open_ErrorCSVFile(string path, out int nRowCnt)
        {
            nRowCnt = 0;
            try
            {
                if (path.Contains(".csv") == false)
                {
                    path += ".csv";
                }

                if (File.Exists(path))
                {
                    string all = File.ReadAllText(path, Encoding.UTF32);
                    string[] strs = all.Replace("\r", "").Split("\n".ToCharArray());
                    //string[] strs = File.ReadAllLines(path, Encoding.Default);
                    if (strs != null && strs.Length > 0)
                    {
                        int col = strs[0].Split(',').Length;
                        int row = strs.Length;
                        nRowCnt = row;

                        string[,] result = new string[row, col];
                        for (int i = 0; i < result.GetLength(0); i++)
                        {
                            string[] split = strs[i].Split(',');
                            int FindDot = strs[i].LastIndexOf(",");

                            if ((FindDot < 1) && (strs[i] != GVar.EOF))
                            {
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < result.GetLength(1); j++)
                                {
                                    result[i, j] = split[j];
                                    if (strs[i] == GVar.EOF) break;
                                }
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        /// <summary>
        /// CSV 텍스트 파일 열기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[,] OpenCSVFile(string path, out int nRowCnt)
        {
            nRowCnt = 0;
            try
            {
                if (path.Contains(".csv") == false)
                {
                    path += ".csv";
                }

                if (File.Exists(path))
                {
                    string[] strs = File.ReadAllLines(path, Encoding.Default);
                    if (strs != null && strs.Length > 0)
                    {
                        int col = strs[0].Split(',').Length;
                        int row = strs.Length;
                        nRowCnt = row;

                        string[,] result = new string[row, col];
                        for (int i = 0; i < result.GetLength(0); i++)
                        {
                            string[] split = strs[i].Split(',');
                            int FindDot = strs[i].LastIndexOf(",");

                            if ((FindDot < 1) && (strs[i] != GVar.EOF))
                            {
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < result.GetLength(1); j++)
                                {
                                    result[i, j] = split[j];
                                    if (strs[i] == GVar.EOF) break;
                                }
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        public static bool SaveCSVFile(string spath, string[,] sData, bool overwrite = true, bool writeHeader = true)
        {
            int nCount = 0;
            int nArrayCnt = 0;
            StringBuilder sb = new StringBuilder();
            StreamWriter writer;
            try
            {
                CreatePathFolder(spath);

                sb.Length = 0;
                if (!File.Exists(spath) || overwrite)
                {
                    using (writer = new StreamWriter(Path.Combine(spath), false, Encoding.Default))
                    {
                        nArrayCnt = sData.Length / sData.GetLength(0);
                        foreach (string str in sData)
                        {

                            if (str == "EOF")
                            {
                                sb.AppendLine("EOF");
                                break;
                            }
                            else if ((nCount +1) >= nArrayCnt)
                            {
                                sb.AppendLine(str);
                                nCount = 0;
                            }
                            else
                            {
                                sb.Append(str);
                                sb.Append(",");
                                nCount++;
                            }
                            
                        }
                        writer.WriteLine(sb);
                        writer.Close();
                    }
                }
                else
                    Console.WriteLine("이미 파일이 존재합니다.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        public static bool SaveMotorCSVFile(string spath, string[,] sData, bool overwrite = true, bool writeHeader = true)
        {
            int nCount = 0;
            int nArrayCnt = 0;
            StringBuilder sb = new StringBuilder();
            StreamWriter writer;
            try
            {
                CreatePathFolder(spath);

                sb.Length = 0;
                if (!File.Exists(spath) || overwrite)
                {
                    using (writer = new StreamWriter(Path.Combine(spath), false, Encoding.Default))
                    {
                        nArrayCnt = sData.Length / sData.GetLength(0);
                        foreach (string str in sData)
                        {       
                            if (string.IsNullOrEmpty(str))
                            {
                                continue; 
                            }
                            else if (str.Contains("EOF"))
                            {
                                sb.AppendLine(str);
                                break;
                            }
                            else if ((nCount + 1) >= nArrayCnt)
                            {
                                sb.AppendLine(str);
                                nCount = 0;
                            }
                            else if (str.Contains("endList"))
                            {
                                sb.AppendLine(str);
                                continue;
                            }
                            //else if (str.Contains(",") == false)
                            //{
                            //    sb.AppendLine("");
                            //    continue ;
                            //}
                            else if (str.Contains("#"))
                            {
                                sb.AppendLine(str);
                                continue;
                            }
                            else
                            {
                                sb.Append(str);
                                sb.Append(",");
                                nCount++;
                            }

                        }
                        writer.WriteLine(sb);
                        writer.Close();
                    }
                }
                else
                    Console.WriteLine("이미 파일이 존재합니다.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }



        /// <summary>
        /// 경로상의 모든 폴더 및 하위 파일 삭제 시도
        /// </summary>
        public static void DeleteDirectory(string path)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }

                try
                {
                    Directory.Delete(path, true);
                }
                catch (IOException)
                {
                    Directory.Delete(path, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Directory.Delete(path, true);
                }
            }
            catch { }
        }
    }
}
