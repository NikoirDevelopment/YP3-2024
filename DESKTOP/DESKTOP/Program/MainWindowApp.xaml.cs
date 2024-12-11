using DESKTOP.Resources.Data;
using DESKTOP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace DESKTOP.Program;

public partial class MainWindowApp : ContentPage
{
    public MainWindowApp()
	{
		InitializeComponent();
        LoadSystem();
	}

    private void LoadSystem()
    {
        LblInfo.IsVisible = true;
        LblDep.Text = "Отдел: NaN";
        BtnBack.IsVisible = false;
        BtnCreate.IsVisible = false;
        BorderCollectionView.IsVisible = false;
        collectionView.ItemsSource = null;
    }

    private void Btn1_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Дороги России";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;

         var users = OdbControlHelper.context.Users
             .Include(x => x.Organization)
             .Include(x => x.Division)
             .Include(x => x.Post)
             .Include(x => x.StatusUser)
             .Include(x => x.Cabinet)
             .ToList();

         collectionView.ItemsSource = users.ToList();
    }

    private void Btn2_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Административные департамент";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void Btn3_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Академия Умные дороги";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void Btn4_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Договорной отдел";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void Btn5_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Общий отдел";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void Btn6_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Лецензионный отдел";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void Btn7_Clicked(object sender, EventArgs e)
    {
        LblInfo.IsVisible = false;
        LblDep.Text = "Отдел: Управление маркетинга";
        BtnBack.IsVisible = true;
        BtnCreate.IsVisible = true;
        BorderCollectionView.IsVisible = true;


    }

    private void BtnBack_Clicked(object sender, EventArgs e)
    {
        LoadSystem();
    }

    private void BtnCreate_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnDetailed_Clicked(object sender, EventArgs e)
    {

    }
}