using DESKTOP.Resources.Data;
using System.Globalization;
using System.Timers;

namespace DESKTOP.Program.userList.win;

public partial class AddUser : ContentPage
{
    private int organization = 0;

    public AddUser()
    {
        InitializeComponent();
        StartSystem_Timer();
        StartSystem();
    }

    private void StartSystem()
    {
        LoadingWindow.IsVisible = true;
        BtnCancelLoading.IsVisible = false;

        AddUserWindow.IsVisible = false;
    }

    /// <summary>
    /// Таймер загрузки
    /// </summary>
    private System.Timers.Timer _timer;
    private int _seconds;

    private void StartSystem_Timer()
    {
        _seconds = 0;
        _timer = new System.Timers.Timer(1000); // Устанавливаем интервал в 1 секунду
        _timer.Elapsed += OnTimeEvent; // Использование таймера

        _timer.Start();
    }

    /// <summary>
    /// Счётчик загрузки и ожидания
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnTimeEvent(object sender, ElapsedEventArgs e)
    {
        _seconds++;

        ((BindableObject)this).Dispatcher.Dispatch(async () =>
        {
            if (_seconds >= 4)
            {
                _timer.Stop();
                LoadingWindow.IsVisible = false;
                BtnCancelLoading.IsVisible = false;

                AddUserWindow.IsVisible = true;

                LoadData();
            }

            if (_seconds >= 120)
            {
                _timer.Stop();
                await DisplayAlert("Подробная загрузка информации", "Время ожидания истекло", "Отмена");
                await Navigation.PopModalAsync();
            }
        });
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        _timer.Stop();
        await DisplayAlert("Подробная загрузка информации", "Пользователь остановил процесс", "Ок");
        await Navigation.PopModalAsync();
    }

    private void LoadData()
    {
        PicOrganization.ItemsSource = OdbControlHelper.context.Organizations.Select(s => s.Title).ToList();
        PicOrganization.SelectedIndex = PicOrganization.Items.Count - 1;

        PicDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(s => s.Title).ToList();
        PicDivision.SelectedIndex = PicDivision.Items.Count - 1;

        PicMiniDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(s => s.Title).ToList();
        PicMiniDivision.SelectedIndex = PicMiniDivision.Items.Count - 1;

        PicPost.ItemsSource = OdbControlHelper.context.Posts.Select(s => s.Title).ToList();
        PicPost.SelectedIndex = PicPost.Items.Count - 1;

        PicCabinet.ItemsSource = OdbControlHelper.context.Cabinets.Select(s => s.Title).ToList();
        PicCabinet.SelectedIndex = PicCabinet.Items.Count - 1;
    }

    private void PicOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        PicDivision.SelectedIndex = 37 - 1;
        PicMiniDivision.SelectedIndex = 37 - 1;
        PicPost.SelectedIndex = 46 - 1;
        PicCabinet.SelectedIndex = 24 - 1;
    }

    private async void BtnClose_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Подробная информация", "Закрыть окно?", "Да", "Нет");

        if (result == true)
        {
            organization = 0;
            await Navigation.PopModalAsync();
        }
    }

    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        if ((EntSurname.Text != null) && (EntName.Text != null) && (EntMiddlename.Text != null)
            && (PicOrganization.SelectedIndex != 14 - 1) && (PicDivision.SelectedIndex != 37 - 1)
            && (PicPost.SelectedIndex != 46 - 1) && (PicCabinet.SelectedIndex != 24 - 1)
            && (EntEmail.Text != null) && (EntPhone.Text != null))
        {
            try
            {
                User user = new User
                {
                    Surname = EntSurname.Text,
                    Name = EntName.Text,
                    Middlename = EntMiddlename.Text,
                    Date = DateOnly.FromDateTime(DtpDate.Date),
                    OrganizationId = PicOrganization.SelectedIndex,
                    DivisionId = PicDivision.SelectedIndex,
                    MinDivisionId = PicMiniDivision.SelectedIndex,
                    PostId = PicPost.SelectedIndex,
                    CabinetId = PicCabinet.SelectedIndex,
                    Email = EntEmail.Text,
                    Phone = EntPhone.Text,
                    StatusUserId = 1
                };

                OdbControlHelper.context.Users.Add(user);
                OdbControlHelper.context.SaveChanges();

                await DisplayAlert("Уведомление добавление", "Пользователь " + EntSurname.Text + " " + EntName.Text, "Ок");

                organization = 0;
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка базы данных", "Ошибка: " + ex, "Отмена");
                throw;
            }
        }
        else
        {
            await DisplayAlert("Создание пользователя", "Одно или несколько полей пусты!", "Ок");
        }
    }
}