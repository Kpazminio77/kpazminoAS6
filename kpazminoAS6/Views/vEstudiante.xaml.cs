using kpazminoAS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kpazminoAS6.Views;

public partial class vEstudiante : ContentPage
{
	//variable para crear mi conexion con la ip de mi maquina donde se ejecuta la bd en xamp
	private const string Url = "http://172.21.96.65/semana6/estudiantews.php";
	private readonly HttpClient client = new HttpClient();
	//contenedor temporal para los datos
	private ObservableCollection<Models.Estudiante> est;
    private Estudiante selectedEstu;
    public vEstudiante()
	{
		InitializeComponent();
		//consumir el metodo mostrar
		mostrar();

        MessagingCenter.Subscribe<ActElim>(this, "ActualizarLista", sender =>
        {
            mostrar();
        });
    }

	//creo el metodo par amostrar
	public async void mostrar()
	{
		var content = await client.GetStringAsync(Url);
		List<Models.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		est = new ObservableCollection<Models.Estudiante>(mostrar);
		listEstudiantes.ItemsSource = est;
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.vAgregar());
    }

	private void listEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedEstu = e.CurrentSelection.FirstOrDefault() as Estudiante;
		Navigation.PushAsync(new ActElim(selectedEstu));
    }
}