using System.Drawing;

namespace PatternMatching;

public interface IPresenter
{
    void Show(IEnumerable<Bitmap> images);
}
