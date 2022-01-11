using School.Models;
using School.Repistory.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _context.Students
                .Include(s => s.Classes)
                .Include(s => s.Countries).ToList();
        }

        public Student getStudent(int id)
        {
            return _context.Students
                .Include(s => s.Classes)
                .Include(s => s.Countries)
                .FirstOrDefault(m => m.id == id);
        }

        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.id == id);
        }


        public async Task<List<ChartModel>> getstudentsPerClassAsync()
        {
            var students = await _context.Students
                    .Include(s => s.Classes)
                    .GroupBy(s => s.Classes.class_name)
                    .Select(s => new ChartModel(s.Key.ToString(), s.Count()))
                    .ToListAsync();



            return students;
        }

        public async Task<List<ChartModel>> getStudentsPerCountryAsync()
        {
            var students = await _context.Students
                    .Include(s => s.Countries)
                    .GroupBy(s => s.Countries.name)
                    .Select(s => new ChartModel(s.Key.ToString(), s.Count()))
                    .ToListAsync();



            return students;
        }


        public int getAverageAge()
        {
           List<int> ages =  _context.Students.Select(x => getAge(x.date_of_birth)).ToList();


           return (int)ages.Average();
        }


        public static int getAge(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.AddYears(-dob.Year).Year;
            return age;
        }
    }
}