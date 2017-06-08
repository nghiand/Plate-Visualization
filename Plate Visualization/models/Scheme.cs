using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Class describes scheme
    /// </summary>
    public class Scheme
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Check if scheme is modified
        /// </summary>
        public bool IsModified
        {
            get; set;
        }
        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get; set;
        }
        /// <summary>
        /// Plate
        /// </summary>
        public Plate Plate
        {
            get; set;
        }
        /// <summary>
        /// List of loads
        /// </summary>
        public List<Load> Loads
        {
            get; set;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Scheme()
        {
            Plate = null;
            Loads = new List<Load>();
            Filename = "";
        }
        /// <summary>
        /// Save scheme to file
        /// </summary>
        /// <param name="filename">File name</param>
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
                        writer.Write(Name);
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
                            writer.Write(node.Delta);
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
                IsModified = false;
            }
        }

        /// <summary>
        /// Save scheme
        /// </summary>
        public void SaveFile()
        {
            if (Filename != "")
            {
                SaveToFile(Filename);
            }
        }

        /// <summary>
        /// Load scheme from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>True if scheme is loaded successfully</returns>
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
                        Name = reader.ReadString();
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
                            Plate.Nodes[i].Delta = reader.ReadSingle();
                            Plate.Nodes[i].State = (State)reader.ReadInt32();
                        }
                        for (int i = 0; i < Plate.Width * Plate.Length; i++)
                        {
                            Plate.Elements[i].Width = reader.ReadSingle();
                            Plate.Elements[i].Length = reader.ReadSingle();
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
                        IsModified = false;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Export scheme to file
        /// </summary>
        /// <param name="filename">File name</param>
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
                    sw.WriteLine(Plate.Nodes.Count);
                    foreach (Node node in Plate.Nodes)
                    {
                        sw.WriteLine("{0} {1} {2}", node.Bonds[0], node.Bonds[1], node.Bonds[2]);
                    }
                    List<float> loads = new List<float>();
                    for (int i = 0; i < Plate.Nodes.Count; i++)
                        loads.Add(0);
                    foreach (Load load in Loads)
                    {
                        loads[((Node)load.Position).Id] = load.Weight;
                    }
                    for (int i = 0; i < loads.Count; i++)
                        sw.WriteLine(loads[i]);
                    foreach (Element element in Plate.Elements)
                    {
                        sw.WriteLine("{0} {1} {2} {3}", element.Nodes[0].Id + 1, element.Nodes[1].Id + 1,
                            element.Nodes[3].Id + 1, element.Nodes[2].Id + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Import calculation result
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns></returns>
        public bool Import(string filename)
        {
            if (filename != "")
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    List<float> delta = new List<float>();
                    for (int i = 0; i < Plate.Nodes.Count; i++)
                    {
                        float k;
                        if (!float.TryParse(sr.ReadLine(), out k))
                        {
                            return false;
                        }
                        delta.Add(k);
                    }
                    if (delta.Count != Plate.Nodes.Count) return false;
                    for (int i = 0; i < Plate.Nodes.Count; i++)
                    {
                        Plate.Nodes[i].Delta = delta[i];
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Generate data to export
        /// </summary>
        /// <returns>Data list to export</returns>
        public List<object> DataToExport()
        {
            List<object> ret = new List<object>();

            if (Plate == null)
                throw new Exception("Plate was not assigned");
            ret.Add(Plate.Width);
            ret.Add(Plate.Length);

            foreach (Element element in Plate.Elements)
            {
                ret.Add(element.Width);
                ret.Add(element.Length);
                ret.Add(element.Stiffness.E);
                ret.Add(element.Stiffness.H);
                ret.Add(element.Stiffness.V);
            }
            ret.Add(Plate.Nodes.Count);
            foreach (Node node in Plate.Nodes)
            {
                ret.Add(node.Bonds[0]);
                ret.Add(node.Bonds[1]);
                ret.Add(node.Bonds[2]);
            }
            List<float> loads = new List<float>();
            for (int i = 0; i < Plate.Nodes.Count; i++)
                loads.Add(0);
            foreach (Load load in Loads)
            {
                loads[((Node)load.Position).Id] = load.Weight;
            }
            for (int i = 0; i < loads.Count; i++)
                ret.Add(loads[i]);
            foreach (Element element in Plate.Elements)
            {
                ret.Add(element.Nodes[0].Id + 1);
                ret.Add(element.Nodes[1].Id + 1);
                ret.Add(element.Nodes[3].Id + 1);
                ret.Add(element.Nodes[2].Id + 1);
            }

            return ret;
        }
        
        /// <summary>
        /// Clone scheme
        /// </summary>
        /// <returns>Cloned scheme</returns>
        public Scheme Clone()
        {
            Scheme ret = new Scheme();
            ret.Plate = Plate.Clone();
            ret.Loads = new List<Load>();
            for (int i = 0; i < Loads.Count; i++)
            {
                Load l = Loads[i].Clone();
                l.Position = ret.Plate.Nodes[((Node)Loads[i].Position).Id];
                ret.Loads.Add(l);
            }
            ret.Loads = Loads.GetRange(0, Loads.Count);
            return ret;
        }
    }
}
