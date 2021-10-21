using System.Drawing;

namespace OymakGroupCase
{
    public class Land
    {
        Size Size_;

        public Land(Size Size)
        {
            Size_ = Size;
        }

        public Size Size
        {
            get
            {
                return Size_;
            }
        }
    }
}
