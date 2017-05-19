using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Plate_Visualization
{
    class Scheme
    {
        public string Name
        {
            get; set;
        }

        public bool IsModified
        {
            get; set;
        }

        public string Filename
        {
            get; set;
        }

        public Plate Plate {
            get; set;
        }

        public List<Load> Loads {
            get; set;
        }

        public Scheme()
        {
            Plate = null;
            Loads = null;
            Filename = "";
        }

        public void SaveToFile(string filename)
        {
            if (filename != "")
            {
                Filename = filename;
                try
                {
                    FileStream fs = File.Open(filename, FileMode.Create);
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(Plate.Widths.Count);
                        foreach (Tuple<int, float> element in Plate.Widths)
                        {
                            writer.Write(element.Item1);
                            writer.Write(element.Item2);
                        }
                        writer.Write(Plate.Lengths.Count);
                        foreach (Tuple<int, float> element in Plate.Lengths)
                        {
                            writer.Write(element.Item1);
                            writer.Write(element.Item2);
                        }
                        writer.Write(Plate.Width);
                        writer.Write(Plate.Length);
                        foreach (Node node in Plate.Nodes)
                        {
                            writer.Write(node.Position.X);
                            writer.Write(node.Position.Y);
                            writer.Write(node.Bonds[0]);
                            writer.Write(node.Bonds[1]);
                            writer.Write(node.Bonds[2]);
                            writer.Write((int)node.State);
                        }
                        foreach (Element element in Plate.Elements)
                        {
                            writer.Write(element.Width);
                            writer.Write(element.Length);
                            writer.Write(element.Stiffness.E);
                            writer.Write(element.Stiffness.H);
                            writer.Write(element.Stiffness.V);
                            writer.Write((int)element.State);
                        }
                        writer.Write(Plate.Mode2D);
                        writer.Write(Loads.Count);
                        foreach (Load load in Loads)
                        {
                            writer.Write(load.Weight);
                            writer.Write(((Node)load.Position).Id);
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void SaveFile()
        {
            if (Filename != "")
            {
                SaveToFile(Filename);
            }
        }

        public bool OpenFromFile(string filename)
        {
            if (filename != "")
            {
                Filename = filename;
                try
                {
                    FileStream fs = File.Open(filename, FileMode.Open);
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        List<Tuple<int, float>> widths = new List<Tuple<int, float>>();
                        int n = reader.ReadInt32();
                        for (int i = 0; i < n; i++)
                        {
                            int item1 = reader.ReadInt32();
                            float item2 = reader.ReadSingle();
                            widths.Add(new Tuple<int, float>(item1, item2));
                        }
                        List<Tuple<int, float>> lengths = new List<Tuple<int, float>>();
                        n = reader.ReadInt32();
                        for (int i = 0; i < n; i++)
                        {
                            int item1 = reader.ReadInt32();
                            float item2 = reader.ReadSingle();
                            lengths.Add(new Tuple<int, float>(item1, item2));
                        }
                        Plate = new Plate(widths, lengths);
                        Plate.Width = reader.ReadInt32();
                        Plate.Length = reader.ReadInt32();
                        for (int i = 0; i < (Plate.Width + 1) * (Plate.Length + 1); i++)
                        {
                            float x = reader.ReadSingle();
                            float y = reader.ReadSingle();
                            Plate.Nodes[i].Position = new System.Drawing.PointF(x, y);

                            for (int j = 0; j < 3; j++)
                            {
                                int k = reader.ReadInt32();
                                Plate.Nodes[i].Bonds[j] = k;
                            }
                            Plate.Nodes[i].State = (State)reader.ReadInt32();
                        }
                        for (int i = 0; i < Plate.Width * Plate.Length; i++)
                        {
                            Plate.Elements[i].Width = reader.ReadDouble();
                            Plate.Elements[i].Length = reader.ReadDouble();
                            Plate.Elements[i].Stiffness.E = reader.ReadSingle();
                            Plate.Elements[i].Stiffness.H = reader.ReadSingle();
                            Plate.Elements[i].Stiffness.V = reader.ReadSingle();
                            Plate.Elements[i].State = (State)reader.ReadInt32();
                        }
                        Plate.Mode2D = reader.ReadBoolean();
                        int load_cnt = reader.ReadInt32();
                        Loads = new List<Load>();
                        for (int i = 0; i < load_cnt; i++)
                        {
                            Load l = new Load();
                            l.Weight = reader.ReadSingle();
                            int pos = reader.ReadInt32();
                            l.Position = Plate.Nodes[pos];
                            Loads.Add(l);
                        }
                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        public void Export(string filename)
        {
            if (filename != "")
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine("{0} {1}", Plate.Width, Plate.Length);
                    foreach (Element element in Plate.Elements)
                    {
                        sw.WriteLine("{0} {1} {2} {3} {4}", element.Width, element.Length, element.Stiffness.E, element.Stiffness.H, element.Stiffness.V);
                    }
                    foreach (Node node in Plate.Nodes)
                    {
                        sw.WriteLine("{0} {1} {2}", node.Bonds[0], node.Bonds[1], node.Bonds[2]);
                    }
                    sw.WriteLine(Loads.Count);
                    foreach (Load load in Loads)
                    {
                        sw.WriteLine("{0} {1}", load.Weight, ((Node)load.Position).Id + 1);
                    }
                }
            }
        }
    }
}
