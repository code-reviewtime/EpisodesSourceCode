namespace PatternMatching.CompileSafe;

public interface IFigure
{
    public T Accept<T>(IFigureVisitor<T> visitor);
}

public sealed record Circle(double Radius) : IFigure
{
    public T Accept<T>(IFigureVisitor<T> visitor) => visitor.Visit(this);
}

public sealed record Square(double Side) : IFigure
{
    public T Accept<T>(IFigureVisitor<T> visitor) => visitor.Visit(this);
}

public sealed record Rectangle(double Height, double Width) : IFigure
{
    public T Accept<T>(IFigureVisitor<T> visitor) => visitor.Visit(this);
}
