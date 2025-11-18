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
using System.Collections;

namespace DAOImplement
{
    public class CiudadanosCategoriasDaoImpl : ICiudadanosCategoriasDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR CIUDADANOS CATEGORIAS
        public async Task<(DCiudadanosCategorias, string error)> crearCiudadanosCategorias(string ciudadanosCategorias)
        {//inicio crear ciudadano categoria
         //variable token
         string token = SessionManager.Token;
         DCiudadanosCategorias dataCiuddanosCategorias = new DCiudadanosCategorias();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadanosCategorias, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/ciudadanos-categorias", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataCiuddanosCategorias = JsonConvert.DeserializeObject<DCiudadanosCategorias>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataCiuddanosCategorias, null);
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


        }//FIN CREAR CIUDADANOS CATEGORIAS

        

        //LISTA DE CATEGORIAS VIGENTES DEL CIUDADANO
        public async Task<(List<DCiudadanosCategorias>, string error)> retornarListaCategoriasVigentesXCiudadano(int id_ciudadano)
        {
            
            //variable token
            string token = SessionManager.Token;
            List<DCiudadanosCategorias> listaCiudadanosCategorias = new List<DCiudadanosCategorias>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/ciudadanos-categorias/lista-vigentes-xciudadano?id_ciudadano=" + id_ciudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaCiudadanosCategorias = JsonConvert.DeserializeObject<List<DCiudadanosCategorias>>(content);

                    return (listaCiudadanosCategorias, null);

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
        //FIN LISTA DE CATEGORIAS VIGENTES DEL CIUDADANO........................................................


        //QUITAR CATEGORIA
        public async Task<(bool, string error)> QuitarCategoria(int id, string dataQuitar)
        {
            //variable token
            string token = SessionManager.Token;

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataQuitar, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/ciudadanos-categorias/quitar-vigente?id_ciudadano_categoria=" + id, content);

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
                        return (false, "No se pudo quitar la categoria");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al quitar la categoria: {mensaje}");
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
        //FIN QUITAR CATEGORIA......................................................

        //INICIO LISTA DE CATEGORIAS POR CIUDADANO
        public async Task<(List<DCiudadanosCategorias>, string error)> retornarListaCategoriasHistoricasXCiudadano(int id_ciudadano)
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            List<DCiudadanosCategorias> listaCiudadanosCategorias = new List<DCiudadanosCategorias>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/ciudadanos-categorias/lista-xciudadano?id_ciudadano=" + id_ciudadano);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaCiudadanosCategorias = JsonConvert.DeserializeObject<List<DCiudadanosCategorias>>(content);

                    return (listaCiudadanosCategorias, null);

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
        //FIN LISTA DE CATEGORIAS POR CIUDADNO
    }
}
