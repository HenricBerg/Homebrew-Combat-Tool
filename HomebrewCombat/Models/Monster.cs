using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewCombat
{
    public class Monster
    {

        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string alignment { get; set; }
        public string AC { get; set; }
        public string HP { get; set; }
        public string speed { get; set; }
        public string STR { get; set; }
        public string DEX { get; set; }
        public string CON { get; set; }
        public string INT { get; set; }
        public string WIS { get; set; }
        public string CHA { get; set; }
        public string skill { get; set; }
        public string passive { get; set; }
        public string languages { get; set; }
        public string CR { get; set; }
        public string immune { get; set; }
        public string senses { get; set; }
        public string save { get; set; }
        public string resist { get; set; }
        public string vulnerable { get; set; }
        public string conditionImmune { get; set; }
        public string description { get; set; }
        public string spells { get; set; }
        public string slots { get; set; }
        public string initiative { get; set; }


        
        public List<Trait> traitList { get; set; }
        public List<Action> actionList { get; set; }
        public List<Legendary> legendaryList { get; set; }
        public List<Reaction> reactionList { get; set; }

        public Monster()
        {
            traitList = new List<Trait>();
            actionList = new List<Action>();
            legendaryList = new List<Legendary>();
            reactionList = new List<Reaction>();
        }

    }
}
