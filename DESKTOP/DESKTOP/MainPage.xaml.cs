using DESKTOP.Resources.Pages;

namespace DESKTOP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            if ((EntLog.Text == "123") && (EntPass.Text == "1234"))
            {
                await Navigation.PushModalAsync(new MainWindow());
            }
        }
    }
}
