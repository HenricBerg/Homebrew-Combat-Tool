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
using OfficeOpenXml;

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
            //try
            //{

            //    monsterList.AddRange(oldList);

            //    using (OpenFileDialog dlg = new OpenFileDialog())
            //    {
            //        dlg.Title = "Select XML to Merge";
            //        dlg.Filter = "XML files (*.xml) | *.xml;";


            //        DialogResult result = dlg.ShowDialog();

            //        if (result == DialogResult.OK)
            //        {
            //            var serializer = new XmlSerializer(typeof(List<Monster>));
            //            var newList = new List<Monster>();

            //            if (File.Exists(dlg.FileName))
            //            {
            //                using (var stream = new StreamReader(dlg.FileName))
            //                {
            //                    newList = (List<Monster>)serializer.Deserialize(stream);

            //                }

            //                Monster newMonster = new Monster();
            //                foreach (var monster in newList)
            //                {
            //                    Monster existing = monsterList.FirstOrDefault(x => x.name == monster.name);

            //                    if (existing == null)
            //                    {
            //                        monsterList.Add(monster);
            //                    }


            //                }

            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("WARNING! Merge unsuccessful, try again.");
            //}





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
        

        public static void ExcelToXmlConverter()
        {
            var fi = new FileInfo(@"C:\Users\Henric Berg\Downloads\bestiary.xlsx");

            using (var p = new ExcelPackage(fi))
            {
                
                var ws = p.Workbook.Worksheets[1];

                var monsterList = new List<Monster>();

                for (var row = 2; row <= ws.Dimension.End.Row; row++)
                {
                    var monster = new Monster();

                    for (var col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        if (ws.Cells[row, col].Value == null)
                            continue;

                        SetValueByColumn(ws.Cells[row, col].Value.ToString(), col, monster);
                    }

                    monsterList.Add(monster);

                }

                SaveMonsterListToFileAs(monsterList);
               
               
               
            }
        }

        public static void SetValueByColumn(string value, int col, Monster monster)
        {
            if(!string.IsNullOrEmpty(value) || !value.ToLower().Equals("null"))
            {
                switch (col)
                {
                    case 1:
                        monster.Name = value;
                        break;
                    case 2:
                        monster.CR = value;
                        break;
                    case 3:
                        monster.XP = value;
                        break;
                    case 4:
                        monster.Race = value;
                        break;
                    case 5:
                        monster.Class1 = value;
                        break;
                    case 6:
                        monster.Class1Lvl = value;
                        break;
                    case 7:
                        monster.Class2 = value;
                        break;
                    case 8:
                        monster.Class2Lvl = value;
                        break;
                    case 9:
                        monster.Alignment = value;
                        break;
                    case 10:
                        monster.Size = value;
                        break;
                    case 11:
                        monster.Type = value;
                        break;
                    case 12:
                        monster.Subtype1 = value;
                        break;
                    case 13:
                        monster.Subtype2 = value;
                        break;
                    case 14:
                        monster.Subtype3 = value;
                        break;
                    case 15:
                        monster.Subtype4 = value;
                        break;
                    case 16:
                        monster.Subtype5 = value;
                        break;
                    case 17:
                        monster.Subtype6 = value;
                        break;
                    case 18:
                        monster.AC = value;
                        break;
                    case 19:
                        monster.ACTouch = value;
                        break;
                    case 20:
                        monster.ACFlatFooted = value;
                        break;
                    case 21:
                        monster.HP = value;
                        break;
                    case 22:
                        monster.HD = value;
                        break;
                    case 23:
                        monster.Fortitude = value;
                        break;
                    case 24:
                        monster.Reflex = value;
                        break;
                    case 25:
                        monster.Will = value;
                        break;
                    case 26:
                        monster.Melee = value;
                        break;
                    case 27:
                        monster.Ranged = value;
                        break;
                    case 28:
                        monster.Space = value;
                        break;
                    case 29:
                        monster.Reach = value;
                        break;
                    case 30:
                        monster.STR = value;
                        break;
                    case 31:
                        monster.DEX = value;
                        break;
                    case 32:
                        monster.CON = value;
                        break;
                    case 33:
                        monster.INT = value;
                        break;
                    case 34:
                        monster.WIS = value;
                        break;
                    case 35:
                        monster.CHA = value;
                        break;
                    case 36:
                        monster.Feats = value;
                        break;
                    case 37:
                        monster.Skills = value;
                        break;
                    case 38:
                        monster.RacialMods = value;
                        break;
                    case 39:
                        monster.Languages = value;
                        break;
                    case 40:
                        monster.SQ = value;
                        break;
                    case 41:
                        monster.Environment = value;
                        break;
                    case 42:
                        monster.Organization = value;
                        break;
                    case 43:
                        monster.Treasure = value;
                        break;
                    case 44:
                        monster.Group = value;
                        break;
                    case 45:
                        monster.Gear = value;
                        break;
                    case 46:
                        monster.OtherGear = value;
                        break;
                    case 47:
                        monster.CharacterFlag = value;
                        break;
                    case 48:
                        monster.CompanionFlag = value;
                        break;
                    case 49:
                        monster.Speed = value;
                        break;
                    case 50:
                        monster.BaseSpeed = value;
                        break;
                    case 51:
                        monster.FlySpeed = value;
                        break;
                    case 52:
                        monster.FlyManeuverability = value;
                        break;
                    case 53:
                        monster.ClimbSpeed = value;
                        break;
                    case 54:
                        monster.SwimSpeed = value;
                        break;
                    case 55:
                        monster.BurrowSpeed = value;
                        break;
                    case 56:
                        monster.SpeedSpecial = value;
                        break;
                    case 57:
                        monster.SpeedLand = value;
                        break;
                    case 58:
                        monster.Fly = value;
                        break;
                    case 59:
                        monster.Climb = value;
                        break;
                    case 60:
                        monster.Burrow = value;
                        break;
                    case 61:
                        monster.Swim = value;
                        break;
                    case 62:
                        monster.VariantParent = value;
                        break;
                    case 63:
                        monster.ClassArchetypes = value;
                        break;
                    case 64:
                        monster.CompanionFamiliarLink = value;
                        break;
                    case 65:
                        monster.AlternateNameForm = value;
                        break;
                    case 66:
                        monster.ID = value;
                        break;
                    case 67:
                        monster.UniqueMonster = value;
                        break;
                    case 68:
                        monster.MR = value;
                        break;
                    case 69:
                        monster.Mythic = value;
                        break;
                    case 70:
                        monster.MT = value;
                        break;
                    case 71:
                        monster.Source = value;
                        break;
                    default:
                        throw new Exception("UNKNOWN VALUE: '" + value + "' IN COLUMN " + col);

            }
            }
            
        }
    }
}
