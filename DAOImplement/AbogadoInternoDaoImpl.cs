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
    public class AbogadoInternoDaoImpl : IAbogadoInternoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public async Task<(DAbogadoInterno, string error)> asignarAbogadoInterno(string abogadoInterno)
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            DAbogadoInterno abgadoInternos = new DAbogadoInterno();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(abogadoInterno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/abogados-interno", content);
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        abgadoInternos = JsonConvert.DeserializeObject<DAbogadoInterno>(contentRespuesta);

                        // Puedes procesar el token o el resultado adicional aquí.
                        // Establecer el usuario actual
                        return (abgadoInternos, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error al crear: {mensaje}");
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

        public async Task<(DAbogadoInterno, string error)> crearRegistroAbogado(string abogadoInterno)
        {
            //throw new NotImplementedException();
            DAbogadoInterno dataAbogadoInterno = new DAbogadoInterno();
            //variable token
            string token = SessionManager.Token;

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(abogadoInterno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/api/abogados-interno", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataAbogadoInterno = JsonConvert.DeserializeObject<DAbogadoInterno>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataAbogadoInterno, null);
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

        public async Task<(List<DAbogadoInterno>, string error)> retornarListaInternosXId(int idAbogado)
        {
            //throw new NotImplementedException();
            List<DAbogadoInterno> listaAbogadoInternos = new List<DAbogadoInterno>();
            //variable token
            string token = SessionManager.Token;

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/abogados-interno/lista-vigentes-xciudadano?id_ciudadano=" + idAbogado);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaAbogadoInternos = JsonConvert.DeserializeObject<List<DAbogadoInterno>>(content);
                        return (listaAbogadoInternos, null);
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
