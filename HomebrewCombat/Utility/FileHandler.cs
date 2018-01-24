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

    public static class FileHandler
    {



        public static void SaveMonsterListToFile(List<Monster> monsterList)
        {
            var serializer = new XmlSerializer(typeof(List<Monster>));


            using (var stream = new StreamWriter("monstermanual.xml"))
            {
                serializer.Serialize(stream, monsterList);


            }
        }


        public static void SaveDungeonLayoutToFile(List<ImageSource> imageList)
        {
            var serializer = new XmlSerializer(typeof(List<ImageSource>));

            if (!Directory.Exists(@"dungeonlayout"))
            {
                Directory.CreateDirectory(@"dungeonlayout");
            }

            using (var stream = new StreamWriter(@"dungeonlayout\dungeonlayout.xml"))
            {
                serializer.Serialize(stream, imageList);


            }
        }

        public static List<ImageSource> GetImageLayoutFromFile()
        {
            var serializer = new XmlSerializer(typeof(List<ImageSource>));
            var imageList = new List<ImageSource>();

            if (File.Exists(@"dungeonlayout\dungeonlayout.xml"))
            {
                using (var stream = new StreamReader(@"dungeonlayout\dungeonlayout.xml"))
                {
                   imageList = (List<ImageSource>)serializer.Deserialize(stream);

                }
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
            monsterList.AddRange(oldList);

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
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




            return monsterList;
        }

        public static List<Monster> GetMonsterListFromFile()
        {
            var serializer = new XmlSerializer(typeof(List<Monster>));
            var monsterList = new List<Monster>();

            if (File.Exists("monstermanual.xml"))
            {
                using (var stream = new StreamReader("monstermanual.xml"))
                {
                    monsterList = (List<Monster>)serializer.Deserialize(stream);

                }
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
            var url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Monster%20Manual%20Bestiary.xml";
            
            monsterList = GetMonsterManual(url);
            url = "https://raw.githubusercontent.com/ceryliae/DnDAppFiles/master/Bestiary/Curse%20of%20Strahd%20Bestiary.xml";
            monsterList.AddRange(GetMonsterManual(url));

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
