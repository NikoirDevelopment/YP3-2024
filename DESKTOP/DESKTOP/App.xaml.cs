using DESKTOP.Resources.Pages;
using Microsoft.Maui.Controls;

namespace DESKTOP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="activationState"></param>
        /// <returns></returns>
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var newWindow = new Window(new AppShell());

            newWindow.HandlerChanged += (s, e) =>
            {
                if (newWindow.Handler?.PlatformView != null)
                {
                    switch(true)
                    {
                        var width = 550;
                        var height = 550;

                        newWindow.Width = width;
                        newWindow.Height = height;

                        CenterWindow(newWindow, width, height);

                        var width = 1280;
                        var height = 720;

                        newWindow.Width = width;
                        newWindow.Height = height;

                        CenterWindow(newWindow, width, height);

                    }
                    
                        
                    

                }
            };

            return newWindow;
        }

        private void CenterWindow(Window newWindow, double width, double height)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var screenWidth = displayInfo.Width / displayInfo.Density;
            var screenHeight = displayInfo.Height / displayInfo.Density;

            var x = (screenWidth - width) / 2;
            var y = (screenHeight - height) / 2;

            newWindow.X = x;
            newWindow.Y = y;
        }
    }
}
