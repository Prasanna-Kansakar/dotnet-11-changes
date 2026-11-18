namespace Dotnet_11_Changes.Unions;

internal class SimpleUnionExample
{
    public static string Describe(Shape shape) => shape switch
    {
        Circle circle => $"Circle with radius {circle.Radius} and area {shape.Area}",
        Rectangle rectangle => $"Rectangle {rectangle.Width} x {rectangle.Height} with area {shape.Area}",
        null => "No shape"
    };

    public static void Run()
    {
        Shape circle = new Circle(3);
        Shape rectangle = new Rectangle(4, 5);

        Console.WriteLine(Describe(circle));
        Console.WriteLine(Describe(rectangle));
    }

    public sealed record class Circle(double Radius);

    public sealed record class Rectangle(double Width, double Height);

    public union Shape(Circle, Rectangle?)
    {
        public readonly double Area => this switch
        {
            Circle circle => Math.PI * circle.Radius * circle.Radius,
            Rectangle rectangle => rectangle.Width * rectangle.Height,
            null => 0
        };
    }
}
