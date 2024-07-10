using kpazminoAS6.Models;
using System.Net;
using System.Text;
using System;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace kpazminoAS6.Views;

public partial class ActElim : ContentPage
{
    private const string Url = "http://172.21.96.65/semana6/estudiantews.php";
    private readonly HttpClient client = new HttpClient();

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
        try
        {
            var estudiante = new Estudiante
            {
                codigo = int.Parse(txtCodigo.Text),
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                edad = int.Parse(txtEdad.Text)
            };

            var json = JsonConvert.SerializeObject(estudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseTask = client.PutAsync($"{Url}?codigo={estudiante.codigo}", content);
            responseTask.Wait(); // Esperar de manera síncrona la respuesta

            var response = responseTask.Result;

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Éxito", "Estudiante actualizado correctamente", "OK");
                MessagingCenter.Send(this, "ActualizarLista"); // Envía un mensaje para actualizar la lista en vEstudiante
                Navigation.PopAsync();
            }
            else
            {
                var responseStringTask = response.Content.ReadAsStringAsync();
                responseStringTask.Wait(); // Esperar de manera síncrona la lectura del contenido
                var responseString = responseStringTask.Result;

                DisplayAlert("Error", $"No se pudo actualizar el estudiante: {responseString}", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "OK");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var codigo = txtCodigo.Text;

            var response = client.DeleteAsync($"{Url}?codigo={codigo}").Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
                MessagingCenter.Send(this, "ActualizarLista"); // Envía un mensaje para actualizar la lista
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", $"No se pudo eliminar el estudiante: {responseString}", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "OK");
        }
    }
}