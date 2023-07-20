namespace drawing;

public class Line:Shape{

    public Point startpoint;
    public Point endpoint;

//constructor overloading
//static polymorphism

public Line():base(){
    this.startpoint=new Point(4,5);
    this.endpoint=new Point(10,12);
}

//inheriting from parent class
public Line(Point p1,Point p2,string c,int w):base(c,w){

    this.startpoint=p1;
    this.endpoint=p2;
}
    //runtime polymorphism
    //method overriding

    public override void draw()
  {
    Console.WriteLine("Drawing Line");
    Console.WriteLine(this.color+ " " +this.width+ " "+this.startpoint.x+" "+this.startpoint.y+" "+this.endpoint.x+" "+this.endpoint.y);
  }

  public override void display(){
    //first parent display method will get called
    base.display();
    Console.WriteLine(this.startpoint.x+" "+this.startpoint.y+" "+this.endpoint.x+" "+this.endpoint.y);
  }

}