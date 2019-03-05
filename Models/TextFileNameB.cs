using System;

namespace HwDIExample{
    public class TextFileNameB : ITextFileName
    {
        public string FileName => $"{Environment.CurrentDirectory}/bin/Debug/netcoreapp2.2/B.txt";
    }
}