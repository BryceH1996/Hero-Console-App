using HeroLibrary;
using System;
using System.IO;

namespace SuperHeroAcademy
{
    class Program
    {
        public const string LEVEL1 = (@"C:\Development\C#\SuperHeroAcademy\SuperHeroAcademy\Level1.txt");
        public const string LEVEL2 = (@"C:\Development\C#\SuperHeroAcademy\SuperHeroAcademy\Level2.txt");
        public const string LEVEL3 = (@"C:\Development\C#\SuperHeroAcademy\SuperHeroAcademy\Level3.txt");
        public const string LEVEL4 = (@"C:\Development\C#\SuperHeroAcademy\SuperHeroAcademy\Level4.txt");
        public const string LEVEL5 = (@"C:\Development\C#\SuperHeroAcademy\SuperHeroAcademy\Level5.txt");

        static void Main(string[] args)
        {
            int level = Selection();

            while (level == 1)
            {
                Level1Method();
            }

            while (level == 2)
            {
                Level2Method();
            }

            while (level == 3)
            {
                Level3Method();
            }

            while(level == 4)
            {
                Level4();
            }
            
        }

        static int Selection()
        {
            Console.WriteLine("Please Enter Level: ");
            int level = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            return level;
        }

        static void Level1Method()
        {
            string[] lines = File.ReadAllLines(LEVEL1);

            //View student

            Console.WriteLine("Please enter Student ID: ");
            string ID = Console.ReadLine();
            Console.Clear();
            foreach (string value in lines)
            {
                if (value.StartsWith(ID))
                {
                    string[] students = value.Split(',');
                    FindStudent(ID, students);
                    break;
                }
                
            }
            Console.ReadLine();
        }

        static void Level2Method()
        {
            string[] lines = File.ReadAllLines(LEVEL2);

            //View student

            Console.WriteLine("Please enter your Student ID: ");
            string ID = Console.ReadLine();
            Console.Clear();
            foreach (string value in lines)
            {
                if (value.StartsWith(ID))
                {
                    string[] students = value.Split(',');
                    FindStudent(ID, students);
                    break;
                }

            }
            Console.ReadLine();
        }

