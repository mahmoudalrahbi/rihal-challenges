using School.Models;
using School.Services.Interfaces;
using School.Repistory.Interfaces;

namespace School.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public void addClass(Class _class)
        {
            _classRepository.addClass( _class);
        }

        public bool classExists(int id)
        {
            return _classRepository.classExists(id);
        }

        public void deleteClass(int id)
        {
            _classRepository.deleteClass(id);
        }

        public void editClass(Class _class)
        {
            _classRepository.editClass(_class);
        }

        public List<Class> getAllClasses()
        {
            return _classRepository.getAllClasses();
        }

        public Class getClass(int id)
        {
           return _classRepository.getClass(id);
        }
    }
}