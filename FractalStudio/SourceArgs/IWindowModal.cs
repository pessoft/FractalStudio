using System.Windows.Forms;

namespace FractalStudio
{
    public interface IWindowModal
    {
        DialogResult ShowDialog(IGroupCreate owner);
    }
}