        static void Level3Method()
        {
            string[] Level3 = File.ReadAllLines(LEVEL3);

            Console.WriteLine("Please enter your Teacher ID: ");
            string ID = Console.ReadLine();
            Console.Clear();
            foreach (string TeacherData in Level3)
            {
                if (TeacherData.StartsWith(ID))
                {
                    string[] Teachers = TeacherData.Split(',');
                    FindTeacher(ID, Teachers);

                    Console.WriteLine("\n\nOptions:\n1. View All Students\n2. Add a Student\n3. Edit a Student\n4. Delete a Student\n\nPlease select an option: ");
                    int option = Convert.ToInt16(Console.ReadLine());

                    if (option.Equals(1))
                    {
                        Console.WriteLine("Please select the students level category: ");
                        int studentlevel = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        if (studentlevel == 1 || studentlevel == 2)
                        {
                            if (studentlevel == 1)
                            {
                                Level1Method();
                            } //if
                            else
                            {
                                Level2Method();
                            }//else
                        }//if
                        else
                        {
                            Console.WriteLine("Not a valid student level");
                            Console.ReadLine();
                            break;
                        }//else
                    }

                    if (option.Equals(2))
                    {
                        Student student = new Student();

                        //Add Student
                        Console.WriteLine("Please enter user ID: ");
                        student.ID = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter first name: ");
                        student.FirstName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter last name: ");
                        student.LastName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter super power: ");
                        student.Superpower = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter level: ");
                        student.Level = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter course: ");
                        student.Courses = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter training: ");
                        student.Training = Console.ReadLine().ToUpper();
                        Console.Clear();

                        StreamWriter Level1Writer = new StreamWriter(LEVEL1, append: true);
                        StreamWriter Level2Writer = new StreamWriter(LEVEL2, append: true);

                        if (student.Level.Equals(1))
                        {
                            Level1Writer.WriteLine($"{student.ID},{student.FirstName},{student.LastName},{student.Superpower},{student.Level},{student.Courses},{student.Training}");
                            Level1Writer.Close();
                            break;
                        }
                        if (student.Level.Equals(2))
                        {
                            Level2Writer.WriteLine($"{student.ID},{student.FirstName},{student.LastName},{student.Superpower},{student.Level},{student.Courses},{student.Training}");
                            Level2Writer.Close();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid level for student");
                            Console.ReadLine();
                            break;
                        }

                    }

                    if(option.Equals(3))
                    {
                        Console.WriteLine("Please select the students level category: ");
                        int studentlevel = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        if (studentlevel == 1 || studentlevel == 2)
                        {
                            if (studentlevel == 1)
                            {
                                string[] lines = File.ReadAllLines(LEVEL1);

                                //Edit student

                                Console.WriteLine("Please enter Student ID: ");
                                string studentID = Console.ReadLine();
                                Console.Clear();
                                foreach (string value in lines)
                                {
                                    if (value.StartsWith(studentID))
                                    {
                                        string[] students = value.Split(',');
                                        string existing = $"{students[0]},{students[1]},{students[2]},{students[3]},{students[4]},{students[5]},{students[6]}";

                                        Console.WriteLine("Please enter super power: ");
                                        students[3] = Console.ReadLine().ToUpper();
                                        Console.Clear();

                                        Console.WriteLine("Please enter level: ");
                                        students[4] = Console.ReadLine();
                                        Console.Clear();

                                        Console.WriteLine("Please enter course: ");
                                        students[5] = Console.ReadLine().ToUpper();
                                        Console.Clear();

                                        Console.WriteLine("Please enter training: ");
                                        students[6] = Console.ReadLine().ToUpper();
                                        Console.Clear();

                                        
                                        existing = existing.Replace(existing ,($"{students[0]},{students[1]},{students[2]},{students[3]},{students[4]},{students[5]},{students[6]}"));
                                        File.WriteAllText(LEVEL1, existing);
                                        break;
                                    }

                                }
                                Console.ReadLine();
                            } //if
                            else
                            {
                                Level2Method();
                            }//else
                        }//if
                        else
                        {
                            Console.WriteLine("Not a valid student level");
                            Console.ReadLine();
                            break;
                        }//else
                    }

                    else
                    {
                        Console.WriteLine("No valid option selected");
                        Console.ReadLine();
                    }
                    break;
                }
            }
        }

