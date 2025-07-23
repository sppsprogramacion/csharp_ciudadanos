using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class SectoresDestinoDaoImpl : ISectoresDestino
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        async public Task<(List<DSectoresDestino>, string error)> RetornarListaSectoresXOrganismo(int id_organismo_destino)
        {
            //variable token
            string token = SessionManager.Token;
            List<DSectoresDestino> listaSectoresDestino = new List<DSectoresDestino>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/sectores-destino/lista-xorganismo?id_organismo=" + id_organismo_destino);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        listaSectoresDestino = JsonConvert.DeserializeObject<List<DSectoresDestino>>(contentRespuesta);
                        return (listaSectoresDestino, null);
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
