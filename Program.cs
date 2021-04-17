using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DLLUnblocker
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUnblocker fub = new FileUnblocker();
            string[] list = Directory.EnumerateFiles("./", "*.*", SearchOption.AllDirectories).ToArray();
            foreach (string s in list)
            {
                Console.WriteLine($"Filename - {s} :: Unblocked -> {fub.Unblock(s)}");
            }
        }
        public class FileUnblocker
        {
            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteFile(string name);

            public bool Unblock(string fileName)
            {
                return DeleteFile(fileName + ":Zone.Identifier");
            }
        }
    }
}
