using System;

namespace HwDIExample{
    public class TextFileNameA : ITextFileName
    {
        public string FileName(){
            string path = Environment.CurrentDirectory + Startup.pathA;
            return path;
        }
    }
}