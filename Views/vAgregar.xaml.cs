
namespace semana5GPaucar.Views;
using semana5GPaucar.Models;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}


    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text))
        {
            App.PersonRepo.AddNewPerson(txtNombre.Text, txtApellido.Text);

            await DisplayAlert("Información", App.PersonRepo.statusMessage, "Aceptar");
        }
        else
        {
            await DisplayAlert("Error", "El nombre y el apellido son requeridos", "Aceptar");
        }
    }



    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vPersona());
    }
}
