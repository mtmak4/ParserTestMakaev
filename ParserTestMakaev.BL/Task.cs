using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserTestMakaev.BL
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateLastChange { get; set; }
        public string Status { get; set; } 
        public User Director { get; set; }
        public User Executor { get; set; }

    }
}
