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
    public class NovedadCiudadanoDaoImpl : INovedadCiudadanoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR NOVEDAD
        public async Task<(DNovedadCiudadano, string error)> CrearNovedadCiudadano(string novedadCiudadano)
        {
            DNovedadCiudadano dataNovedad = new DNovedadCiudadano();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(novedadCiudadano, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/novedades-ciudadano", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataNovedad = JsonConvert.DeserializeObject<DNovedadCiudadano>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataNovedad, null);
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
        //FIN CREAR NOVEDAD

        public Task<(DNovedadCiudadano, string error)> BuscarNovedadCiudadanoXId(int idNovedad)
        {
            throw new NotImplementedException();
        }

        //LISTA DE NOVEDADES POR CIUDADANO
        public async Task<(List<DNovedadCiudadano>, string error)> RetornarNovedadesCiudadanoXCiudadano(int idCiudadano)
        {
            List<DNovedadCiudadano> listaNovedades = new List<DNovedadCiudadano>();

            try
            {
                
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/novedades-ciudadano/lista-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaNovedades = JsonConvert.DeserializeObject<List<DNovedadCiudadano>>(content);
                    return (listaNovedades, null);
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
        
        // FIN LISTA DE NOVEDADES POR CIUDADANO.................
    }
}
