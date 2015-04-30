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

        /// <summary>
        /// Returns a list of process names.
        /// </summary>
        /// <returns>A list of process names</returns>
        public static List<string> GetProcessNames()
        {
            List<string> names = new List<string>();

            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                names.Add(process.ProcessName);
            }

            return names;
        }

        /// <summary>
        /// Attempts to connect to a process with a given name.
        /// </summary>
        /// <param name="name">The name of the process</param>
        /// <returns>True if the connection was successful, false if not</returns>
        public static bool TryConnectToProcess(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            if (processes.Length == 0)
                return false;

            selectedProcess = processes[0];
            processHandle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, selectedProcess.Id);
            connected = true;
            baseAddress = selectedProcess.MainModule.BaseAddress;
            return true;
        }

        /// <summary>
        /// Writes a byte array to a spot in the currently selected processes memory.
        /// </summary>
        /// <param name="memoryAddress">The address to write to</param>
        /// <param name="data">The byte array to write</param>
        /// <returns>True upon success, false upon failure</returns>
        public static bool WriteToMemory(uint memoryAddress, byte[] data)
        {
            if (!connected)
                return false;

            int bytesWritten = 0;
            return WriteProcessMemory(processHandle, memoryAddress, data, data.Length, new IntPtr(bytesWritten));
        }

        /// <summary>
        /// Reads a processes memory.
        /// </summary>
        /// <param name="memoryAddress">The memory address to read</param>
        /// <param name="data">The byte array to fill</param>
        /// <returns></returns>
        public static bool ReadFromMemory(uint memoryAddress, [Out] byte[] data)
        {
            if (!connected)
                return false;

            int bytesRead = 0;
            return ReadProcessMemory(processHandle, memoryAddress, data, data.Length, new IntPtr(bytesRead));
        }

        /// <summary>
        /// Reads a processes memory.
        /// </summary>
        /// <param name="memoryAddress">The memory address to read</param>
        /// <param name="length">How many bytes to read</param>
        /// <returns>A byte array returning the bytes, null on fail</returns>
        public static byte[] ReadFromMemory(uint memoryAddress, uint length)
        {
            byte[] result = null;
            if (!connected)
                return result;

            result = new byte[length];
            int bytesRead = 0;
            ReadProcessMemory(processHandle, memoryAddress, result, result.Length, new IntPtr(bytesRead));
            return result;
        }

        /// <summary>
        /// Checks if the selected process is the foreground window.
        /// </summary>
        /// <returns>True if it is, false if not</returns>
        public static bool IsForegrounded()
        {
            IntPtr foregrounded = GetForegroundWindow();
            return foregrounded == selectedProcess.MainWindowHandle;
        }

        /// <summary>
        /// Runs through a processes memory in search of a particular array of bytes.
        /// </summary>
        /// <param name="start">The minimum memory boundary to search</param>
        /// <param name="end">The maximum memory boundary to search</param>
        /// <param name="bytes">The array of bytes to search for</param>
        /// <param name="address">The address that is returned when found</param>
        /// <returns></returns>
        public static bool Rummage(uint start, uint end, string bytes, out uint address)
        {
            uint bucketSize = 2048;
            uint length = end - start;

            byte[] fovSearchBytes = hexStringToByteArray(bytes);

            bool found = false;
            uint searchIndex = 0;

            for (uint i = start; i < end - fovSearchBytes.Length; i++)
            {
                IntPtr bytesRead = new IntPtr();

                byte[] bucket = new byte[bucketSize];
                ReadProcessMemory(processHandle, i, bucket, bucket.Length, bytesRead);

                bool inBucket = false;

                for (uint k = 0; k < bucket.Length; k++)
                {
                    if (bucket[k] == fovSearchBytes[0])
                    {
                        i += k;
                        inBucket = true;
                        break;
                    }
                }
                if ( !inBucket )
                {
                    i += (uint)bucket.Length - 1;
                    continue;
                }

                byte[] haypile = new byte[fovSearchBytes.Length];
                ReadProcessMemory(processHandle, i, haypile, haypile.Length, bytesRead);

                //MouseThingy.MainForm.barRummageProgress.Value = (int)(((float)(i - start) / (end - fovSearchBytes.Length - start))*100);

                int matched = 0;
                for (uint j = 0; j < fovSearchBytes.Length; j++)
                {
                    if (fovSearchBytes[j] != haypile[j])
                    {
                        break;
                    }
                    else
                    {
                        matched++;
                    }
                    if (matched == fovSearchBytes.Length - 1)
                    {
                        searchIndex = i;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    address = searchIndex;
                    return true;
                }
            }
            address = 0;
            return false;
        }

        /// <summary>
        /// Converts a space separated hex value string to a byte array.
        /// </summary>
        /// <param name="hexString">The space separated hex string to convert</param>
        /// <returns>A byte array representative of the hex string</returns>
        public static byte[] hexStringToByteArray( string hexString )
        {
            string[] splitHex = hexString.Split(' ');
            byte[] convertedHex = new byte[splitHex.Length];
            for ( int i = 0; i < splitHex.Length; i++ )
            {
                convertedHex[i] = (byte)Convert.ToInt32(splitHex[i], 16);
            }
            return convertedHex;
        }
    }
}
