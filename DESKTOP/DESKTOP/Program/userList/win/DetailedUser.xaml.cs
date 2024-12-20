using System.Timers;
using DESKTOP;
using DESKTOP.Resources.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace DESKTOP.Program.userList.win;

public partial class DetailedUser : ContentPage
{
    private User _user;

    private Calendar _calendar;
    private List<Calendar> calendars;

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
        StcEventCalendar.IsVisible = false;
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
            if ((_seconds >= 4) && (OdbControlHelper.Buffer.UserID != null))
            {
                LoadingWindow.IsVisible = false;
                DetailedUserWindow.IsVisible = true;

                LoadData();

                _timer.Stop();

                await DisplayAlert("Подсказка", "Для того, чтобы изменить данные сотрудник, нажмите кнопку изменить. " +
                        "Как только вы нажали изменить, вам не достпуна кнопка закрыть. После изменений, нажмите на кнопку сохранить. " +
                        "После этого, у вас снова будет работать кнопка закрыть.", "Ок");
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
        int userID = OdbControlHelper.Buffer.UserID;
        var user = OdbControlHelper.context.Users.FirstOrDefault(
            w => w.UserId == userID);

        if (user != null)
        {
            _user = user;
        }
        else
        {
            await DisplayAlert("Ошибка", "Данные о пользователи не загрузились! Обратитесь к администратору.", "Ок");
            return;
        }

        EntSurname.Text = _user.Surname;
        EntName.Text = _user.Name;
        EntMiddlename.Text = _user.Middlename;

        DtpDate.Date = _user.Date.ToDateTime(TimeOnly.MinValue); //Удаляет время и устанавливает ДД.ММ.ГГГГ

        PicOrganization.ItemsSource = OdbControlHelper.context.Organizations.Select(s => s.Title).ToList();
        PicOrganization.SelectedIndex = _user.OrganizationId - 1;

        PicDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(s => s.Title).ToList();
        PicDivision.SelectedIndex = _user.DivisionId.Value - 1;

        PicMiniDivision.ItemsSource = OdbControlHelper.context.Divisions.Select(s => s.Title).ToList();
        PicMiniDivision.SelectedIndex = _user.MinDivisionId.Value - 1;

        PicPost.ItemsSource = OdbControlHelper.context.Posts.Select(s => s.Title).ToList();
        PicPost.SelectedIndex = _user.PostId - 1;

        PicCabinet.ItemsSource = OdbControlHelper.context.Cabinets.Select(s => s.Title).ToList();
        PicCabinet.SelectedIndex = _user.CabinetId - 1;

        EntEmail.Text = _user.Email;
        EntPhone.Text = _user.Phone;

        if (_user.StatusUserId == 2)
        {
            StcOffUser.IsVisible = true;

            PicStatus.Text = "Уволен";
            DtpDateOff.Date = _user.DateFinish.Value.ToDateTime(TimeOnly.MinValue); //Удаляет время и устанавливает ДД.ММ.ГГГГ;
        }

        LoadCalendar();
    }

    /// <summary>
    /// Отмена редактирования
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnNotEdit_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Изменение данных сотрудника", "Выйти из режима редактирования?", "Да", "Нет");

