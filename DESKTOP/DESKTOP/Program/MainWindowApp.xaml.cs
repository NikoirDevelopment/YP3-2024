using DESKTOP.Resources.Data;
using DESKTOP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using DESKTOP.Program.userList.win;
using System.Diagnostics.Tracing;

namespace DESKTOP.Program;

public partial class MainWindowApp : ContentPage
{
    //Переключение между страницами
    public int modeCollectionView = 0;

    //Буфер данных
    private List<User> Full;
    private List<User> RoadsRussia;
    private List<User> AcademySmartRoads;
    private List<User> AdministrativeDepartment;
    private List<User> FinancialAndEconomicDepartment;
    private List<User> ManagementApparatus;
    private List<User> DepartmentMarketingAndPartnerships;
    private List<User> DepartmentCorporateEvents;
    private List<User> DepartmentCommunications;
    private List<User> HR_Department;
    private List<User> DepartmentStrategyAndPlanning;
    private List<User> DepartmentWorkWithIndustry;
    private List<User> LegalDepartment;
    private List<User> FinancialPlanningAndControlDepartment;

    public MainWindowApp()
	{
		InitializeComponent();
        LoadData();
        LoadCollectionView();
    }

    private void BtnRoadsRussia_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 1;
        LoadCollectionView();
    }

    private void BtnAdministrativeDepartment_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 2;
        LoadCollectionView();

    }

    private void BtnAcademySmartRoads_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 3;
        LoadCollectionView();
    }

    private void BtnManagementApparatus_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 5;
        LoadCollectionView();
    }

    private void BtnDepartmentCommunications_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 8;
        LoadCollectionView();
    }

    private void BtnDepartmentMarketingAndPartnerships_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 6;
        LoadCollectionView();
    }

    private void BtnDepartmentCorporateEvents_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 7;
        LoadCollectionView();
    }

    private void BtnFinancialAndEconomicDepartment_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 4;
        LoadCollectionView();
    }

    private void BtnHR_Department_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 9;
        LoadCollectionView();
    }

    private void BtnDepartmentStrategyAndPlanning_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 10;
        LoadCollectionView();
    }

    private void BtnDepartmentWorkWithIndustry_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 11;
        LoadCollectionView();
    }

    private void BtnLegalDepartment_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 12;
        LoadCollectionView();
    }

    private void BtnFinancialPlanningAndControlDepartment_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 13;
        LoadCollectionView();
    }

    /// <summary>
    /// Загрузка данных в буфер
    /// </summary>
    private void LoadData()
    {
        Image image = new Image
        {
            Source = ImageSource.FromResource("DESKTOP.Resources.Images.res.Logo.png")
        };
        ImgLogo.Source = image.Source;

        Full = OdbControlHelper.context.Users
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        RoadsRussia = OdbControlHelper.context.Users
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        AcademySmartRoads = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 2)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        AdministrativeDepartment = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 1)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        FinancialAndEconomicDepartment = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 11)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        ManagementApparatus = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 3)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        DepartmentMarketingAndPartnerships = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 5)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        DepartmentCorporateEvents = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 6)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        DepartmentCommunications = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 4)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        HR_Department = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 7)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        DepartmentStrategyAndPlanning = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 9)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        DepartmentWorkWithIndustry = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 8)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        LegalDepartment = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 12)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();

        FinancialPlanningAndControlDepartment = OdbControlHelper.context.Users
                    .Where(x => x.OrganizationId == 10)
                    .Include(x => x.Organization)
                    .Include(x => x.Division)
                    .Include(x => x.Post)
                    .Include(x => x.StatusUser)
                    .Include(x => x.Cabinet)
                    .ToList();
    }

    /// <summary>
    /// Поисковая система
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnSearch_Clicked(object sender, EventArgs e)
    {
        if (EntSearch.Text != null)
        {
            string search = EntSearch.Text;

            if (string.IsNullOrWhiteSpace(search))
            {
                await DisplayAlert("Системное уведомление | Поисковая система", "Поле состоит из пробелов и пустых символов", "OK");
            }
            else
            {
                if (modeCollectionView != 0)
                {
                    switch (modeCollectionView)
                    {
                        case 1:
                            LblDep.Text = "Поиск (Дороги России)";
                            collectionView.ItemsSource = RoadsRussia
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                            break;

                        case 2:
                            LblDep.Text = "Поиск (Административные департамент)";
                            collectionView.ItemsSource = AdministrativeDepartment
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 3:
                            LblDep.Text = "Поиск (Академия Умные дороги)";
                            collectionView.ItemsSource = AcademySmartRoads
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 4:
                            LblDep.Text = "Поиск (Финансово-экономический департамент)";
                            collectionView.ItemsSource = FinancialAndEconomicDepartment
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 5:
                            LblDep.Text = "Поиск (Аппарат управления)";
                            collectionView.ItemsSource = ManagementApparatus
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 6:
                            LblDep.Text = "Поиск (Департамент маркетинга и партнерских отношений)";
                            collectionView.ItemsSource = DepartmentMarketingAndPartnerships
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 7:
                            LblDep.Text = "Поиск (Департамент по организации корпоративов)";
                            collectionView.ItemsSource = DepartmentCorporateEvents
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 8:
                            LblDep.Text = "Поиск (Департамент коммуникаций)";
                            collectionView.ItemsSource = DepartmentCommunications
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 9:
                            LblDep.Text = "Поиск (Департамент по работе с персоналом)";
                            collectionView.ItemsSource = HR_Department
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 10:
                            LblDep.Text = "Поиск (Департамент стратегии и планирования)";
                            collectionView.ItemsSource = DepartmentStrategyAndPlanning
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 11:
                            LblDep.Text = "Поиск (Департамент по работе с промышленностью)";
                            collectionView.ItemsSource = DepartmentWorkWithIndustry
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 12:
                            LblDep.Text = "Поиск (Юридический департамент)";
                            collectionView.ItemsSource = LegalDepartment
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;

                        case 13:
                            LblDep.Text = "Поиск (Управление Финансового планирования и контроля)";
                            collectionView.ItemsSource = FinancialPlanningAndControlDepartment
                                .Where(w => w.Surname.Contains(search)
                                    || w.Name.Contains(search)
                                    || w.Middlename.Contains(search)
                                    || w.Phone.Contains(search)
                                    || w.Email.Contains(search))
                                .ToList();
                        break;
                    }
                }
                else
                {
                    LblDep.Text = "Поиск";

                    collectionView.ItemsSource = null;

                    collectionView.ItemsSource = Full
                            .Where(w => w.Surname.Contains(search)
                                || w.Name.Contains(search)
                                || w.Middlename.Contains(search)
                                || w.Phone.Contains(search)
                                || w.Email.Contains(search))
                            .ToList();

                    BorderCollectionView.IsVisible = true;
                    LblInfo.IsVisible = false;

                    BtnBack.IsVisible = true;
                    BtnCreate.IsVisible = true;
                }

            }
        }
        else
        {
            await DisplayAlert("Системное уведомление | Поиск", "Поле поиско пустое!", "OK");
        }
    }

    /// <summary>
    /// Переключение между страницами
    /// </summary>
    private void LoadCollectionView()
    {
        if (modeCollectionView != 0)
        {
            BorderCollectionView.IsVisible = true;
            LblInfo.IsVisible = false;

            BtnBack.IsVisible = true;
            BtnCreate.IsVisible = true;
        }
        else
        {
            EntSearch.Placeholder = "Поиск";

            LblDep.Text = "Отдел: NaN";

            BorderCollectionView.IsVisible = false;
            LblInfo.IsVisible = true;

            BtnBack.IsVisible = false;
            BtnCreate.IsVisible = false;

            GC.Collect();
            collectionView.ItemsSource = null;
            GC.WaitForPendingFinalizers();

            return;
        }

        switch (modeCollectionView)
        {
            case 1:
                EntSearch.Placeholder = "Поиск (Дороги России)";

                LblDep.Text = "Отдел: Дороги России (Общий список)";
                collectionView.ItemsSource = RoadsRussia;
            break;

            case 2:
                EntSearch.Placeholder = "Поиск (Административные департамент)";

                LblDep.Text = "Отдел: Административные департамент";
                collectionView.ItemsSource = AdministrativeDepartment;
            break;

            case 3:
                EntSearch.Placeholder = "Поиск (Академия Умные дороги)";

                LblDep.Text = "Отдел: Академия Умные дороги";
                collectionView.ItemsSource = AcademySmartRoads;
            break;

            case 4:
                EntSearch.Placeholder = "Поиск (Финансово-экономический департамент)";

                LblDep.Text = "Отдел: Финансово-экономический департамент";
                collectionView.ItemsSource = FinancialAndEconomicDepartment;
            break;

            case 5:
                EntSearch.Placeholder = "Поиск (Аппарат управления)";

                LblDep.Text = "Отдел: Аппарат управления";
                collectionView.ItemsSource = ManagementApparatus;
            break;

            case 6:
                EntSearch.Placeholder = "Поиск (Департамент маркетинга и партнерских отношений)";

                LblDep.Text = "Отдел: Департамент маркетинга и партнерских отношений";
                collectionView.ItemsSource = DepartmentMarketingAndPartnerships;
            break;

            case 7:
                EntSearch.Placeholder = "Поиск (Департамент по организации корпоративов)";

                LblDep.Text = "Отдел: Департамент по организации корпоративов";
                collectionView.ItemsSource = DepartmentCorporateEvents;
            break;

            case 8:
                EntSearch.Placeholder = "Поиск (Департамент коммуникаций)";

                LblDep.Text = "Отдел: Департамент коммуникаций";
                collectionView.ItemsSource = DepartmentCommunications;
            break;

            case 9:
                EntSearch.Placeholder = "Поиск (Департамент по работе с персоналом)";

                LblDep.Text = "Отдел: Департамент по работе с персоналом";
                collectionView.ItemsSource = HR_Department;
            break;

            case 10:
                EntSearch.Placeholder = "Поиск (Департамент стратегии и планирования)";

                LblDep.Text = "Отдел: Департамент стратегии и планирования";
                collectionView.ItemsSource = DepartmentStrategyAndPlanning;
            break;

            case 11:
                EntSearch.Placeholder = "Поиск (Департамент по работе с промышленностью)";

                LblDep.Text = "Отдел: Департамент по работе с промышленностью";
                collectionView.ItemsSource = DepartmentWorkWithIndustry;
            break;

            case 12:
                EntSearch.Placeholder = "Поиск (Юридический департамент)";

                LblDep.Text = "Отдел: Юридический департамент";
                collectionView.ItemsSource = LegalDepartment;
            break;

            case 13:
                EntSearch.Placeholder = "Поиск (Управление Финансового планирования и контроля)";

                LblDep.Text = "Отдел: Управление Финансового планирования и контроля";
                collectionView.ItemsSource = FinancialPlanningAndControlDepartment;
            break;
        }
    }

    private void BtnBack_Clicked(object sender, EventArgs e)
    {
        modeCollectionView = 0;
        LoadCollectionView();
    }

    /// <summary>
    /// Открытия модального окна подробностей
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BtnDetailed_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var user = button?.BindingContext as User;

        if (user != null)
        {
            OdbControlHelper.Buffer.UserID = user.UserId;

            var detailedUser = new DetailedUser();
            await Navigation.PushModalAsync(detailedUser);
        }
        else
        {
            await DisplayAlert("Ошибка", "Ошибка загрузки данных. Обратитесь к адмнистатору!", "Отмена");
        }
    }

    private void BtnCreate_Clicked(object sender, EventArgs e)
    {

    }
}