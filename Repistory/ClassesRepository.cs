
using School.Models;
using School.Repistory.Interfaces;

namespace School.Repistory
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly MvcSchoolContext _context;


         public ClassesRepository(MvcSchoolContext context)
        {
            _context = context;
        }

        public void addClass(Class _class)
        {
           _context.Add(_class);
           _context.SaveChanges();
        }

        public bool classExists(int id)
        {
             return _context.Classes.Any(e => e.id == id);
        }

        public void deleteClass(int id)
        {
            var _class = _context.Classes.Find(id);
            _context.Classes.Remove(_class);
            _context.SaveChanges();
        }

        public void editClass(Class _class)
        {
            _context.Update(_class);
            _context.SaveChanges();
        }

        public List<Class> getAllClasses()
        {
            return  _context.Classes.ToList();
        }

        public Class getClass(int id)
        {
            return  _context.Classes.Find(id);
        }
    }
}