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
    public class TipoDefensorDaoImpl : ITipoDefensorDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public async Task<(List<DTipoDefensor>, string error)> MostrarTipoDefensor()
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            List<DTipoDefensor> listaTipoDefensor = new List<DTipoDefensor>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/tipos-defensor/todos");
                {
                    
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaTipoDefensor = JsonConvert.DeserializeObject<List<DTipoDefensor>>(content);
                        return (listaTipoDefensor, null);
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
