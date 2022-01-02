using School.Models;
using School.Services.Interfaces;
using School.Repistory.Interfaces;

namespace School.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void addStudent(Student student)
        {
           _studentRepository.addStudent(student);
        }

        public void deleteStudent(int id)
        {
            _studentRepository.deleteStudent(id);
        }

        public void editStudent(Student student)
        {
            _studentRepository.editStudent(student);
        }

        public List<Student> getAllStudents()
        {
            return _studentRepository.getAllStudents();
        }

        public Student getStudent(int id)
        {
           return _studentRepository.getStudent(id);
        }

        public bool StudentExists(int id)
        {
            return _studentRepository.StudentExists(id);
        }
    }
}