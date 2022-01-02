using School.Models;
using School.Repistory.Interfaces;


namespace School.Repistory
{
    public class StudentRepository : IStudentRepository
    {

        private readonly MvcSchoolContext _context;


        public StudentRepository(MvcSchoolContext context)
        {
            _context = context;
        }



        public void addStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }

        public void deleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void editStudent(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
        }

        public List<Student> getAllStudents()
        {
            return  _context.Students.ToList();
        }

        public Student getStudent(int id)
        {
            return  _context.Students.Find(id);
        }

        public bool StudentExists(int id)
        {
             return _context.Students.Any(e => e.id == id);
        }
    }
}