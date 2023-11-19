namespace Test_Many_To_Many2.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Mark { get; set; }       // оценка студента
        public DateTime EnrollmentDate { get; set; } // дата зачисления
    }
}
