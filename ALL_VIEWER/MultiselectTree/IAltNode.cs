using System.Drawing;

namespace NsMultiselectTreeView
{
    public interface IAltNode
    {
        string AltText { get; }

        Color AltForeColor { get; }
    }
}
