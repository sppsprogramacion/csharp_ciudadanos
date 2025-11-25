using CapaDatos;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class ProhibisionVisitaAnticipadaDaoImpl : IProhibicionVisitaAnticipadaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();


        //BUSCAR X ID
        public async Task<(DProhibicionAnticipada, string error)> BuscarProhibicionAnticipadaXId(int idProhibicionvisita)
        {
            DProhibicionAnticipada dProhibicion = new DProhibicionAnticipada();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-anticipadas/" + idProhibicionvisita);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dProhibicion = JsonConvert.DeserializeObject<DProhibicionAnticipada>(content);
                    return (dProhibicion, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
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
        //FIN BUSCAR X ID....................................................

        //LISTA X APELLIDO
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesAnticipadasXApellido(string apellido)
        {
            List<DProhibicionAnticipada> listaProhibiciones = new List<DProhibicionAnticipada>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-anticipadas/buscarlista-xapellido?apellido=" + apellido);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionAnticipada>>(content);
                    return (listaProhibiciones, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
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

        //FIN LISTA X APELLIDO..........................................................
        
        
    }
}
