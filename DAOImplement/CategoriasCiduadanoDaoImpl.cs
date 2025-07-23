using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using CapaDatos;
using Conexion;
using DAO;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using CommonCache;
using System.Net.Http.Headers;


namespace DAOImplement
{
    public class CategoriasCiduadanoDaoImpl : ICategoriasCiudadanoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public async Task<(List<DCategoriasCiudadano>, string error)> retornarListaCategoriasCiudadano()
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            List<DCategoriasCiudadano> listaCategoriasCiudadano = new List<DCategoriasCiudadano>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //agregar tpken a la cabecera
                    this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/categorias-ciudadano/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCategoriasCiudadano = JsonConvert.DeserializeObject<List<DCategoriasCiudadano>>(content);
                        return (listaCategoriasCiudadano, null);


                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error en la busqueda: {mensaje}");
                    }
                }



            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }

        }
    }
}
