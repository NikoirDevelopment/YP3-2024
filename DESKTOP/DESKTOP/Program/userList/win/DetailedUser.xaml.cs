namespace DESKTOP.Program.userList.win;

public partial class DetailedUser : Window
{
	private User _user;

	public DetailedUser(User user)
	{
		InitializeComponent();
		LoadSystem(user);



	}

	private void LoadSystem(User user)
	{
        _user = user;

		this.Title = "Подробная информация сотрадница " + _user.Surname + " " + _user.Name + " " + _user.Middlename;
    }
}