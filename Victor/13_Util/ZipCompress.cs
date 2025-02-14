using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Victor
{
    public class ZipCompress
    {
        private string sCompress_file;
        private string sCompress_Path;
        public ZipCompress()
        {
            string sPath = "";
            sCompress_file = sPath;
            sCompress_Path = sPath;
        }
        public void Compress_File()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "압축할 파일 선택";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    string zipFile = sourceFile + ".zip";

                    using (FileStream zipStream = new FileStream(zipFile, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile));
                    }

                    MessageBox.Show($"파일이 {zipFile}로 압축되었습니다.", "완료");
                }
            }
        }

        public void Decompress_File()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "압축 해제할 ZIP 파일 선택";
                ofd.Filter = "ZIP 파일 (*.zip)|*.zip";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string zipFile = ofd.FileName;
                    string extractPath = Path.Combine(Path.GetDirectoryName(zipFile), "Extracted");

                    Directory.CreateDirectory(extractPath);
                    ZipFile.ExtractToDirectory(zipFile, extractPath);

                    MessageBox.Show($"파일이 {extractPath} 폴더에 압축 해제되었습니다.", "완료");
                }
            }
        }

    }
}
