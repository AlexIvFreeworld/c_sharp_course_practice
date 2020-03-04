using System;
using static System.Console;
namespace hw_4_1
{
    abstract class Figure
    {
        protected double S;
        protected double P;
        public Figure() { }
        public abstract void Area();
        public abstract void Perimetr();
public double GetS() {
return S;
}
    }
    class Triangle : Figure
    {
        double side_A;
        double side_B;
        double angle_A_B;
        public Triangle(double a, double b, double ang)
        {
            side_A = a;
            side_B = b;
            angle_A_B = ang;
        }
        public override void Area()
        {
            S = (side_A * side_B * Math.Sin(angle_A_B)) / 2;
            WriteLine("This is Triangle.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    double side_C = Math.Sqrt(Math.Pow(side_B,2) + Math.Pow(side_A,2) - side_B*side_A*Math.Cos(angle_A_B));	
	    P = side_A + side_B + side_C;
            WriteLine("This is Triangle.Perimetr() : {0:f0}", P);
        }
    }
    class Square : Figure
    {
        double side_A;
        public Square(double a)
        {
            side_A = a;
        }
        public override void Area()
        {
            S = side_A * side_A;
            WriteLine("This is Square.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    P = 4 * side_A;	
            WriteLine("This is Square.Perimetr() : {0:f0}",P);
        }

    }
    class Rhombus : Figure
    {
        double diag_A;
        double diag_B;
        public Rhombus(double a, double b)
        {
            diag_A = a;
            diag_B = b;
        }
        public override void Area()
        {
            S = (diag_A * diag_B) / 2;
            WriteLine("This is Rhombus.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    double side_A = Math.Sqrt(Math.Pow(diag_A/2,2) + Math.Pow(diag_B/2,2));	
	    P = 4 * side_A;
            WriteLine("This is Rhombus.Perimetr() : {0:f0}",P);
        }
    }
    class Parallelogram : Figure
    {
        double base_A;
        double height_H;
	double angle_A_B;
        public Parallelogram(double a, double h, double ang)
        {
            base_A = a;
            height_H = h;
	    angle_A_B = ang;
        }
        public override void Area()
        {
            S = base_A * height_H;
            WriteLine("This is Parallelogram.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    double base_B = height_H / Math.Sin(angle_A_B);	
	    P = 2 * base_A + 2 * base_B; 
            WriteLine("This is Parallelogram.Perimetr() : {0:f0}",P);
        }
    }
    class Rectangle : Figure
    {
        double side_A;
        double side_B;
        public Rectangle(double a, double b)
        {
            side_A = a;
            side_B = b;
        }
        public override void Area()
        {
            S = side_A * side_B;
            WriteLine("This is Rectangle.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    P = 2 * side_A + 2 * side_B;	
            WriteLine("This is Rectangle.Perimetr() : {0:f0}",P);
        }

    }
    class Trapeze : Figure
    {
        double base_A;
        double base_B;
        double height_H;
        public Trapeze(double a, double b, double h)
        {
            base_A = a;
            base_B = b;
            height_H = h;
        }
        public override void Area()
        {
	    S = (base_A + base_B)/2*height_H;	
            WriteLine("This is Trapeze.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    double p, side_C;
            p = (base_B - base_A)/2;
            side_C = Math.Sqrt(Math.Pow(p,2) + Math.Pow(height_H,2));	    
	    P = base_A + base_B + 2 * side_C;
            WriteLine("This is Trapeze.Perimetr() : {0:f0}",P);
        }

    }
    class Circle : Figure
    {
        double rad_A;
        public Circle(double a)
        {
            rad_A = a;
        }
        public override void Area()
        {
            S =  Math.PI * Math.Pow(rad_A,2);
            WriteLine("This is Circle.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    P = 2 * Math.PI * rad_A;	
            WriteLine("This is Circle.Perimetr() : {0:f0}",P);
        }

    }
    class Ellipse : Figure
    {
        double axis_A;
        double axis_B;
        public Ellipse(double a, double b)
        {
            axis_A = a;
            axis_B = b;
        }
        public override void Area()
        {
            S =  Math.PI * axis_A * axis_B;
            WriteLine("This is Ellipse.Area() : {0:f0}", S);
        }
        public override void Perimetr()
        {
	    P = 4 * ((Math.PI * axis_A * axis_B + Math.Pow(axis_A - axis_B,2))/(axis_A + axis_B)); 	
            WriteLine("This is Ellipse.Perimetr() : {0:f0}",P);
        }

    }
    class Composite : Figure
    {
	public Figure[] pTarr;    
        public Composite(params Figure[] arr)
        {
            int i = 0;
	    pTarr = new Figure[arr.Length];
            foreach(Figure F in arr)
            {
                pTarr[i] = F;
                i++;
            }
        }
        public override void Area()
        {
	    S = 0.0;
            foreach(Figure F in pTarr){
            F.Area();
                S += F.GetS();
	    }	    
            WriteLine("This is Composite.Area() : {0:f0}", S);
        }
        public override void Perimetr() { }
    }
    class Program
    {
        static public void Main()
        {
            Figure F_1 = new Triangle(10.0, 10.0, 1.5708);
            Figure F_2 = new Square(10.0);
            Figure F_3 = new Rhombus(10.0, 10.0);
            Figure F_4 = new Trapeze(10.0, 30.0, 10.0);
            Figure F_5 = new Rectangle(10.0, 20.0);
            Figure F_6 = new Parallelogram(30.0, 10.0, 0.8);
            Figure F_7 = new Circle(10.0);
            Figure F_8 = new Ellipse(10.0, 30.0);
           // F_1.Area();
           // F_1.Perimetr();
            Figure[] ArrF = new Figure[] { F_1, F_2, F_3, F_4, F_5, F_6, F_7, F_8 };
            foreach (Figure F in ArrF)
            {
                F.Area();
                F.Perimetr();
            }
            Composite C_1 = new Composite(F_1, F_2, F_3, F_4);
            // C_1.pTarr[0].Area();
            C_1.Area();
        }
    }
}
