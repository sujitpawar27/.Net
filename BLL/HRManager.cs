namespace BLL;
using BOL;
using DAL.Connected;
public class HRManager
{
    public List<Department> GetAllDepartments(){
        List<Department> allDepartments = new List<Department>();
        allDepartments=DBManager.GetAllDepartments();
        return allDepartments;
    }

}