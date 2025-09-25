using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class ProhibicinVisitaDaoImpl : IProhibicionVisitaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
                
        
        
        //BUSCAR PROHIBICION X ID
        public Task<(DProhibicionVisita, string error)> BuscarProhibicionVisitaXId(int idProhibicionvisita)
        {
            throw new NotImplementedException();
        }
        //FIN BUSCAR PROHIBICION X ID..........................................

        

        //RETORNAR LISTA DE PROHIBICIONES X CIUDADANO
        async public Task<(List<DProhibicionVisita>, string error)> RetornarProhibicionesVisitaXCiudadano(int idCiudadano)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            List<DProhibicionVisita> listaProhibiciones = new List<DProhibicionVisita>();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                                
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-visita/buscar-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionVisita>>(content);
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
        //FIN RETORNAR LISTA DE PROHIBICIONES X CIUDADANO...................................

        
    }
}
