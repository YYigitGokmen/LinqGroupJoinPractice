using LinqGroupJoinPractice;

public class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        students.Add(new Student { studentId = 1, studentName = "Ali", classId = 1 });
        students.Add(new Student { studentId = 2, studentName = "Ayşe", classId = 2 });
        students.Add(new Student { studentId = 3, studentName = "Mehmet", classId = 1 });
        students.Add(new Student { studentId = 4, studentName = "Fatma", classId = 3 });
        students.Add(new Student { studentId = 5, studentName = "Ahmet", classId = 2 });



        List<Class> classes = new List<Class>();

        classes.Add(new Class { classId = 1, className = "Matematik" });
        classes.Add(new Class { classId = 2, className = "Türkçe" });
        classes.Add(new Class { classId = 3, className = "Kimya" });


        var groupJoin = from c in classes
                        join s in students on c.classId equals s.classId into studentGroup
                        select new
                        {
                            Classname = c.className,
                            Students = studentGroup,
                        };


        foreach (var group in groupJoin)
        {
            Console.WriteLine($"Class: {group.Classname}");
            foreach (var student in group.Students)
            {
                Console.WriteLine($" - Student: {student.studentName}");
            }


        }
    }
}