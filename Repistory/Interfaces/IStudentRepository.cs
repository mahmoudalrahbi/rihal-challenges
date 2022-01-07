using School.Models;


namespace School.Repistory.Interfaces
{
    public interface IStudentRepository
    {
        Student getStudent(int id);
        List<Student> getAllStudents();
        void addStudent(Student student);
        void editStudent(Student student);
        void deleteStudent(int id);

        bool StudentExists(int id);
        Task<List<ChartModel>> getStudentsBerClassAsync();

        Task<List<ChartModel>> getStudentsBerCountryAsync();
    }
}