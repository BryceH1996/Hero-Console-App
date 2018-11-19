
namespace HeroLibrary
{
    public class Student : Hero
    {
        public string Courses { get; set; }
        public string Training { get; set; }

        public Student NewStudent(Hero hero, string Course, string Train)
        {
            Student student = new Student
            {
                Courses = Course,
                Training = Train
            }; 

            return student;
        }
    }
}
