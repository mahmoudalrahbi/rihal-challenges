using School.Models;

namespace School.Services.Interfaces
{
    public interface IStudentService
    {
        Student getStudent(int id);
        List<Student> getAllStudents();
        void addStudent(Student student);
        void editStudent(Student student);
        void deleteStudent(int id);
        bool StudentExists(int id);
    }
}