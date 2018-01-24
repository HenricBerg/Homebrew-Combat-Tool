using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewCombat
{
    public class Combatant
    {
        public string name { get; set; }
        public string initiative { get; set; }
        public int ID { get; set; }
        public int HP { get; set; }
        public string save { get; set; }
        public string AC { get; set; }
        public List<Condition> conditions { get; set; }
    }
}
