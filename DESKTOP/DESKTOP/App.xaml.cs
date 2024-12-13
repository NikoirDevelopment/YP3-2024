using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Globalization;

namespace DESKTOP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        /// <summary>
        /// Точка входа программы
        /// </summary>
        /// <param name="activationState"></param>
        /// <returns></returns>
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell())
            {
                Title = "С.У.Д.  ",
                Height = 720,
                MinimumHeight = 720,
                Width = 1300,
                MinimumWidth = 1300
            };

            CenterWindow(window);

            return window;
        }

        /// <summary>
        /// Центрирование окна
        /// </summary>
        /// <param name="window"></param>
        private void CenterWindow(Window window)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var screenWidth = displayInfo.Width / displayInfo.Density;
            var screenHeight = displayInfo.Height / displayInfo.Density;

            var x = (screenWidth - window.Width) / 2;
            var y = (screenHeight - window.Height) / 2;

            window.X = x;
            window.Y = y;
        }
    }
}
