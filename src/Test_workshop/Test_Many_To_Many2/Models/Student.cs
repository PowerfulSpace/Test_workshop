namespace Test_Many_To_Many2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
