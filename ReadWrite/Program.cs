using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @".\file.txt";
            List<Student> students = new List<Student>();
            students.Add(new Student("David", "Kroods", "awfwabf@Mail.ru", "666151515", 1, 21));
            students.Add(new Student("David", "Kroods", "awfwabf@Mail.ru", "666151515", 2, 21));
            students.Add(new Student("David", "Kroods", "awfwabf@Mail.ru", "666151515", 3, 21));
            students.Add(new Student("David", "Kroods", "awfwabf@Mail.ru", "666151515", 4, 21));
            students.Add(new Student("David", "Kroods", "awfwabf@Mail.ru", "666151515", 5, 21));


            students.ToSave(path);

            string[] array = Student.GetFromTXT(path, 5).ToArray();
            students = null;
            Student st3 = new Student(array);
        }
    }
}
