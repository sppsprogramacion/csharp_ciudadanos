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
    public class InternoDaoImpl : IInternoDao
    {

        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public async Task<(List<DInterno>, string error)> retornarListaInternoXApellido(string apellido)
        {
            //variable token
            string token = SessionManager.Token;
            List<DInterno> listaInternos = new List<DInterno>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(apellido, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/internos/buscarlista-xapellido?apellido=" + apellido);

                

                if (httpResponse.IsSuccessStatusCode)
                {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        listaInternos = JsonConvert.DeserializeObject<List<DInterno>>(contentRespuesta);
                        return (listaInternos, null);
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

        //Task<List<DInterno>> IInternoDao.retornarListaInternoXApellido(string apellido)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
