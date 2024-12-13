using DESKTOP.Program;

namespace DESKTOP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.IconImageSource = ImageSource.FromResource("DESKTOP.Resources.Images.Logo.png");
        }
    }
}
