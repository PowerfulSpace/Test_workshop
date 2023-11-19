namespace Test_Many_To_Many2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
