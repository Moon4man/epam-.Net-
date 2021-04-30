using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xml
{
    class Program
    {
        static void FirstTask()
        {
            List<string> FileLines = new List<string>();
            using (StreamReader File = new StreamReader(Path.GetFullPath("Task1.txt")))
            {
                while (!File.EndOfStream)
                {
                    FileLines.Add(File.ReadLine());
                }
            }
            XmlWriterSettings Settings = new XmlWriterSettings();
            Settings.Encoding = Encoding.GetEncoding("windows-1251");
            XmlWriter Writer = XmlWriter.Create("Task1.xml", Settings);
            Writer.WriteStartDocument();
            Writer.WriteStartElement("root");
            for (int i = 0; i < FileLines.Count; i++)
            {
                Writer.WriteStartElement("line");
                Writer.WriteAttributeString("num", $"{i + 1}");
                Writer.WriteString(FileLines[i].ToString());
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();
        }

        static void SecondTask()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.GetEncoding("windows-1251");
            XmlWriter writer = XmlWriter.Create("Task2.xml", settings);

            using (var File = new StreamReader(Path.GetFullPath("Task2.txt")))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                while (!File.EndOfStream)
                {
                    string[] Number = File.ReadLine().Split(" ");
                    int Sum = 0;
                    List<int> Nums = new List<int>();
                    for (int i = 0; i < Number.Length; i++)
                    {
                        Sum += int.Parse(Number[i]);
                        Nums.Add(int.Parse(Number[i]));
                    }
                    var New = Nums.OrderByDescending(num => num).ToList();
                    writer.WriteStartElement("line");
                    writer.WriteAttributeString("Sum", $"{Sum}");

                    for (int i = 0; i < New.Count; i++)
                    {
                        writer.WriteStartElement("number");
                        writer.WriteString(New[i].ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                File.Close();
            }
            writer.Close();
        }

        static void Main(string[] args)
        {
            string Key;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the task number:");
                Console.WriteLine("#1 The first task \n#2 The second task \n#3 Exit");
                Key = Console.ReadLine();
                if (Key == "1")
                {
                    Console.Clear();
                    FirstTask();
                }
                else if (Key == "2")
                {
                    Console.Clear();
                    SecondTask();
                }
                else if (Key == "3")
                {

                    break;
                }
            }
        }
    }
}