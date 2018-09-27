using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWrite
{
    class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PNumber { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }

        private static int state = 0;
        public int curState = 0;
        public Student(string name, string surName, string email, string pNumber, int id, int age)
        {
            state++;
            curState = state;
            Name = name;
            SurName = surName;
            Email = email;
            PNumber = pNumber;
            ID = id;
            Age = age;
        }

        public Student(string[] array)
            : this(array[0], array[1], array[2], array[3], Convert.ToInt32(array[4]), Convert.ToInt32(array[5]))
        {
            state++;
            curState = state;
        }

        public void Save(string path)
        {
            StreamWriter writer = File.CreateText(path);
            writer.WriteLine(state);
            writer.WriteLine($"{Name}\r\n{SurName}\r\n{Email}\r\n{PNumber}\r\n{ID}\r\n{Age}");
            writer.Close();
        }

        public static IEnumerable<string> GetFromTXT(string path, int state)
        {
            StreamReader reader = File.OpenText(path);
            while (!reader.EndOfStream)
            {
                if (reader.ReadLine().StartsWith((state + "->").ToString()))
                {
                   string value = reader.ReadLine();
                    while (!string.IsNullOrEmpty(value))
                    {
                        yield return value;
                        value = reader.ReadLine();
                    }
                    break;
                } 
            }
        }
    }
}
