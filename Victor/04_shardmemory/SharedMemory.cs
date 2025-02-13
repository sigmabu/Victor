using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Victor.FileMapping;

namespace Victor
{

    #region Win32 DLL Import


    [Flags]
    public enum FileProtection : uint
    {
        PAGE_NOACCESS = 0x01,
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400,
        SEC_FILE = 0x800000,
        SEC_IMAGE = 0x1000000,
        SEC_RESERVE = 0x4000000,
        SEC_COMMIT = 0x8000000,
        SEC_NOCACHE = 0x10000000
    }


    [Flags]
    public enum FileMapAccess
    {
        FILE_MAP_COPY = 0x0001,
        FILE_MAP_WRITE = 0x0002,
        FILE_MAP_READ = 0x0004,
        FILE_MAP_ALL_ACCESS = 0x000F001F
    }

    public class FileMappingNative
    {
        public const int INVALID_HANDLE_VALUE = -1;

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFileMapping(
            IntPtr hFile,                   // Handle to the file
            IntPtr lpAttributes,            // Security Attributes
            FileProtection flProtect,       // File protection
            uint dwMaximumSizeHigh,         // High-order DWORD of size
            uint dwMaximumSizeLow,          // Low-order DWORD of size
            string lpName                   // File mapping object name
            );


        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr MapViewOfFile(
            IntPtr hFileMappingObject,      // Handle to the file mapping object
            FileMapAccess dwDesiredAccess,  // Desired access to file mapping object
            uint dwFileOffsetHigh,          // High-order DWORD of file offset
            uint dwFileOffsetLow,           // Low-order DWORD of file offset
            uint dwNumberOfBytesToMap       // Number of bytes map to the view
            );


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenFileMapping(
          FileMapAccess dwDesiredAccess,    // Access mode
          bool bInheritHandle,              // Inherit flag
          string lpName                     // File mapping object name
          );


        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool UnmapViewOfFile(
            IntPtr lpBaseAddress             // Base address of mapped view
            );


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetLastError();
    }


    #endregion // win32 

    public static class CSharedName
    {
        public const string SH_NAME = "_EMO_SHARED_COM";

    }

    public class CSharedMemory
    {

        private string m_strShardMemName;
        private Int32 m_Memorysize;

        IntPtr hMemPtr;
        IntPtr hMapFile;

        public static IntPtr CsmMem = IntPtr.Zero;




        public CSharedMemory(string sharedMapFileName, Int32 MemorySize)
        {

            m_strShardMemName = sharedMapFileName;
            m_Memorysize = MemorySize;

            // OpenSharedMemory(m_strShardMemName);
            CreateSharedMemory(m_strShardMemName, MemorySize);
        }


        public bool OpenSharedMemory(string strShardMemName)
        {
            // Open the named file mapping.
            hMapFile = FileMappingNative.OpenFileMapping(FileMapAccess.FILE_MAP_ALL_ACCESS, false, strShardMemName);


            if (hMapFile == IntPtr.Zero)
            {
                Trace.WriteLine(" Shared Mem {0} not open", strShardMemName);
                return false;
            }

            Trace.WriteLine(" Shared Mem {0} open", strShardMemName);

            hMemPtr = FileMappingNative.MapViewOfFile(hMapFile, FileMapAccess.FILE_MAP_ALL_ACCESS, 0, 0, (UInt32)m_Memorysize);

            if (hMemPtr == IntPtr.Zero)
            {
                Trace.WriteLine("Unable to map view of file error {0}", FileMappingNative.GetLastError().ToString());
                return false;
            }

            return true;
        }

        public void CloseSharedMemory()
        {
            FileMappingNative.UnmapViewOfFile(hMapFile);
            FileMappingNative.CloseHandle(hMemPtr);

            MsgMem = IntPtr.Zero;
        }



        public static IntPtr MsgMem;


        public void CreateSharedMemory(string strMapFileName, Int32 MemorySize)
        {
            hMemPtr = FileMappingNative.CreateFileMapping(
               (IntPtr)FileMappingNative.INVALID_HANDLE_VALUE,
               IntPtr.Zero,
               FileProtection.PAGE_READWRITE,// 파일 Mapping 을 쓰기 가능으로 Open 
               0,
               (UInt32)MemorySize,
               CSharedName.SH_NAME);

            if (hMemPtr == IntPtr.Zero)
            {
                Console.WriteLine("Unable to create file mapping object w/err 0x{0:X}", FileMappingNative.GetLastError());

            }

            // Create file view from the file mapping object. 버퍼에 매핑, 향후 pBuf 를 통하여 메모리에 쓸 수 있음 
            hMapFile = FileMappingNative.MapViewOfFile(hMemPtr, FileMapAccess.FILE_MAP_ALL_ACCESS, 0, 0, (UInt32)MemorySize);

            if (hMapFile == IntPtr.Zero)
            {
                Console.WriteLine("Unable to map view of file w/err 0x{0:X}", FileMappingNative.GetLastError().ToString());

            }

            MsgMem = hMapFile;
        }
    }
    public class CShared_mem //: IDisposable
    {
        static byte[] mcs_byte_mem;
        static IntPtr m_pAlloc_MCSMem;
        static int nMemSize;

        static CMSGMem CMsgMem = null;
        static CSharedMemory shMSGMem = null;
        private CShared_mem()
        {
        }

        private bool isDisposed = false;

