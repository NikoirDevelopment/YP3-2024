using DESKTOP.Program;
using DESKTOP.Resources.Data;
using DESKTOP;

namespace DESKTOP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            OdbControlHelper.context = new OdbYp32024Context();
        }

        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            if ((EntLog.Text == "admin") && (EntPass.Text == "root"))
            {
                await DisplayAlert("Системное уведомление | Авторизация", "Добро пожаловать в систему!", "OK");
                    await Navigation.PushModalAsync(new MainWindowApp());
            }
            else
            {
                await DisplayAlert("Системное уведомление | Авторизация", "Не верный логин или пароль!", "OK");
            }
        }
    }
}
