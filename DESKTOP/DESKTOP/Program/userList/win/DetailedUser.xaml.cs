namespace DESKTOP.Program.userList.win;

using DESKTOP.Resources.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using System;
using System.Timers;

public partial class DetailedUser : ContentPage
{
    private User _user;

	public DetailedUser()
	{
		InitializeComponent();
        StartSystem_Timer();
        StartSystem();
    }

	private void StartSystem()
	{
        LoadingWindow.IsVisible = true;
        BtnCancelLoading.IsVisible = false;

        DetailedUserWindow.IsVisible = false;

        StcDataUser.IsEnabled = false;
        StcOffUser.IsVisible = false;
    }

    /// <summary>
    /// Таймер загрузки
    /// </summary>
    private Timer _timer;
    private int _seconds;
    private void StartSystem_Timer()
	{
        _seconds = 0;
        _timer = new Timer(1000); // Устанавливаем интервал в 1 секунду
        _timer.Elapsed += OnTimeEvent; // Использование таймера

        _timer.Start();
    }
    private async void OnTimeEvent(object sender, ElapsedEventArgs e)
    {
        _seconds++;

        ((BindableObject)this).Dispatcher.Dispatch(async () =>
        {
            if ((_seconds >= 4) && (OdbControlHelper.Buffer.UserID != null))
            {
                LoadingWindow.IsVisible = false;
                DetailedUserWindow.IsVisible = true;

                LoadData();

                _timer.Stop();
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

    private async void LoadData()
    {
        await DisplayAlert("Подсказка", "Для того, чтобы изменить данные сотрудник, нажмите кнопку изменить. " +
            "Как только вы нажали изменить, вам не достпуна кнопка закрыть. После изменений, нажмите на кнопку сохранить. " +
            "После этого, у вас снова будет работать кнопка закрыть.", "Ок");

        PicOrganization.ItemsSource = OdbControlHelper.context.Organizations.Select(w => w.Title).ToList();
        PicDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(w => w.Title).ToList();
        PicMiniDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(w => w.Title).ToList();
        PicPost.ItemsSource = OdbControlHelper.context.Posts.Select(w => w.Title).ToList();
        PicCabinet.ItemsSource = OdbControlHelper.context.Cabinets.Select(w => w.Title).ToList();
        PicStatus.ItemsSource = OdbControlHelper.context.StatusUsers.Select(w => w.Title).ToList();

        int userID = OdbControlHelper.Buffer.UserID;
        var user = OdbControlHelper.context.Users.FirstOrDefault(
            w => w.UserId == userID);

        if (user != null)
        {
            _user = user;
        }

        if (_user != null)
        {
            EntSurname.Text = _user.Surname;
            EntName.Text = _user.Name;
            EntMiddlename.Text = _user.Middlename;
            DtpDate.Date = _user.Date.ToDateTime(TimeOnly.MinValue); //Удаляет время и устанавливает ДД.ММ.ГГГГ

            PicOrganization.SelectedIndex = _user.OrganizationId;

            if (_user.DivisionId.HasValue)
            {
                PicDivision.SelectedIndex = _user.DivisionId.Value;
            }

            if (_user.MinDivisionId.HasValue)
            {
                PicMiniDivision.SelectedIndex = _user.MinDivisionId.Value;
            }

            PicPost.SelectedIndex = _user.PostId;
            PicCabinet.SelectedIndex = _user.CabinetId;

            EntEmail.Text = _user.Email;
            EntPhone.Text = _user.Phone;
            PicStatus.SelectedItem = _user.StatusUser;
            //DtpDate.Date = _user.DateFinish.Value.ToDateTime(TimeOnly.MinValue); //Удаляет время и устанавливает ДД.ММ.ГГГГ


        }

        if (_user.StatusUserId == 3)
        {
            StcOffUser.IsVisible = true;
            BtnClose.Margin = new Thickness(5, 15, 0, 5);
            BtnEdit.Margin = new Thickness(90, 15, 5, 5);
        }
    }

    private async void BtnEdit_Clicked(object sender, EventArgs e)
    {
        if (StcDataUser.IsEnabled == false)
        {
            BtnEdit.Text = "Сохранить";
            BtnClose.IsEnabled = false;

            StcDataUser.IsEnabled = true;
        }
        else
        {
            BtnEdit.Text = "Изменить";
            BtnClose.IsEnabled = true;

            StcDataUser.IsEnabled = false;

            if ((EntSurname.Text != _user.Surname) || (EntName.Text != _user.Name) || (EntMiddlename.Text != _user.Middlename) ||
                (DtpDate.Date != _user.Date.ToDateTime(TimeOnly.MinValue)) || (PicOrganization.SelectedIndex != _user.OrganizationId) ||
                (PicDivision.SelectedIndex != _user.DivisionId) || (PicMiniDivision.SelectedIndex != _user.MinDivisionId) || (PicPost.SelectedIndex != _user.PostId) ||
                (PicCabinet.SelectedIndex != _user.CabinetId) || (EntEmail.Text != _user.Email) || (EntPhone.Text != _user.Phone) || (PicStatus.SelectedIndex != _user.StatusUserId))
            {
                bool result = await DisplayAlert("Изменение данных сотрудника",
                    "Сохранить изменения?", "Да", "Нет");

                if (result == true)
                {
                    try
                    {
                        _user.OrganizationId = PicOrganization.SelectedIndex;
                        _user.DivisionId = PicDivision.SelectedIndex;
                        _user.MinDivisionId = PicMiniDivision.SelectedIndex;
                        _user.PostId = PicPost.SelectedIndex;
                        _user.Surname = EntSurname.Text;
                        _user.Name = EntName.Text;
                        _user.Middlename = EntMiddlename.Text;
                        _user.Date = DateOnly.FromDateTime(DtpDate.Date);
                        _user.Phone = EntPhone.Text;
                        _user.CabinetId = PicCabinet.SelectedIndex;
                        _user.Email = EntEmail.Text;
                        if (PicStatus.SelectedIndex == 3)
                        {
                            _user.StatusUserId = PicStatus.SelectedIndex;
                            _user.DateFinish = DateOnly.FromDateTime(DateTime.Now);

                        }
                        else
                        {
                            _user.StatusUserId = _user.StatusUserId;
                        }
                        OdbControlHelper.context.SaveChanges();

                        await DisplayAlert("Изменение данных сотрудника", "Данные успешно изменены!", "Ок");
                    }
                    catch (DbUpdateException dbEx)
                    {
                        var innerException = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
                        await DisplayAlert("Ошибка сохранения", "Возникла ошибка: " + innerException, "Отмена");
                    }
                }
            }
        }
    }

    private async void BtnClose_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Подробная информация", "Закрыть окно?", "Да", "Нет");

        if (result == true)
        {
            await Navigation.PopModalAsync();
        }
    }

}