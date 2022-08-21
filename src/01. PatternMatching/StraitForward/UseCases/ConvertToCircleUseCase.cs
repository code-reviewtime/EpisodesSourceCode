namespace PatternMatching.StraitForward;

public interface IConvertToCircleUseCase
{
    IEnumerable<Circle?> Convert(IEnumerable<IFigure> figures);
}

public sealed class ConvertToCircleUseCase : IConvertToCircleUseCase
{
    public IEnumerable<Circle?> Convert(IEnumerable<IFigure> figures)
    {
        var circles = figures.Select(x => x switch
        {
            Circle circle => circle,
            Square square => new Circle(square.Side / 2),
            _ => null
        });

        return circles;
    }
}