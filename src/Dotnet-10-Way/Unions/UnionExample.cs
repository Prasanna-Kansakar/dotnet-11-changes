namespace Dotnet_10_Way.Unions;

internal class SimpleUnionExample
{
    public static string Describe(object shape) => shape switch
    {
        Circle circle => $"Circle with radius {circle.Radius} and area {Math.PI * circle.Radius * circle.Radius}",
        Rectangle rectangle => $"Rectangle {rectangle.Width} x {rectangle.Height} with area {rectangle.Width * rectangle.Height}",
        _ => "No shape"
    };

    public sealed record class Circle(double Radius) : IShape;

    public sealed record class Rectangle(double Width, double Height) : IShape;

    public interface IShape;
}
