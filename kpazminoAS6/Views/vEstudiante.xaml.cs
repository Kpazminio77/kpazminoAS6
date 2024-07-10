using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kpazminoAS6.Views;

public partial class vEstudiante : ContentPage
{
	//variable para crear mi conexion con la ip de mi maquina donde se ejecuta la bd en xamp
	private const string Url = "http://192.168.16.48/semana6/estudiantews.php";
	private readonly HttpClient client = new HttpClient();
	//contenedor temporal para los datos
	private ObservableCollection<Models.Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		//consumir el metodo mostrar
		mostrar();
	}

	//creo el metodo par amostrar
	public async void mostrar()
	{
		var content = await client.GetStringAsync(Url);
		List<Models.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		est = new ObservableCollection<Models.Estudiante>(mostrar);
		listEstudiantes.ItemsSource = est;
	}
}