using System.Net;

namespace kpazminoAS6.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);

			cliente.UploadValues("http://10.2.8.79/semana6/estudiantews.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());


		}
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "OK");
		}
    }
}