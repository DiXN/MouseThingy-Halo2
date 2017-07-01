using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MouseThingy
{
    static class HaloMemoryWriter
    {
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>The GetForegroundWindow function returns a handle to the foreground window.</summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

        private static Process selectedProcess;

        public static Process SelectedProcess
        {
            get { return HaloMemoryWriter.selectedProcess; }
        }

        private static IntPtr processHandle;

        public static IntPtr ProcessHandle
        {
            get { return HaloMemoryWriter.processHandle; }
        }

        private static bool connected = false;

        public static bool Connected
        {
            get { return HaloMemoryWriter.connected; }
        }

        private static IntPtr baseAddress;

        public static IntPtr BaseAddress
        {
            get { return baseAddress; }
        }

        public static bool TryConnectToProcess()
        {
            Process[] processes = Process.GetProcessesByName("halo2");

            if (processes.Length == 0)
                return false;

            selectedProcess = processes[0];
            processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, selectedProcess.Id);
            connected = true;

            try
            {
                baseAddress = selectedProcess.MainModule.BaseAddress;
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public static bool WriteToMemory(uint memoryAddress, byte[] data)
        {
            if (!connected)
                return false;

            int bytesWritten = 0;
            return WriteProcessMemory(processHandle, memoryAddress, data, data.Length, new IntPtr(bytesWritten));
        }

        public static bool ReadFromMemory(uint memoryAddress, [Out] byte[] data)
        {
            if (!connected)
                return false;

            int bytesRead = 0;
            return ReadProcessMemory(processHandle, memoryAddress, data, data.Length, new IntPtr(bytesRead));
        }

        public static bool IsForegrounded()
        {     
            return GetForegroundWindow() == selectedProcess.MainWindowHandle;
        }
    }
}
