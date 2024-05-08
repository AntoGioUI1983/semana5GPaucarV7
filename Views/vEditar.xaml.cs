namespace semana5GPaucar.Views;
using semana5GPaucar.Models;


    public partial class vEditar : ContentPage
{
    public vEditar(string nombre, int id,string apellido)
    {
        InitializeComponent();

        txtNombre.Text = nombre;
        lblId.Text = id.ToString();
        txtApellido.Text = apellido;
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        string nuevoNombre = txtNombre.Text;
        string nuevoApellido = txtApellido.Text;
        int id = int.Parse(lblId.Text);

      
        Persona persona = new Persona { Id = id, Name = nuevoNombre , Apellido=nuevoApellido};
        App.PersonRepo.UpdatePerson(persona);

        MostrarAlerta("Éxito", "Información actualizada");
    }


    private async void MostrarAlerta(string titulo, string mensaje)
        {
            await DisplayAlert(titulo, mensaje, "Aceptar");
        }

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vPersona());
    }
}