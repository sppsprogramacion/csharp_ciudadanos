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
    public class NacionalidadDaolmpl: INacionalidadDao
    {//inicio de clase
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public DNacionalidad buscarNacionalidadXId(int id)
        {
            throw new NotImplementedException();
        }

        public int crearNacionalidad(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        public int editarNacionalidad(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        
        public async Task<(List<DNacionalidad>, string error)> retornarListaNacionalidad()
        {
            //variable token
            string token = SessionManager.Token;
            List<DNacionalidad> listaNacionalidad = new List<DNacionalidad>();
           
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                {
                                       
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/nacionalidades/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        listaNacionalidad = JsonConvert.DeserializeObject<List<DNacionalidad>>(contentRespuesta);
                        return (listaNacionalidad, null);

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
    }//fin d eclase
}
