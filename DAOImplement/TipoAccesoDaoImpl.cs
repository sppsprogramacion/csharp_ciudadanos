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
using CommonCache;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class TipoAccesoDaoImpl : ITipoAcceso
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public async Task<(List<DTipoAcceso>, string error)> retornarTipoAcceso()
        {
            //variable token
            string token = SessionManager.Token;
            List<DTipoAcceso> listaTipoAcceso = new List<DTipoAcceso>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/tipos-acceso/todos");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        listaTipoAcceso = JsonConvert.DeserializeObject<List<DTipoAcceso>>(contentRespuesta);
                        return (listaTipoAcceso, null);
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
