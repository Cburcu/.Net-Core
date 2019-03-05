using System;

namespace HwDIExample{
    public class TextFileNameB : ITextFileName
    {
        public string FileName(){
            string path = Environment.CurrentDirectory + Startup.pathB;
            return path;
        }
    }
}