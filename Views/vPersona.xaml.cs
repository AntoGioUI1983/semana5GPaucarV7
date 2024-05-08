namespace semana5GPaucar.Views;
using semana5GPaucar.Models;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private  void btnAgregar_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Views.vAgregar());
        
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        
        List<Persona> people = App.PersonRepo.GetAllPeople();
        Listapersonas.ItemsSource = people;
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

       
        bool answer = await DisplayAlert("Confirmaci�n", $"�Est�s seguro de borrar a {persona.Name}?", "S�", "No");

        if (answer)
        {
            App.PersonRepo.DeletePerson(persona.Id);
         
            await DisplayAlert("Informaci�n", App.PersonRepo.statusMessage, "Aceptar");
            btnObtener_Clicked(sender, e); 
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;
        Navigation.PushAsync(new Views.vEditar(persona.Name, persona.Id,persona.Apellido));
    }
}
