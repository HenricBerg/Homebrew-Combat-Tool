using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewCombat.Models
{
    public class Spell
    {
        public string name { get; set; }
        public string level { get; set; }
        public string school { get; set; }
        public string time { get; set; }
        public string range { get; set; }
        public string components { get; set; }
        public string duration { get; set; }
        public string classes { get; set; }
        public List<string> textList { get; set; }
        public string ritual { get; set; }
    }
}
