using App_Tiempo.MVVM.ViewModels;

namespace App_Tiempo.MVVM.Views;

public partial class PaginaPrincipal : ContentPage
{
	public PaginaPrincipal()
	{
		InitializeComponent();
		BindingContext = new TiempoViewModel();
	}
}