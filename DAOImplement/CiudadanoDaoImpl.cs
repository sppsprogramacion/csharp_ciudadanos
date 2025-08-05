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
using System.IO;
using System.Security.Cryptography;

namespace DAOImplement
{
    public class CiudadanoDaoImpl : ICiudadanoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public DCiudadano buscarCiudadanoXDni(int dni)
        {
            throw new NotImplementedException();
        }

        public async Task<(DCiudadano, string error)> buscarCiudadanoXId(int id)
        {
            //variable token
            string token = SessionManager.Token;
            DCiudadano dCiudadano = new DCiudadano();
            //throw new NotImplementedException();
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/" + id);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        dCiudadano = JsonConvert.DeserializeObject<DCiudadano>(content);
                        return (dCiudadano, null);
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

        //public DCiudadano buscarCiudadanoXId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<(DCiudadano, string error)> crearCiudadano(string ciudadano)
        {
            //variable token
            string token = SessionManager.Token;
            DCiudadano dCiudadano = new DCiudadano();
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/ciudadanos", content);
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        dCiudadano = JsonConvert.DeserializeObject<DCiudadano>(contentRespuesta);

                        // Puedes procesar el token o el resultado adicional aquí.
                        // Establecer el usuario actual
                        return (dCiudadano, null);
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

        public int editarCiudadano(DCiudadano ciudadano)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> editarCiudadanoDni(int id, string ciudadano)

        {//inicio metodo editar objeto

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/ciudadanos/update-domicilio?id_ciudadano=" + id, content);


                return httpResponse;

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





        }//fin metodo editar objeto

        public DataTable retornarCiudadanosTodos()
        {
            throw new NotImplementedException();
        }


        public async Task<(List<DCiudadano>, string error)> retornarListaCiudadanoXApellido(string apellido)
        {
            //variable token
            string token = SessionManager.Token;
            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            { //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/buscarlista-xapellido?apellido=" + apellido);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(content);
                        return (listaCiudadanos, null);
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



        public async Task<(List<DCiudadano>, string error)> retornarListaCiudadano()
        {//inicio funcion Retornoar Lista de Ciudadanos

            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(content);
                        return (listaCiudadanos, null);


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




        }//fin funcion Retornar Lista de Ciudadanos

        public async Task<(List<DCiudadano>, string error)> retornarListaCiudadanoXDni(int dni)
        {//inicio funvion retornar listrado x dni
            //variable token
            string token = SessionManager.Token;
            List<DCiudadano> listaCiudadanos = new List<DCiudadano>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(Convert.ToString(dni), Encoding.UTF8, "application/json");

                //HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/" + dni);
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/ciudadanos/buscarlista-xdni?dni=" + dni);
                {

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentt = await httpResponse.Content.ReadAsStringAsync();
                        listaCiudadanos = JsonConvert.DeserializeObject<List<DCiudadano>>(contentt);
                        return (listaCiudadanos, null);
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





        }//fin funcion retornar listado x dni

        public async Task<HttpResponseMessage> editarDatosPersonales(int id, string ciudadano)
        {

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/ciudadanos/update-datos-personales?id_ciudadano=" + id, content);

                return httpResponse;

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

        //ESTABLCER VISITA
        public async Task<(bool, string error)> establecerVisita(int id, string ciudadano)
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/ciudadanos/establecer-visita?id_ciudadano=" + id, content);

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
                        return (false, "No se pudo establecer como visita");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en establecer como visita: {mensaje}");
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

        //FIN ESTABLECER VISITA

        //ESTABLECER DISCAACIDAD
        public async Task<(bool, string error)> establecerDiscapacidad(int id, string ciudadano)
        {
            //throw new NotImplementedException();
            //variable token
            string token = SessionManager.Token;
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(ciudadano, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/ciudadanos/establecer-discapacidad?id_ciudadano=" + id, content);

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
                        return (false, "No se pudo establecer con discapacidad");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en establecer la discapacidad: {mensaje}");
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

        public async Task<(bool, string error)> subirImagen(int id, string rutaImagen)
        {
            string token = SessionManager.Token;

            if (!File.Exists(rutaImagen))
                return (false, "No se encontró el archivo de imagen.");

            try
            {
                using (var form = new MultipartFormDataContent())
                using (var imageContent = new ByteArrayContent(File.ReadAllBytes(rutaImagen)))
                {
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    form.Add(imageContent, "file", Path.GetFileName(rutaImagen));

                    // Agregar token a la cabecera
                    this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string url = $"{url_base}/ciudadanos/upload-img-ciudadano?id_ciudadano={id}";
                    var response = await this.httpClient.PostAsync(url, form);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(responseContent)["message"]?.ToString();
                        return (false, $"Error al subir la imagen: {mensaje}");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                return (false, $"Error en la solicitud: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
    }

}
