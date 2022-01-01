using School.Models;

namespace School.Services.Interfaces
{
    public interface IClassService
    {
        Class getClass(int id);
        List<Class> getAllClasses();
        void addClass(Class _class);
        void editClass(Class _class);
        void deleteClass(int id);
        bool classExists(int id);
    }
}