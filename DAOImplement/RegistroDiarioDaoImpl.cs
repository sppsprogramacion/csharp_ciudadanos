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
    public class RegistroDiarioDaoImpl : IRegistroDiarioDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public async Task<(DRegistroDiario, string error)> crearRegistroDiario(string registroDiario)
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            DRegistroDiario registroDiarios= new DRegistroDiario();
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(registroDiario, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/registro-diario", content);
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        registroDiarios = JsonConvert.DeserializeObject<DRegistroDiario>(contentRespuesta);
                        return (registroDiarios, null);
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
                throw new Exception($"Error al realizar la solicitud: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON
                throw new Exception($"Error al serializar/deserializar JSON: {jsonException.Message}");
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro tipo de excepción
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                throw new Exception($"Ocurrió un error inesperado: {ex.Message}");
            }
        }
    }
}
