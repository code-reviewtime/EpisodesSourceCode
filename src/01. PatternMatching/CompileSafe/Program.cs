using Microsoft.Extensions.DependencyInjection;
using PatternMatching;
using PatternMatching.CompileSafe;

var services = new ServiceCollection()
    .AddScoped<IImagesRepository>()
    .AddScoped<IPresenter>()
    .AddScoped<IPresentUseCase, PresentUseCase>();

var provider = services.BuildServiceProvider();

IFigure[] figures =
{
    new Circle(10),
    new Square(6),
    new Rectangle(5, 2)
};

var presentUseCase = provider.GetRequiredService<IPresentUseCase>();
presentUseCase.Show(figures);

var convertToCircleUseCase = provider.GetRequiredService<IConvertToCircleUseCase>();
convertToCircleUseCase.Convert(figures);
