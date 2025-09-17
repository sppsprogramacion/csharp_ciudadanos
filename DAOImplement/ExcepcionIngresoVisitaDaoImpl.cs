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
    public class ExcepcionIngresoVisitaDaoImpl : IExcepcionIngresoVisitaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        
        //BUSCAR XID
        public Task<(DExcepcionIngresoVisita, string error)> BuscarExcepcionIngresoVisitaXId(int idExcepcionIngresoVisita)
        {
            throw new NotImplementedException();
        }
        //FIN BUSCAR XID...........................................................

        //LISTA DE EXCEPCIONES POR CIUDADANO
        public async Task<(List<DExcepcionIngresoVisita>, string error)> RetornarExcepcionesIngresoXCiudadano(int idCiudadano)
        {
            List<DExcepcionIngresoVisita> listaExcepcionesIngreso = new List<DExcepcionIngresoVisita>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/excepciones-ingreso-visita/lista-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaExcepcionesIngreso = JsonConvert.DeserializeObject<List<DExcepcionIngresoVisita>>(content);
                    return (listaExcepcionesIngreso, null);
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

        //FIN LISTA DE EXCEPCIONES POR CIUDADANO...................................................

        //LISTA EXCEPCIONES POR FECHA
        public async Task<(List<DExcepcionIngresoVisita>, string error)> ListaExcepcionesIngresoXFecha(string fechaExcepcion)
        {
            List<DExcepcionIngresoVisita> listaExcepcionesIngreso = new List<DExcepcionIngresoVisita>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/excepciones-ingreso-visita/lista-fecha?fecha_excpcion=" + fechaExcepcion);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaExcepcionesIngreso = JsonConvert.DeserializeObject<List<DExcepcionIngresoVisita>>(content);
                    return (listaExcepcionesIngreso, null);
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
        //FIN LISTA EXCEPCIONES POR FECHA
                

        //CUMPLIMENTAR EXCEPCION
        public async Task<(bool, string error)> CumplimentarExcepcion(int id, string dataCumplimentar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataCumplimentar, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/excepciones-ingreso-visita/cumplimentar?id_excepcion=" + id, content);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo cumplimentar la excepción");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al cumplimentar: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        
        //FIN CUMPLIMENTAR EXCEPCION................................................................
    }
}
