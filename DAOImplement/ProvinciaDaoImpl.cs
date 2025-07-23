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
    public class ProvinciaDaoImpl : IProvinciaDao
    {//inicio clase
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public DProvincia buscarProvinciaXId(int id)
        {
            throw new NotImplementedException();
        }

        public int crearProvincia(DProvincia usuario)
        {
            throw new NotImplementedException();
        }

        public int editarProvincia(DProvincia usuario)
        {
            throw new NotImplementedException();
        }



        //public Task<List<DProvincia>> retornarListaProvincia()
        //{
        //    throw new NotImplementedException();
        //}

        async public Task<(List<DProvincia>, string error)> retornarListaProvinciasXPais(string id_pais)
        {
            //variable token
            string token = SessionManager.Token;
            List<DProvincia> listaProvincia = new List<DProvincia>();
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/provincias/buscar-xpais?id_pais=" + id_pais);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        listaProvincia = JsonConvert.DeserializeObject<List<DProvincia>>(contentRespuesta);
                        return (listaProvincia, null);
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

        //public Task<List<DProvincia>> retornarListaProvinciasXPais(string id_pais)
        //{
        //    throw new NotImplementedException();
        //}
    }//fin clase
}