        //public void Dispose()
        //{
        //    this.dispose(true);
        //    Close_Shredmemory();
        //}
        //private void dispose(bool disposing)
        //{
        //    if (this.isDisposed)
        //    {
        //        return;
        //    }

        //    if (disposing)
        //    {

        //    }
        //    this.isDisposed = true;
        //}

        private static string exe_name = @"D:\09_Execute\VMS23\" + "DTrace.exe";
        public static void Init_Shredmemory()
        {

            CMsgMem = new CMSGMem();

            nMemSize = Marshal.SizeOf(typeof(CMSGMem));
            shMSGMem = new CSharedMemory(CSharedName.SH_NAME, nMemSize);

            nMemSize = Marshal.SizeOf(typeof(CMSGMem));
            m_pAlloc_MCSMem = Marshal.AllocHGlobal(nMemSize);
            mcs_byte_mem = new Byte[nMemSize];

            Marshal.Copy(mcs_byte_mem, 0, m_pAlloc_MCSMem, mcs_byte_mem.Length);
            CMsgMem = (CMSGMem)Marshal.PtrToStructure(m_pAlloc_MCSMem, typeof(CMSGMem)); // byte 배열(메모리블럭)을 지정된 형식(struct or class) 으로 마샬링한다.

            CMsgMem = (CMSGMem)RawDeSerialize(mcs_byte_mem, CMsgMem.GetType()); // 초기화

            //string exe_name = @"C:\ProsysConf\bin\" + "\\DTrace.exe";
            //string exe_name = @"..\..\..\..\09_Execute\VMS23\" + "\\DTrace.exe";
            //string exe_name = @"D:\09_Execute\VMS23\" + "\\DTrace.exe";

            // 실행파일 실행
            Process[] processes = Process.GetProcessesByName(exe_name);

            if (processes.Length > 0)
            {
                Console.WriteLine($"{exe_name} 프로세스가 실행 중입니다.");
            }
            else
            {
                Process.Start(exe_name);
                Console.WriteLine($"{exe_name} 프로세스가 실행되지 않았습니다.");
            }            
        }

        public static void Terminate_Shredmemory()
        {
            Process[] processes = Process.GetProcessesByName(exe_name);

            foreach (var process in processes)
            {
                try
                {
                    process.Kill(); // 프로세스 종료
                    Console.WriteLine($"{exe_name} 프로세스가 종료되었습니다.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"프로세스를 종료하는 중 오류 발생: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// ShmData 구조체 초기화
        /// </summary>
        /// <param name="RawData"></param>
        /// <param name="ShmData"></param>
        /// <returns></returns>
        private static object RawDeSerialize(byte[] RawData, Type ShmData)  // 구조체 메모리 할당
        {
            int RawSize = Marshal.SizeOf(ShmData);

            //Size Over
            if (RawSize > RawData.Length)
            {
                return null;
            }

            IntPtr buffer = Marshal.AllocHGlobal(RawSize);
            Marshal.Copy(RawData, 0, buffer, RawSize);
            object retobj = Marshal.PtrToStructure(buffer, ShmData);
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }

        /// <summary>
        /// 구조체(struct)를 배열로 변화
        /// </summary>
        /// <param name="ShmStruct"></param>
        /// <param name="size"></param>
        /// <param name="PLCMEMBLOCK"></param>
        /// <returns></returns>
        private static byte[] RRawSerialize(object ShmStruct, int size, CMSGMem PLCMEMBLOCK)  // 구조체 바이트 배열로 변환 
        {
            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(PLCMEMBLOCK, buffer, false);
            byte[] RawData = new byte[size];
            Marshal.Copy(buffer, RawData, 0, size);
            Marshal.FreeHGlobal(buffer);
            return RawData;
        }

        public static void Close_Shredmemory()
        {
            int nMemSize = 0;
            nMemSize = Marshal.SizeOf(typeof(CMSGMem));
            CMsgMem.nstatus = 0;
            byte[] cmCsmembyte = RRawSerialize(CMsgMem, nMemSize, CMsgMem);
            Marshal.Copy(cmCsmembyte, 0, CSharedMemory.MsgMem, cmCsmembyte.Length); // 구조체 객체를 배열에 복사

            shMSGMem.CloseSharedMemory();
        }

        /// <summary>
        /// Sheared memory 에 Write 하기
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="sMsg"></param>
        /// <param name="color"></param>
        public static void SetMsg(int nPage, int nX, int nY, string sMsg, Color? color = null)
        {
            if (nY >= (int)CDef.PACKET_STR) return;
            else if (nX >= (int)CDef.PACKET_ROW) return;
            else if (nPage >= (int)CDef.PAGE_MAX) return;

            CMsgMem.packet[nPage].MsgData[nY].nX = (uint)nX;
            CMsgMem.packet[nPage].MsgData[nY].nY = (uint)nY;
            CMsgMem.packet[nPage].MsgData[nY].col = color.HasValue ? color.Value : Color.White;
            CMsgMem.packet[nPage].MsgData[nY].str = sMsg;

            byte[] cmCsmembyte = RRawSerialize(CMsgMem, nMemSize, CMsgMem);
            Marshal.Copy(cmCsmembyte, 0, CSharedMemory.MsgMem, cmCsmembyte.Length); // Data 배열에 Write


            //nPaper[nPage].x[0] = nX;
            //nPaper[nPage].y[nY] = nY;
            //nPaper[nPage].color[nY] = color.HasValue ? color.Value : Color.White;
            //nPaper[nPage].text[nY] = msg;

        }
    }
}
