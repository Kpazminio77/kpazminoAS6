using kpazminoAS6.Models;

namespace kpazminoAS6.Views;

public partial class ActElim : ContentPage
{
	public ActElim(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception)
        {

            throw;
        }
    }
}