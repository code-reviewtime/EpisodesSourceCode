namespace PatternMatching.CompileSafe;

public interface IConvertToCircleUseCase
{
    IEnumerable<Circle?> Convert(IEnumerable<IFigure> figures);
}

public sealed class ConvertToCircleUseCase : IConvertToCircleUseCase
{
    public IEnumerable<Circle?> Convert(IEnumerable<IFigure> figures)
    {
        var convertToCircleVisitor = new ConvertToCircleVisitor();
        return figures.Select(x => x.Accept(convertToCircleVisitor));
    }
}