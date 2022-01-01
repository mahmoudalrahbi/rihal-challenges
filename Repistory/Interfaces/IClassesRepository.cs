using School.Models;

namespace School.Repistory.Interfaces
{
    public interface  IClassesRepository
    {

        Class getClass(int id);
        List<Class> getAllClasses();
        void addClass(Class _class);
        void editClass(Class _class);
        void deleteClass(int id);

        bool classExists(int id);
    }
}