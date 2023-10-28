using System;



public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public GraphicPrimitive(int x, int y)
    {
        X = x;
        Y = y;
    }

    public abstract void Draw();

    public virtual void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}


public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
    }

    public void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}


public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height) : base(x, y)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}


public class Triangle : GraphicPrimitive
{
    public Triangle(int x, int y) : base(x, y) { }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a triangle at ({X}, {Y})");
    }
}


public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> members;

    public Group(int x, int y) : base(x, y)
    {
        members = new List<GraphicPrimitive>();
    }

    public void AddMember(GraphicPrimitive member)
    {
        members.Add(member);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a group at ({X}, {Y})");

        foreach (var member in members)
        {
            member.Draw();
        }
    }

    public override void Move(int dx, int dy)
    {
        base.Move(dx, dy);

        foreach (var member in members)
        {
            member.Move(dx, dy);
        }
    }
}


public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives;

    public GraphicsEditor()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void MoveAll(int dx, int dy)
    {
        foreach (var primitive in primitives)
        {
            primitive.Move(dx, dy);
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            if (primitive is Circle circle)
            {
                circle.Scale(factor);
            }
            else if (primitive is Rectangle rectangle)
            {
                rectangle.Scale(factor);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(10, 10, 5);
        Rectangle rectangle = new Rectangle(20, 20, 8, 8);
        Triangle triangle = new Triangle(15, 15);

        Group group = new Group(0, 0);
        group.AddMember(circle);
        group.AddMember(rectangle);
        group.AddMember(triangle);

        GraphicsEditor editor = new GraphicsEditor();
        editor.AddPrimitive(group);

        Console.WriteLine("Original:");
        editor.DrawAll();
        editor.MoveAll(5, 5);
        editor.ScaleAll(1.5f);

        Console.WriteLine("\nAfter moving and scaling:");
        editor.DrawAll();
    }
}
