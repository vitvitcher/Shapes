using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Square : Shape
    {
        readonly private int Side;
        public Square(int side) => Side = side;
        public override double GetArea() => Side * Side;
        public override double GetPerimeter() => Side * 4;
    }
    class Triangle : Shape
    {
        readonly private int Side;
        public Triangle(int side) => Side = side;
        public override double GetArea() => Math.Pow(3,1/3)/4*Side*Side;
        public override double GetPerimeter() => Side * 3;
    }
    class Diamond : Shape
    {
        readonly private int H;
        readonly private int Side;
        public Diamond(int side, int h) { Side = side; H = h; }
        public override double GetArea() => Side*H;
        public override double GetPerimeter() => 4 * Side;
    }
    class Rectangle : Shape
    {
        readonly private int Side1;
        readonly private int Side2;

        public Rectangle(int side1, int side2) { Side1 = side1; Side2 = side2; }
        public override double GetArea() => Side1*Side2;
        public override double GetPerimeter() => 2*Side1+2*Side2;
    }
    class Parallelogram : Shape
    {
        readonly private int SideA;
        readonly private int SideB;
        readonly private int H;

        public Parallelogram(int sidea, int sideb, int h) { SideA = sidea; SideB = sideb; H = h; }
        public override double GetArea() => SideA * H;
        public override double GetPerimeter() => 2 * SideA + 2 * SideB;
    }
    class Trapezoid : Shape
    {
        readonly private int SideA;
        readonly private int SideB;
        readonly private int SideC;
        readonly private int SideD;
        readonly double pivper; 
        public Trapezoid(int sidea, int sideb,int sidec, int sided) { SideA = sidea; SideB = sideb; SideC = sidec; SideD= sided;pivper= (SideA + SideB + SideC + SideD) / 2; }
        public override double GetArea()=> (SideA + SideB) / Math.Abs(SideA - SideB) * Math.Sqrt((pivper - SideA) * (pivper - SideB) * (pivper - SideA - SideC) * (pivper - SideA - SideD));
        public override double GetPerimeter() => SideA + SideB + SideC + SideD;
    }
    class Circle : Shape
    {
        readonly private int R;

        public Circle(int r) { R = r; }
        public override double GetArea() => Math.PI * R * R;
        public override double GetPerimeter() => 2 * Math.PI * R;
    }
    class Elipse : Shape
    {
        readonly private int SideA;
        readonly private int SideB;

        public Elipse(int sidea, int sideb, int r) { SideA = sidea; SideB = sideb; }
        public override double GetArea() => Math.PI*SideA*SideB;
        public override double GetPerimeter() => 4 * (Math.PI * SideA * SideB + (SideA - SideB)) / (SideA + SideB);
    }
    class ComplexShape : Shape
    {
        readonly Shape[] shapes;
        ComplexShape(params Shape[]list)
        {
            shapes = list;
        }
        public override double GetArea()
        {
            double area=0;
            foreach(var shape in shapes)
            {
                area += shape.GetArea();
            }
            return area;
        }
        public override double GetPerimeter()
        {
            double perim = 0;
            foreach (var shape in shapes)
            {
                perim += shape.GetPerimeter();
            }
            return perim;
        }
    }
}
