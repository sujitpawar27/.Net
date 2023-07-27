namespace BLL;
using BOL;
using DAL;

public class Service
{
    public static List<Department> getAllDept()
    {
        return DBManager.getAllDepartment();
    }

    public static Department GetDepartmentById(int id)
    {
        return DBManager.GetDepartmentById(id);
    }

    public static bool Insert(Department d)
    {
        return DBManager.Insert(d);
    }
}
