using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using HomebrewCombat.Models;
using System.Linq;

namespace HomebrewCombat
{

    public static class SpellFileHandler
    {
        public static List<Spell> GetSpellListFromSelectedFile()
        {

            var spellList = new List<Spell>();
            try
            {
                var serializer = new XmlSerializer(typeof(List<Spell>));
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Load XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "spells.xml";

                    DialogResult result = dlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (File.Exists(dlg.FileName))
                        {
                            using (var stream = new StreamReader(dlg.FileName))
                            {
                                spellList = (List<Spell>)serializer.Deserialize(stream);

                            }
                        }
                    }
                }

            }


            catch
            {
                MessageBox.Show("WARNING! Load unsuccessful, try again.");
            }


            return spellList;
        }

        public static void SaveSpellListToFileAs(List<Spell> spellList)
        {

            try
            {
                var serializer = new XmlSerializer(typeof(List<Spell>));

                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Title = "Save XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "spells.xml";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = new StreamWriter(dlg.FileName))
                        {
                            serializer.Serialize(stream, spellList);


                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("WARNING! Save unsuccessful, try again!");
            }





        }

        public static List<Spell> GetSpellListFromWeb()
        {
            List<Spell> spellList = new List<Spell>();
            try
            {

                var url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Spells/EE%20Spells.xml";

                spellList = GetSpells(url);
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Spells/PHB%20Spells.xml";
                spellList.AddRange(GetSpells(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Spells/SCAG%20Spells.xml";
                spellList.AddRange(GetSpells(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Unearthed%20Arcana/UA%20Starter%20Spells";
                spellList.AddRange(GetSpells(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Unearthed%20Arcana/Modern%20Spells.xml";
                spellList.AddRange(GetSpells(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Unearthed%20Arcana/Demon%20Summoning.xml";
                spellList.AddRange(GetSpells(url));
                MessageBox.Show("The database has been downloaded.");
            }
            catch
            {
                MessageBox.Show("Download unsuccessful.");
            }


            return spellList;

        }

        public static List<Spell> GetSpells(string url)
        {

            var xml = "";

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                xml = client.DownloadString(url);

            }

            var document = new XmlDocument();
            document.LoadXml(xml);
            var spellList = new List<Spell>();


            foreach (XmlNode spell in document.DocumentElement.SelectNodes("spell"))
            {

                var name = "N/A";
                var level = "N/A";
                var school = "N/A";
                var time = "N/A";
                var range = "N/A";
                var components = "N/A";
                var duration = "N/A";
                var classes = "N/A";
                var ritual = "NO";
                List<string> textList = new List<string>();


                try { name = spell.SelectSingleNode("name").InnerText; }
                catch { }
                try { level = spell.SelectSingleNode("level").InnerText; }
                catch { }
                try { school = spell.SelectSingleNode("school").InnerText; }
                catch { }
                try { time = spell.SelectSingleNode("time").InnerText; }
                catch { }
                try { range = spell.SelectSingleNode("range").InnerText; }
                catch { }
                try { components = spell.SelectSingleNode("components").InnerText; }
                catch { }
                try { duration = spell.SelectSingleNode("duration").InnerText; }
                catch { }
                try { classes = spell.SelectSingleNode("classes").InnerText; }
                catch { }
                try { ritual = spell.SelectSingleNode("ritual").InnerText; }
                catch { }

                try
                {

                    foreach (XmlNode text in spell.SelectNodes("text"))
                    {

                        textList.Add(text.InnerText);


                    }







                }
                catch { }



                spellList.Add(new Spell
                {
                    name = name,
                    level = level,
                    school = school,
                    time = time,
                    range = range,
                    components = components,
                    duration = duration,
                    classes = classes,
                    ritual = ritual,
                    textList = textList



                });
            }




            return spellList;
        }

    }


    public static class FileHandler
    {



        public static void SaveMonsterListToFileAs(List<Monster> monsterList)
        {

            try
            {
                var serializer = new XmlSerializer(typeof(List<Monster>));

                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Title = "Save XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "monstermanual.xml";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = new StreamWriter(dlg.FileName))
                        {
                            serializer.Serialize(stream, monsterList);


                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("WARNING! Save unsuccessful, try again!");
            }





        }



        public static void SaveDungeonLayoutToFileAs(List<ImageSource> imageList)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<ImageSource>));

                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Title = "Save XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "dungeonlayout.xml";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = new StreamWriter(dlg.FileName))
                        {
                            serializer.Serialize(stream, imageList);


                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("WARNING! Save unsuccessful, try again!");
            }

        }

        public static List<ImageSource> GetImageLayoutFromFile()
        {
            var imageList = new List<ImageSource>();
            try
            {
                var serializer = new XmlSerializer(typeof(List<ImageSource>));


                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Load XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "dungeonlayout.xml";

                    DialogResult result = dlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (File.Exists(dlg.FileName))
                        {
                            using (var stream = new StreamReader(dlg.FileName))
                            {
                                imageList = (List<ImageSource>)serializer.Deserialize(stream);

                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("WARNING! Load unsuccessful, try again.");
            }



            return imageList;
        }

        public static void SaveCombatantListToFile(List<Combatant> combatantList)
        {
            var serializer = new XmlSerializer(typeof(List<Combatant>));


            using (var stream = new StreamWriter("savestate.xml"))
            {
                serializer.Serialize(stream, combatantList);


            }
        }

        public static List<Monster> MergeList(List<Monster> oldList)
        {

            List<Monster> monsterList = new List<Monster>();
            try
            {

                monsterList.AddRange(oldList);

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Select XML to Merge";
                    dlg.Filter = "XML files (*.xml) | *.xml;";


                    DialogResult result = dlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var serializer = new XmlSerializer(typeof(List<Monster>));
                        var newList = new List<Monster>();

                        if (File.Exists(dlg.FileName))
                        {
                            using (var stream = new StreamReader(dlg.FileName))
                            {
                                newList = (List<Monster>)serializer.Deserialize(stream);

                            }

                            Monster newMonster = new Monster();
                            foreach (var monster in newList)
                            {
                                Monster existing = monsterList.FirstOrDefault(x => x.name == monster.name);

                                if (existing == null)
                                {
                                    monsterList.Add(monster);
                                }


                            }

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("WARNING! Merge unsuccessful, try again.");
            }





            return monsterList;
        }


        public static List<Monster> GetMonsterListFromSelectedFile()
        {

            var monsterList = new List<Monster>();
            try
            {
                var serializer = new XmlSerializer(typeof(List<Monster>));
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Load XML";
                    dlg.Filter = "XML files (*.xml) | *.xml;";
                    dlg.FileName = "monstermanual.xml";

                    DialogResult result = dlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (File.Exists(dlg.FileName))
                        {
                            using (var stream = new StreamReader(dlg.FileName))
                            {
                                monsterList = (List<Monster>)serializer.Deserialize(stream);

                            }
                        }
                    }
                }
            }


            catch
            {
                MessageBox.Show("WARNING! Load unsuccessful, try again.");
            }


            return monsterList;
        }

        public static List<Combatant> GetCombatantListFromFile()
        {
            var serializer = new XmlSerializer(typeof(List<Combatant>));
            var combatantList = new List<Combatant>();

            if (File.Exists("savestate.xml"))
            {
                using (var stream = new StreamReader("savestate.xml"))
                {
                    combatantList = (List<Combatant>)serializer.Deserialize(stream);

                }
            }


            return combatantList;
        }


        public static List<Monster> GetMonsterListFromWeb()
        {
            List<Monster> monsterList = new List<Monster>();
            try
            {

                var url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Monster%20Manual%20Bestiary.xml";

                monsterList = GetMonsterManual(url);
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Curse%20of%20Strahd%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));

                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Hoard%20of%20the%20Dragon%20Queen%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Out%20of%20the%20Abyss.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Phandelver%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Player%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Princes%20of%20the%20Apocalypse%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Storm%20King's%20Thunder.xml";

                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Tales%20From%20the%20Yawining%20Portal%20Bestiary.xml";
                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Volo's%20Bestiary.xml";

                monsterList.AddRange(GetMonsterManual(url));
                url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Storm%20King's%20Thunder.xml";

                monsterList.AddRange(GetMonsterManual(url));
                MessageBox.Show("The database has been downloaded.");
            }
            catch
            {
                MessageBox.Show("Download unsuccessful.");
            }


            return monsterList;

        }

        public static List<Monster> GetMonsterManual(string url)
        {

            var xml = "";

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                xml = client.DownloadString(url);

            }

            var document = new XmlDocument();
            document.LoadXml(xml);
            var monsterList = new List<Monster>();


            foreach (XmlNode monster in document.DocumentElement.SelectNodes("monster"))
            {
                {

                    var name = "N/A";
                    var size = "N/A";
                    var type = "N/A";
                    var alignment = "N/A";
                    var AC = "N/A";
                    var HP = "N/A";
                    var speed = "N/A";
                    var STR = "N/A";
                    var DEX = "N/A";
                    var CON = "N/A";
                    var INT = "N/A";
                    var WIS = "N/A";
                    var CHA = "N/A";
                    var skill = "N/A";
                    var passive = "N/A";
                    var languages = "N/A";
                    var CR = "N/A";
                    var immune = "N/A";
                    var senses = "N/A";
                    var save = "N/A";
                    var resist = "N/A";
                    var vulnerable = "N/A";
                    var conditionImmune = "N/A";
                    var description = "N/A";
                    var spells = "N/A";
                    var slots = "N/A";
                    var initiative = "N/A";
                    List<Trait> traitList = new List<Trait>();
                    List<Action> actionList = new List<Action>();
                    List<Legendary> legendaryList = new List<Legendary>();
                    List<Reaction> reactionList = new List<Reaction>();

                    try { name = monster.SelectSingleNode("name").InnerText; }
                    catch { }
                    try { size = monster.SelectSingleNode("size").InnerText; }
                    catch { }
                    try { type = monster.SelectSingleNode("type").InnerText; }
                    catch { }
                    try { alignment = monster.SelectSingleNode("alignment").InnerText; }
                    catch { }
                    try { AC = monster.SelectSingleNode("ac").InnerText; }
                    catch { }
                    try { HP = monster.SelectSingleNode("hp").InnerText; }
                    catch { }
                    try { speed = monster.SelectSingleNode("speed").InnerText; }
                    catch { }
                    try { STR = monster.SelectSingleNode("str").InnerText; }
                    catch { }
                    try { DEX = monster.SelectSingleNode("dex").InnerText; }
                    catch { }
                    try { CON = monster.SelectSingleNode("con").InnerText; }
                    catch { }
                    try { INT = monster.SelectSingleNode("int").InnerText; }
                    catch { }
                    try { WIS = monster.SelectSingleNode("wis").InnerText; }
                    catch { }
                    try { CHA = monster.SelectSingleNode("cha").InnerText; }
                    catch { }
                    try { skill = monster.SelectSingleNode("skill").InnerText; }
                    catch { }
                    try { passive = monster.SelectSingleNode("passive").InnerText; }
                    catch { }
                    try { languages = monster.SelectSingleNode("languages").InnerText; }
                    catch { }
                    try { CR = monster.SelectSingleNode("cr").InnerText; }
                    catch { }
                    try { immune = monster.SelectSingleNode("immune").InnerText; }
                    catch { }
                    try { senses = monster.SelectSingleNode("senses").InnerText; }
                    catch { }
                    try { save = monster.SelectSingleNode("save").InnerText; }
                    catch { }
                    try { resist = monster.SelectSingleNode("resist").InnerText; }
                    catch { }
                    try { vulnerable = monster.SelectSingleNode("vulnerable").InnerText; }
                    catch { }
                    try { conditionImmune = monster.SelectSingleNode("conditionImmune").InnerText; }
                    catch { }
                    try { description = monster.SelectSingleNode("description").InnerText; }
                    catch { }
                    try { spells = monster.SelectSingleNode("spells").InnerText; }
                    catch { }
                    try { slots = monster.SelectSingleNode("slots").InnerText; }
                    catch { }
                    try
                    {
                        foreach (XmlNode trait in monster.SelectNodes("trait"))
                        {
                            Trait newTrait = new Trait();
                            newTrait.name = trait.SelectSingleNode("name").InnerText;
                            List<string> textList = new List<string>();

                            foreach (XmlNode text in trait.SelectNodes("text"))
                            {

                                textList.Add(text.InnerText);


                            }

                            newTrait.textList = textList;

                            traitList.Add(newTrait);




                        }
                    }
                    catch { }
                    try
                    {
                        foreach (XmlNode action in monster.SelectNodes("action"))
                        {
                            Action newAction = new Action();
                            newAction.name = action.SelectSingleNode("name").InnerText;
                            newAction.text = action.SelectSingleNode("text").InnerText;
                            actionList.Add(newAction);
                        }
                    }
                    catch { }
                    try
                    {
                        foreach (XmlNode legendary in monster.SelectNodes("legendary"))
                        {
                            Legendary newLegendary = new Legendary();
                            newLegendary.name = legendary.SelectSingleNode("name").InnerText;
                            newLegendary.text = legendary.SelectSingleNode("text").InnerText;
                            legendaryList.Add(newLegendary);
                        }
                    }
                    catch { }
                    try
                    {
                        foreach (XmlNode reaction in monster.SelectNodes("reaction"))
                        {
                            Reaction newReaction = new Reaction();
                            newReaction.name = reaction.SelectSingleNode("name").InnerText;
                            newReaction.text = reaction.SelectSingleNode("text").InnerText;
                            reactionList.Add(newReaction);
                        }
                    }
                    catch { }



                    switch (int.Parse(DEX))
                    {
                        case 1:
                            initiative = "-5";
                            break;
                        case 2:
                            initiative = "-4";
                            break;
                        case 3:
                            initiative = "-4";
                            break;
                        case 4:
                            initiative = "-3";
                            break;
                        case 5:
                            initiative = "-3";
                            break;
                        case 6:
                            initiative = "-2";
                            break;
                        case 7:
                            initiative = "-2";
                            break;
                        case 8:
                            initiative = "-1";
                            break;
                        case 9:
                            initiative = "-1";
                            break;
                        case 10:
                            initiative = "0";
                            break;
                        case 11:
                            initiative = "0";
                            break;
                        case 12:
                            initiative = "1";
                            break;
                        case 13:
                            initiative = "1";
                            break;
                        case 14:
                            initiative = "2";
                            break;
                        case 15:
                            initiative = "2";
                            break;
                        case 16:
                            initiative = "3";
                            break;
                        case 17:
                            initiative = "3";
                            break;
                        case 18:
                            initiative = "4";
                            break;
                        case 19:
                            initiative = "4";
                            break;
                        case 20:
                            initiative = "5";
                            break;
                        case 21:
                            initiative = "5";
                            break;
                        case 22:
                            initiative = "6";
                            break;
                        case 23:
                            initiative = "6";
                            break;
                        case 24:
                            initiative = "7";
                            break;
                        case 25:
                            initiative = "7";
                            break;
                        case 26:
                            initiative = "8";
                            break;
                        case 27:
                            initiative = "8";
                            break;
                        case 28:
                            initiative = "9";
                            break;
                        case 29:
                            initiative = "9";
                            break;
                        case 30:
                            initiative = "10";
                            break;
                        default:
                            MessageBox.Show("Dexterity anomaly found on " + name + ". Setting initiative to 0.");
                            initiative = "0";
                            break;




                    }



                    monsterList.Add(new Monster
                    {
                        name = name,
                        size = size,
                        type = type,
                        alignment = alignment,
                        AC = AC,
                        HP = HP,
                        speed = speed,
                        STR = STR,
                        DEX = DEX,
                        CON = CON,
                        INT = INT,
                        WIS = WIS,
                        CHA = CHA,
                        skill = skill,
                        passive = passive,
                        languages = languages,
                        CR = CR,
                        immune = immune,
                        senses = senses,
                        save = save,
                        resist = resist,
                        vulnerable = vulnerable,
                        conditionImmune = conditionImmune,
                        legendaryList = legendaryList,
                        reactionList = reactionList,
                        traitList = traitList,
                        actionList = actionList,
                        description = description,
                        spells = spells,
                        slots = slots,
                        initiative = initiative


                    });
                }
            }



            return monsterList;
        }


    }
}
