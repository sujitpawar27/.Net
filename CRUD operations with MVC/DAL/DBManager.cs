namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public class DBManager
{
    public static string conString = @"server=192.168.10.150;port=3306;user=dac54;password=welcome;database=dac54";

    public static List<Department> getAllDepartment()
    {
        //created Department List
        List<Department> dlist = new List<Department>();
        //create connection obj
        MySqlConnection con = new MySqlConnection();
        //set connection string to connection obj
        con.ConnectionString = conString;
        //create command obj
        MySqlCommand cmd = new MySqlCommand();
        //associate existing connection to command obj
        cmd.Connection = con;
        String Query = "Select * From Department";
        //set query to command obj
        cmd.CommandText = Query;

        try
        {
            //open connection 
            con.Open();
            //execute command obj and access data reader as output from execution 
            MySqlDataReader reader = cmd.ExecuteReader();
            //iterate data reader
            while (reader.Read())
            {
                //extract each record from data reader 
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string location = reader["location"].ToString();
                //create department obj
                Department dept = new Department
                {
                    Id = id,
                    Name = name,
                    Location = location

                };
                //add dept obj to dlist
                dlist.Add(dept);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //close connection 
            con.Close();
        }
        return dlist;
    }

    public static Department GetDepartmentById(int id)
    {
        //declaring department reference here because if we declare it in try block then cant return/use it from outside try block
        Department d = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        String Query = "Select * From Department where id=" + id;
        cmd.CommandText = Query;

        try
        {
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                int id1 = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string location = reader["location"].ToString();
                d = new Department
                {
                    Id = id1,
                    Name = name,
                    Location = location
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return d;
    }
    public static bool Insert(Department d)
    {
        //Console.WriteLine("In insert ");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        String Query = "insert into Department values(" + d.Id + ",'" + d.Name + "','" + d.Location + "')";
        try
        {
            //Console.WriteLine("In Try ");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(Query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            status=true;
        }
        catch (Exception e)
        {
            //Console.WriteLine("In exception ");
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        Console.WriteLine(status);
        return status;
    }

     public static bool Update(Department d)
    {
        //Console.WriteLine("In insert ");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        String Query = "update Department set name = '"+d.Name+"', location ='"+d.Location+"' where id="+d.Id;
        try
        {
            //Console.WriteLine("In Try ");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(Query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            status=true;
        }
        catch (Exception e)
        {
            //Console.WriteLine("In exception ");
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

     public static bool Delete(int id)
    {
        //Console.WriteLine("In insert ");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        String Query = "delete from Department where id = "+id;
        try
        {
            //Console.WriteLine("In Try ");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(Query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            status=true;
        }
        catch (Exception e)
        {
            //Console.WriteLine("In exception ");
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

}