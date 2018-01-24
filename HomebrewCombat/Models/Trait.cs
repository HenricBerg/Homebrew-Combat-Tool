using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewCombat
{
    public class Trait
    {
        public string name { get; set; }
        public List<string> textList { get; set; }


        public Trait()
        {
            textList = new List<string>();
        }
    }
}
