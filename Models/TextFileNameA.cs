using System;

namespace HwDIExample{
    public class TextFileNameA : ITextFileName
    {
        public string FileName => $"{Environment.CurrentDirectory}/bin/Debug/netcoreapp2.2/A.txt";
    }
}