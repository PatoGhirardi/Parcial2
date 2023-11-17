using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8
{
    public class Carpetas
    {
        public string Name {  get; set; }
        public string Path { get; set; }

        public Carpetas(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}