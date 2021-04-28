using ParserTestMakaev.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParserTestMakaev.BL
{
    public class User : IGettingClassProperty
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateLastChange { get; set; }
        public enum Status { Active,Disabled,Blocked}

       
    }
}
