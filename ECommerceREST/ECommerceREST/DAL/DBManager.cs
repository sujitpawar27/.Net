
using BOL;
using MySql.Data.MySqlClient;
namespace DAL;


public class DBManager
{
    //public static string conString=@"server=192.168.10.150;port=3306;user=dac27; password=welcome;database:dac27";
    //public static string conString=@"server=192.168.10.150;port=3306;user=dac27; password=welcome;database=dac27"; 
    public static string conString=@"server=192.168.10.150;port=3306;user=dac27; password=welcome;database=dac27"; 

    public static List<Employee> GetAllEmployees(){
        Console.WriteLine("Inside GetAllEmployees Method");
        List<Employee> elist=new List<Employee>();
        MySqlConnection con=new MySqlConnection();
        Console.WriteLine("Before Setting Connetion String ");
         con.ConnectionString=conString;
        string query="Select * from Employee;";
        
         try{
             Console.WriteLine("Inside Try Block ");
                MySqlCommand cmd=new MySqlCommand();
                cmd.Connection=con;
                con.Open();
                Console.WriteLine("Connection Opened");
            cmd.CommandText=query;
          MySqlDataReader reader=cmd.ExecuteReader();
             while(reader.Read()){
                 int id=int.Parse(reader["empno"].ToString());
                 string name=reader["ename"].ToString();
                 int sal=int.Parse(reader["salary"].ToString());


                 Employee e=new Employee{
                     empno=id,
                     ename=name,
                     sal=sal
                 };
                 Console.WriteLine(e);
                 elist.Add(e);
             }

             
         }catch(Exception e){
             Console.WriteLine(e.Message);
         }
         return elist;
    }

    public static Employee GetById(int id) {
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        string query="select * from employee where empno="+id;
        MySqlCommand cmd = new MySqlCommand(query, con);
        con.Open();
        MySqlDataReader dr=cmd.ExecuteReader();
        Employee e=null;
        if (dr.Read())
        {
           e = new Employee
            {
                empno = int.Parse(dr["empno"].ToString()),
                ename = dr["ename"].ToString(),
                sal = int.Parse(dr["salary"].ToString())
            };
           
        }
        return e;
    }
}
