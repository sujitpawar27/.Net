namespace BOL;

public class Employee
{
  public int empno{get;set;}
  public string ename{get;set;}
  public int sal{get;set;}

  public Employee(){}

  public Employee(int id, string name,int sal){
    this.empno=id;
    this.ename=name;
    this.sal=sal;
  }

  public override string ToString(){
      return base.ToString()+" Empno: "+this.empno+" Ename: "+this.ename+" Salary: "+this.sal;
  }
}
