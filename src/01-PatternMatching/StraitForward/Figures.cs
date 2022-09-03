namespace PatternMatching.StraitForward;

public interface IFigure { }

public sealed record Circle(double Radius) : IFigure;

public sealed record Square(double Side) : IFigure;

public sealed record Rectangle(double Height, double Width) : IFigure;