        if (result == true)
        {
            await DisplayAlert("Изменение данных сотрудника", "Вы вышли из режима редактирования", "Да");

            BtnNotEdit.IsVisible = false;
            BtnRemove.IsVisible = false;
            StcDataUser.IsEnabled = false;

            //Изменение смещения кнопок
            BtnClose.Margin = new Thickness(5, 75, 0, 5);
            BtnNotEdit.Margin = new Thickness(5, 75, 0, 5);
            BtnEdit.Margin = new Thickness(5, 75, 0, 5);

            BtnEdit.Text = "Изменить";
            BtnClose.IsEnabled = true;

            LoadData();
        }
    }

    /// <summary>
    /// Обновление изменение
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PicOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        PicDivision.SelectedIndex = 37 - 1;
        PicMiniDivision.SelectedIndex = 37 - 1;
        PicPost.SelectedIndex = 46 - 1;
        PicCabinet.SelectedIndex = 24 - 1;
    }

    /// <summary>
    /// Изменения личной информации сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnEdit_Clicked(object sender, EventArgs e)
    {
        if (StcDataUser.IsEnabled == false)
        {
            BtnEdit.Text = "Сохранить";
            BtnClose.IsEnabled = false;
            BtnNotEdit.IsVisible = true;

            StcDataUser.IsEnabled = true;
            BtnRemove.IsVisible = true;

            //Изменение смещения кнопок
            BtnClose.Margin = new Thickness(5, 40, 0, 5);
            BtnNotEdit.Margin = new Thickness(5, 40, 0, 5);
            BtnEdit.Margin = new Thickness(5, 40, 0, 5);
        }
        else
        {
            bool result = await DisplayAlert("Изменение данных сотрудника", "Применить изменения?", "Да", "Нет");

            if (result == true)
            {
                BtnEdit.Text = "Изменить";

                StcDataUser.IsEnabled = false;

                BtnClose.IsEnabled = true;
                BtnNotEdit.IsVisible = false;
                BtnRemove.IsVisible = false;

                //Изменение смещения кнопок
                BtnClose.Margin = new Thickness(5, 75, 0, 5);
                BtnNotEdit.Margin = new Thickness(5, 75, 0, 5);
                BtnEdit.Margin = new Thickness(5, 75, 0, 5);

                try
                {
                    _user.OrganizationId = PicOrganization.SelectedIndex - 1;
                    _user.DivisionId = PicDivision.SelectedIndex - 1;
                    _user.MinDivisionId = PicMiniDivision.SelectedIndex - 1;
                    _user.PostId = PicPost.SelectedIndex - 1;
                    _user.Surname = EntSurname.Text;
                    _user.Name = EntName.Text;
                    _user.Middlename = EntMiddlename.Text;
                    _user.Date = DateOnly.FromDateTime(DtpDate.Date);
                    _user.Phone = EntPhone.Text;
                    _user.CabinetId = PicCabinet.SelectedIndex;
                    _user.Email = EntEmail.Text;

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

    /// <summary>
    /// Закрытие окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnClose_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Подробная информация", "Закрыть окно?", "Да", "Нет");

        if (result == true)
        {
            _user = null;
            calendars = null;

            await Navigation.PopModalAsync();
        }
    }

    /// <summary>
    /// Загрузка календаря событий
    /// </summary>
    private void LoadCalendar()
    {
        var calendar = OdbControlHelper.context.Calendars
            .Include(i => i.StatusCalendar)
            .Include(i => i.TypeCalendar)
            .Include(i => i.User)
            .ToList();

        PickTypeCalendar.ItemsSource = OdbControlHelper.context.TypeCalendars.Select(w => w.Title).ToList();
        PickStatusCalendar.ItemsSource = OdbControlHelper.context.StatusCalendars.Select(w => w.Title).ToList();

        if (calendar != null)
        {
            calendars = calendar;

            LblTitleCalendar.Text = "Весь календарь";

            ColVCalendar.ItemsSource = calendars
                    .Where(w => w.UserId == OdbControlHelper.Buffer.UserID)
                    .ToList();
        }
        else
        {
            ColVCalendar.ItemsSource = null;
        }

        var calendaaaaar = OdbControlHelper.context.Calendars
            .FirstOrDefault(w => w.UserId == _user.UserId);

        if (calendaaaaar != null)
        {
            _calendar = calendaaaaar;
        }
    }

    private void BtnFull_Clicked(object sender, EventArgs e)
    {
        LblTitleCalendar.Text = "Весь календарь";

        ColVCalendar.ItemsSource = calendars
                .Where(w => w.UserId == OdbControlHelper.Buffer.UserID)
                .ToList();
    }

    private void BtnPast_Clicked(object sender, EventArgs e)
    {
        LblTitleCalendar.Text = "Прошедшие мероприятия";

        // Загрузка текущей даты
        DateTime currentDate = DateTime.Now;

        ColVCalendar.ItemsSource = calendars
                    .Where(w => w.UserId == OdbControlHelper.Buffer.UserID)
                    .Where(w => w.DateTimeStart.ToDateTime(TimeOnly.MinValue) < currentDate)
                    .ToList();
    }

    private void BtnPresent_Clicked(object sender, EventArgs e)
    {
        LblTitleCalendar.Text = "Текущие мероприятия";

        // Загрузка текущей даты
        DateTime currentDate = DateTime.Now;

        ColVCalendar.ItemsSource = calendars
                    .Where(w => w.UserId == OdbControlHelper.Buffer.UserID)
                    .Where(w => w.DateTimeStart.ToDateTime(TimeOnly.MinValue) == currentDate)
                    .ToList();
    }

    private void BtnFuture_Clicked(object sender, EventArgs e)
    {
        LblTitleCalendar.Text = "Будущие мероприятия";

        // Загрузка текущей даты
        DateTime currentDate = DateTime.Now;

        ColVCalendar.ItemsSource = calendars
                    .Where(w => w.UserId == OdbControlHelper.Buffer.UserID)
                    .Where(w => w.DateTimeStart.ToDateTime(TimeOnly.MinValue) > currentDate)
                    .ToList();
    }

    /// <summary>
    /// Создание/Обновление событий сотрудников
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnSaveCalendar_Clicked(object sender, EventArgs e)
    {
        if (LblEditCalendar.Text == "Создание записи")
        {
            // Проблема значений статуса календаря
            if (PickStatusCalendar.SelectedIndex != 0)
            {
                PickStatusCalendar.SelectedIndex = +1;
            }
            else
            {
                PickStatusCalendar.SelectedIndex = 0;
            }

            // Изменение значений тип календаря
            if (PickTypeCalendar.SelectedIndex != 0)
            {
                PickTypeCalendar.SelectedIndex = +1;
            }
            else
            {
                PickTypeCalendar.SelectedIndex = 0;
            }

            try
            {
                Calendar calendar = new Calendar
                {
                    DateTimeStart = DateOnly.FromDateTime(DtPCalendarStart.Date),
                    DateTimeEnd = DateOnly.FromDateTime(DtPCalendarEnd.Date),
                    StatusCalendarId = PickStatusCalendar.SelectedIndex,
                    TypeCalendarId = PickTypeCalendar.SelectedIndex,
                    Description = EntDescriptionCalendar.Text,
                    UserId = _user.UserId,
                };

                OdbControlHelper.context.Calendars.Add(calendar);
                OdbControlHelper.context.SaveChanges();

                await DisplayAlert("Уведомление", "Событие добавлено в календарь сотрудника " + _user.Surname + " " + _user.Name + " " + _user.Middlename, "Ок");

                PickStatusCalendar.SelectedItem = null;
                PickTypeCalendar.SelectedItem = null;
                EntDescriptionCalendar.Text = null;
                DtPCalendarStart.Date = DateTime.Now;
                DtPCalendarEnd.Date = DateTime.Now;

                StcEventCalendar.IsVisible = false;
                BtnDeleteCalendar.IsVisible = false;
                BtnCreateCalendar.Text = "Создать событие";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Критическаая ошибка базы данных! ", " " + ex, "Ок");
            }
        }
        else
        {
            // Проблема значений статуса календаря
            if (PickStatusCalendar.SelectedIndex != 0)
            {
                PickStatusCalendar.SelectedIndex = -1;
            }

            // Изменение значений тип календаря
            if (PickTypeCalendar.SelectedIndex != 0)
            {
                PickTypeCalendar.SelectedIndex = -1;
            }

            try
            {
                _calendar.DateTimeStart = DateOnly.FromDateTime(DtPCalendarStart.Date);
                _calendar.DateTimeEnd = DateOnly.FromDateTime(DtPCalendarEnd.Date);
                _calendar.StatusCalendarId = PickStatusCalendar.SelectedIndex;
                _calendar.TypeCalendarId = PickTypeCalendar.SelectedIndex;
                _calendar.Description = EntDescriptionCalendar.Text;
                _calendar.UserId = _user.UserId;

                OdbControlHelper.context.SaveChanges();

                await DisplayAlert("Уведомление", "Событие обновлено в календаре сотрудника " + _user.Surname + " " + _user.Name + " " + _user.Middlename, "Ок");

                PickStatusCalendar.SelectedItem = null;
                PickTypeCalendar.SelectedItem = null;
                EntDescriptionCalendar.Text = null;
                DtPCalendarStart.Date = DateTime.Now;
                DtPCalendarEnd.Date = DateTime.Now;

                StcEventCalendar.IsVisible = false;
                BtnDeleteCalendar.IsVisible = false;
                BtnCreateCalendar.Text = "Создать событие";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Критическаая ошибка базы данных! ", "" + ex, "Ок");
            }
        }
    }

    /// <summary>
    /// Открытие панели создание события
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnCreateCalendar_Clicked(object sender, EventArgs e)
    {
        if (LblEditCalendar.Text == "Изменение события")
        {
            BtnDeleteCalendar.IsVisible = true;
        }
        else
        {
            BtnDeleteCalendar.IsVisible = false;
        }

        if (StcEventCalendar.IsVisible == false)
        {
            BtnCreateCalendar.Text = "Отмена создания";
            StcEventCalendar.IsVisible = true;

            if ((PickTypeCalendar.SelectedItem != null) && (PickStatusCalendar.SelectedItem != null) && (EntDescriptionCalendar.Text.Length > 0))
            {
                bool result = await DisplayAlert("Уведомление",
                "Модуль созддания/редактирования уже используется. Хотите ли вы его заменить?", "Да", "Нет");

                if (result == true)
                {
                    LblEditCalendar.Text = "Изменение события";
                    PickStatusCalendar.SelectedItem = null;
                    PickTypeCalendar.SelectedItem = null;
                    EntDescriptionCalendar.Text = null;
                    DtPCalendarStart.Date = DateTime.Now;
                    DtPCalendarEnd.Date = DateTime.Now;

                    BtnCreateCalendar.Text = "Отмена создания";
                }
            }
        }
        else
        {
            BtnCreateCalendar.Text = "Создать событие";
            StcEventCalendar.IsVisible = false;
        }
    }

    /// <summary>
    /// Удаление записи календаря
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnDeleteCalendar_Clicked(object sender, EventArgs e)
    {
        OdbControlHelper.context.Remove(_calendar);
        OdbControlHelper.context.SaveChanges();
    }

    private void BtnReloadCalendar_Clicked(object sender, EventArgs e)
    {
        LoadCalendar();
    }

    /// <summary>
    /// Кнопка изменить событие
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnEditEventCalendar_Clicked(object sender, EventArgs e)
    {
        PickStatusCalendar.SelectedItem = null;
        PickTypeCalendar.SelectedItem = null;
        EntDescriptionCalendar.Text = null;
        DtPCalendarStart.Date = DateTime.Now;
        DtPCalendarEnd.Date = DateTime.Now;

        BtnCreateCalendar.Text = "Изменение события";
        StcEventCalendar.IsVisible = true;

        var button = sender as Button;
        var calendar = button?.BindingContext as Calendar;

        if (calendar != null)
        {
            LblEditCalendar.Text = "Изменение события";
            PickStatusCalendar.SelectedIndex = (int)calendar.StatusCalendarId;
            PickTypeCalendar.SelectedIndex = (int)calendar.TypeCalendarId;
            EntDescriptionCalendar.Text = calendar.Description;
            DtPCalendarStart.Date = calendar.DateTimeStart.ToDateTime(TimeOnly.MinValue);
            DtPCalendarEnd.Date = calendar.DateTimeEnd.ToDateTime(TimeOnly.MinValue);

            BtnCreateCalendar.Text = "Отмена создания";
        }
        else
        {
            await DisplayAlert("Ошибка",
                "Ошибка загрузки данных. Обратитесь к адмнистатору!", "Отмена");
        }
    }

    /// <summary>
    /// Увольнение сотрудника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnRemove_Clicked(object sender, EventArgs e)
    {
        bool result1 = await DisplayAlert("Процесс удаление сотрудника",
                "Вы уверены, что хотите уволить сотрудника?", "Да", "Отмена");

        if (result1)
        {
            bool result2 = await DisplayAlert("Процесс удаление сотрудника",
                "Вы ТОЧНО уверены, что хотите УВОЛИТЬ сотрудника?", "Да", "Отмена");

            if (result2)
            {
                _user.StatusUserId = 2;
                _user.DateFinish = DateOnly.FromDateTime(DateTime.Now);

                OdbControlHelper.context.SaveChanges();

                await DisplayAlert("Процесс удаление сотрудника",
                "Сотрудник уволен! Данные о сотрудники удалятся в течение 30 дней", "Ок");
            }
        }
    }
}