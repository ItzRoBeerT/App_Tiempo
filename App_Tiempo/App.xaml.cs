using App_Tiempo.MVVM.Views;

namespace App_Tiempo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new PaginaPrincipal();
	}
}
