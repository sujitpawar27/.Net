using drawing;
// See https://aka.ms/new-console-template for more information


int w=8;
string c="red";

Point start_point=new Point(12,32);
Point end_point=new Point(45,65);

Line l=new Line(start_point,end_point,c,w);
l.draw();
l.display();

