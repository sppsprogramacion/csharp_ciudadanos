using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class PaisDaolmpl : IPaisDao
            
    {//inicio clase
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public DPais buscarPaisXId(int id)
        {
            throw new NotImplementedException();
        }

        public int crearPais(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        public int crearPais(DPais usuario)
        {
            throw new NotImplementedException();
        }

        public int editarPais(DCiudadano usuario)
        {
            throw new NotImplementedException();
        }

        public int editarPais(DPais usuario)
        {
            throw new NotImplementedException();
        }

        async public Task<(List<DPais>, string error)> retornarListaPais()
            {
            //variable token
            string token = SessionManager.Token;
            List<DPais> listaPais = new List<DPais>();

           try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/paises/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaPais = JsonConvert.DeserializeObject<List<DPais>>(content);
                        return (listaPais, null);
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
    }//fin clase
}
