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
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace DAOImplement
{
    public class VisitaInternoDaoImpl : IVisitaInternoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public async Task<(DVisitaInterno, string error)> crearVisitaInterno(string visitainterno)
           
        {
            //throw new NotImplementedException();

            //variable token
            string token = SessionManager.Token;
            DVisitaInterno dataVisitaInterno = new DVisitaInterno();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(visitainterno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/visitas-internos", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataVisitaInterno = JsonConvert.DeserializeObject<DVisitaInterno>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataVisitaInterno, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error al crear: {mensaje}");
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

        public async Task<(List<DVisitaInterno>, string error)> retornarListaVisitaInternoXCiudadano(int id_ciudadano)
            {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            List<DVisitaInterno> listaVisitasInternos = new List<DVisitaInterno>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/visitas-internos/buscarlista-xciudadano?id_ciudadano=" + id_ciudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaVisitasInternos = JsonConvert.DeserializeObject<List<DVisitaInterno>>(content);
                    return (listaVisitasInternos, null);


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
    }
}
