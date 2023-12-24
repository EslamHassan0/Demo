namespace Demo.Models
{
    public class StudentList
    {
        List<Student> students = new();
        public StudentList()
        {
                students.Add(
                    new Student() { StudentId = 1 , StudentName ="eslam" , Address= "شارع 19" , Img = "eslam.jpg"});
            students.Add(
                  new Student() { StudentId = 2, StudentName = "ahmed", Address = "شارع 18", Img = "eslam.jpg" });
            students.Add(
                  new Student() { StudentId = 3, StudentName = "ali", Address = "شارع 20", Img = "eslam.jpg" });
        }

        public List<Student> GetStudents()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(a=>a.StudentId == id);
        }
    }
}