        static void Level4()
        {
            string[] Level1 = File.ReadAllLines(LEVEL1);
            string[] Level2 = File.ReadAllLines(LEVEL2);
            string[] Level3 = File.ReadAllLines(LEVEL3);
            string[] Level4 = File.ReadAllLines(LEVEL4);

            Console.WriteLine("Please enter your Principle ID: ");
            string ID = Console.ReadLine();
            Console.Clear();
            foreach (string PrincipleData in Level4)
            {
                if (PrincipleData.StartsWith(ID))
                {
                    string[] Teachers = PrincipleData.Split(',');
                    FindTeacher(ID, Teachers);

                    Console.WriteLine("\n\nOptions:\n1. View All Students\n2. Add a Student\n5. View All Teachers\n6. Add a Teacher\n\nPlease select an option: ");
                    int option = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();

                    if (option.Equals(1))
                    {
                        Console.WriteLine("Please select the students level category: ");
                        int studentlevel = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        if (studentlevel == 1 || studentlevel == 2)
                        {
                            if (studentlevel == 1)
                            {
                                foreach (string Level1Data in Level1)
                                {
                                    string[] LevelStudents = Level1Data.Split(',');
                                    Console.WriteLine($"Student ID: {LevelStudents[0]}\nStudent Name: {LevelStudents[1]} {LevelStudents[2]}\nStudent Superpower: {LevelStudents[3]}\nStudent Level: {LevelStudents[4]}\nStudent Course: {LevelStudents[5]}\nStudent Training: {LevelStudents[6]}\n");
                                }
                                Console.ReadLine();
                                break;
                            } //if
                            else
                            {
                                foreach (string Level2Data in Level2)
                                {
                                    string[] LevelStudents = Level2Data.Split(',');
                                    Console.WriteLine($"Student ID: {LevelStudents[0]}\nStudent Name: {LevelStudents[1]} {LevelStudents[2]}\nStudent Superpower: {LevelStudents[3]}\nStudent Level: {LevelStudents[4]}\nStudent Course: {LevelStudents[5]}\nStudent Training: {LevelStudents[6]}\n");
                                }
                                Console.ReadLine();
                                break;
                            }//else
                        }//if
                        else
                        {
                            Console.WriteLine("Not a valid student level");
                            Console.ReadLine();
                            break;
                        }//else
                    }

                    if (option.Equals(2))
                    {
                        Student student = new Student();

                        //Add Student
                        Console.WriteLine("Please enter user ID: ");
                        student.ID = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter first name: ");
                        student.FirstName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter last name: ");
                        student.LastName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter super power: ");
                        student.Superpower = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter level: ");
                        student.Level = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter course: ");
                        student.Courses = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter training: ");
                        student.Training = Console.ReadLine().ToUpper();
                        Console.Clear();

                        StreamWriter Level1Writer = new StreamWriter(LEVEL1, append: true);
                        StreamWriter Level2Writer = new StreamWriter(LEVEL2, append: true);

                        if (student.Level.Equals(1))
                        {
                            Level1Writer.WriteLine($"{student.ID},{student.FirstName},{student.LastName},{student.Superpower},{student.Level},{student.Courses},{student.Training}");
                            Level1Writer.Close();
                            break;
                        }
                        if (student.Level.Equals(2))
                        {
                            Level2Writer.WriteLine($"{student.ID},{student.FirstName},{student.LastName},{student.Superpower},{student.Level},{student.Courses},{student.Training}");
                            Level2Writer.Close();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid level for student");
                            Console.ReadLine();
                            break;
                        }

                    }

                    if (option.Equals(5))
                    {
                                foreach (string Level3Data in Level3)
                                {
                                    string[] LevelStudents = Level3Data.Split(',');
                                    Console.WriteLine($"Teacher ID: {LevelStudents[0]}\nTeacher Name: {LevelStudents[1]} {LevelStudents[2]}\nTeacher Superpower: {LevelStudents[3]}\nTeacher Level: {LevelStudents[4]}\nType of Teacher: {LevelStudents[5]}\nTeacher Salary: {LevelStudents[6]}\n");
                                }
                                Console.ReadLine();
                                break;
                    }

                    if (option.Equals(6))
                    {
                        Teacher teacher = new Teacher();

                        //Add Teacher
                        Console.WriteLine("Please enter user ID: ");
                        teacher.ID = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter first name: ");
                        teacher.FirstName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter last name: ");
                        teacher.LastName = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter super power: ");
                        teacher.Superpower = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter level: ");
                        teacher.Level = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter type of teacher: ");
                        teacher.TypeOfTeacher = Console.ReadLine().ToUpper();
                        Console.Clear();

                        Console.WriteLine("Please enter salary: ");
                        teacher.Salary = Convert.ToDouble(Console.ReadLine());
                        Console.Clear();

                        StreamWriter Level3Writer = new StreamWriter(LEVEL3, append: true);

                        if (teacher.Level.Equals(3))
                        {
                            Level3Writer.WriteLine($"{teacher.ID},{teacher.FirstName},{teacher.LastName},{teacher.Superpower},{teacher.Level},{teacher.TypeOfTeacher},{teacher.Salary}");
                            Level3Writer.Close();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid level for teacher");
                            Console.ReadLine();
                            break;
                        }

                    }

                    else
                    {
                        Console.WriteLine("No valid option selected");
                        Console.ReadLine();
                    }
                    break;
                }
            }
        }

        static void FindStudent(string ID, string[] students)
        {
            if (ID.Equals(students[0]))
            {
                Console.WriteLine($"Student ID: {students[0]}\nStudent Name: {students[1]} {students[2]}\nStudent Superpower: {students[3]}\nStudent Level: {students[4]}\nStudent Course: {students[5]}\nStudent Training: {students[6]}");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void FindTeacher(string ID, string[] Teachers)
        {
            if(ID.Equals(Teachers[0]))
            {
                Console.WriteLine($"Welcome {Teachers[1]} {Teachers[2]}");
            }

        }
    }
}
