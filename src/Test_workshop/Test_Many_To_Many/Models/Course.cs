namespace Test_Many_To_Many.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
