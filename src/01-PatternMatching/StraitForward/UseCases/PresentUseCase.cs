namespace PatternMatching.StraitForward;

public interface IPresentUseCase
{
    void Show(IEnumerable<IFigure> figures);
}

public sealed class PresentUseCase : IPresentUseCase
{
    private readonly IImagesRepository _imagesRepository;
    private readonly IPresenter _presenter;

    public PresentUseCase(IImagesRepository imagesRepository, IPresenter presenter)
    {
        _imagesRepository = imagesRepository;
        _presenter = presenter;
    }

    public void Show(IEnumerable<IFigure> figures)
    {
        var images = figures.Select(x => x switch
        {
            Circle circle => _imagesRepository.GetCircle(circle.Radius),
            Square square => _imagesRepository.GetRectangle(square.Side, square.Side),
            Rectangle rectangle => _imagesRepository.GetRectangle(rectangle.Height, rectangle.Width),
            _ => throw new NotImplementedException()
        });

        _presenter.Show(images);
    }
}
