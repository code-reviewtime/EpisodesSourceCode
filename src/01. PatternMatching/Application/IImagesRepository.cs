using System.Drawing;

namespace PatternMatching;
public interface IImagesRepository
{
    Bitmap GetCircle(double radius);
    Bitmap GetRectangle(double height, double width);
}