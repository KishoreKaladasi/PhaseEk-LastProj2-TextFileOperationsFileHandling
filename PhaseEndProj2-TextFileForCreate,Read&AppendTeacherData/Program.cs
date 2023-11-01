using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseEndProj2_TextFileForCreate_Read_AppendTeacherData
{
    internal class Program
    {
        class Teacher
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string ClassAndSection { get; set; }
        }
        static void Main(string[] args)
        {
            CreateTextFile();

            //ReadTextFile();

            //UpdateTextFile();



            Console.ReadLine();
        }

        private static void UpdateTextFile()
        {
            Teacher newTeacher = new Teacher { ID = 108, Name = "Sara", ClassAndSection = "EEE-B" };
            //checking file is in the given location or NOT if not it goes to else block
            bool ans = File.Exists(@"C:\Users\ASUS\source\repos\PhaseEndProj2-TextFileForCreate,Read&AppendTeacherData\Teacher.txt");
            if (ans == true)
            {
                //this command used to open the file and read it ... 
                FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\PhaseEndProj2-TextFileForCreate,Read&AppendTeacherData\Teacher.txt", FileMode.Append, FileAccess.Write);
                StreamWriter appending = new StreamWriter(fs);
                //this try catch block used to if there any exceptions catch block executed otherwise try executed

                try
                {
                    appending.WriteLine($"ID: {newTeacher.ID}");
                    appending.WriteLine($"Name: {newTeacher.Name}");
                    appending.WriteLine($"Class and Section: {newTeacher.ClassAndSection}");
                    appending.WriteLine();
                    // Add an empty line for separation or formatting
                    Console.WriteLine("New teacher data has been appended to the file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    appending.Close();
                    appending.Dispose();
                    fs.Close();
                    fs.Dispose();
                }

            }
            else
            {
                Console.WriteLine("file does'nt exist on your given location");
            }
        }

        private static void ReadTextFile()
        {
            //checking file is in the given location or NOT if not it goes to else block
            bool ans = File.Exists(@"C:\Users\ASUS\source\repos\PhaseEndProj2-TextFileForCreate,Read&AppendTeacherData\Teacher.txt");
            if (ans == true)
            {
                //this try catch block used to if there any exceptions catch block executed otherwise try executed
                try
                {
                    //this command used to open the file and read it ... 
                    FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\PhaseEndProj2-TextFileForCreate,Read&AppendTeacherData\Teacher.txt", FileMode.Open, FileAccess.Read);
                    StreamReader reading = null;
                    //this try catch block used to if there any exceptions catch block executed otherwise try executed
                    try
                    {
                        //Retrieve the data from the file to readme string ..and print it in console..
                        reading = new StreamReader(fs);
                        string readme = reading.ReadToEnd();
                        Console.WriteLine(readme);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        fs.Close();
                        fs.Dispose();
                        reading.Close();
                        reading.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                Console.WriteLine("File does'nt exist on the given location");
            }
        }

        private static void CreateTextFile()
        {
            List<Teacher> teachers = new List<Teacher>();

            teachers.Add(new Teacher { ID = 101, Name = "Kishore", ClassAndSection = "EEE-A" });
            teachers.Add(new Teacher { ID = 102, Name = "Ram", ClassAndSection = "EEE-B" });
            teachers.Add(new Teacher { ID = 103, Name = "Kishan", ClassAndSection = "EEE-A" });
            teachers.Add(new Teacher { ID = 104, Name = "Raju", ClassAndSection = "EEE-B" });
            teachers.Add(new Teacher { ID = 105, Name = "Ravi", ClassAndSection = "EEE-A" });
            teachers.Add(new Teacher { ID = 106, Name = "Roja", ClassAndSection = "EEE-A" });
            teachers.Add(new Teacher { ID = 107, Name = "Chris", ClassAndSection = "EEE-B" });

            //creating a txt file by giving location
            FileStream fs = new FileStream(@"C:\Users\ASUS\source\repos\PhaseEndProj2-TextFileForCreate,Read&AppendTeacherData\Teacher.txt", FileMode.Create, FileAccess.Write);
            //creating a obj for writing
            StreamWriter writing = new StreamWriter(fs);
            //lets assign text to fieds with object
            try
            {
                foreach (var teacher in teachers)
                {
                    writing.WriteLine($"ID: {teacher.ID}");
                    writing.WriteLine($"Name: {teacher.Name}");
                    writing.WriteLine($"Class and Section: {teacher.ClassAndSection}");
                    writing.WriteLine();
                    // Add an empty line for separation or formatting
                }

                Console.WriteLine("Teacher data for 7 teachers has been written to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //flush means the buffer data if anything is remaining will be written to the file
                writing.Flush();
                //close and save
                writing.Close();
                writing.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
