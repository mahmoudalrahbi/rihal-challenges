namespace School.Models
{
    public class ChartModel
    {
        public ChartModel(string _category_name, int _count)
        {
            category_name = _category_name;
            count = _count;
        }
        public int count;
        public string category_name;
    }
}