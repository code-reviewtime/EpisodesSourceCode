namespace PatternMatching.CompileSafe;

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
        var getImageVisitor = new GetImageVisitor(_imagesRepository);
        var images = figures.Select(x => x.Accept(getImageVisitor));

        _presenter.Show(images);
    }
}
