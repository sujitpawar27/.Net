namespace drawing;

//abstract class is created contains only generalisation
public abstract class Shape{

    public const double PI=3.14;
    public string color;
    public int width;

    public Shape(){
        this.color="black";
        this.width=3;
    }
    public Shape(String c,int w){
        this.color=c;
        this.width=w;
    }

    public abstract void draw();

//implement and o
    public virtual void display(){
        Console.WriteLine("width="+width+ "color="+color);
    }
}