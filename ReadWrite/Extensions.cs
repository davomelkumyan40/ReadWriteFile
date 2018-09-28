using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ReadWrite
{
    static class Extensions
    {
        public static IEnumerable<string> ToEnumerable(this StreamReader reader)
        {
            while(!reader.EndOfStream)
            {
                string value = reader.ReadLine();
                if (string.IsNullOrEmpty(value))                
                yield break;

                yield return value;
            }
        }

        public static void ToSave(this List<Student> students, string path)
        {
            StreamWriter writer = new StreamWriter(path, true);
            //StreamWriter writer = File.CreateText(path);
             
            foreach (var item in students)
            {
                writer.WriteLine(new string('_', 10));
                writer.WriteLine(item.curState  + "->");
                writer.WriteLine($"{item.Name}\r\n{item.SurName}\r\n{item.Email}\r\n{item.PNumber}\r\n{item.ID}\r\n{item.Age}");
                writer.WriteLine();
            }
            writer.Close();
        }

