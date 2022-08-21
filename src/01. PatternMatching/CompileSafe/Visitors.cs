using System.Drawing;

namespace PatternMatching.CompileSafe;

public interface IFigureVisitor<T>
{
    T Visit(Circle circle);
    T Visit(Square square);
    T Visit(Rectangle rectangle);
}

public sealed class GetImageVisitor : IFigureVisitor<Bitmap>
{
    private readonly IImagesRepository _imagesRepository;

    public GetImageVisitor(IImagesRepository imagesRepository) => _imagesRepository = imagesRepository;

    public Bitmap Visit(Circle circle) => _imagesRepository.GetCircle(circle.Radius);
    public Bitmap Visit(Square square) => _imagesRepository.GetRectangle(square.Side, square.Side);
    public Bitmap Visit(Rectangle rectangle) => _imagesRepository.GetRectangle(rectangle.Height, rectangle.Width);
}

public sealed class ConvertToCircleVisitor : IFigureVisitor<Circle?>
{
    public Circle? Visit(Circle circle) => circle;
    public Circle? Visit(Square square) => new(square.Side / 2);
    public Circle? Visit(Rectangle rectangle) => null;
}