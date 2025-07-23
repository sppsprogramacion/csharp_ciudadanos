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
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class OrganismoDestinoDaoImpl : IOrganismoDestino
    {
        private string url_base = MiConexion.getConexion();

        public async Task<List<DOrganismoDestino>> retornarOrganismoDestinoListaxUsuario(int id_organismo_destino)
        {
            HttpClient httpClient = new HttpClient();
            List<DOrganismoDestino> listaOrganismoDestino = new List<DOrganismoDestino>();
            string token = SessionManager.Token; // Aquí pones tu token real

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var httpResponse = await httpClient.GetAsync(url_base + "/organismos-destino/lista-xusuario");

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaOrganismoDestino = JsonConvert.DeserializeObject<List<DOrganismoDestino>>(content);





            }

            return listaOrganismoDestino;

        }

       

        public async Task<List<DOrganismoDestino>> retornarOrganismoDestinoTodos()
        {
            //throw new NotImplementedException();
            HttpClient httpClient = new HttpClient();
            List<DOrganismoDestino> listaOrganismoDestino = new List<DOrganismoDestino>();

            var httpResponse = await httpClient.GetAsync(url_base + "/organismos-destino/todos");

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                listaOrganismoDestino = JsonConvert.DeserializeObject<List<DOrganismoDestino>>(content);

            }

            return listaOrganismoDestino;
        }
    }
}
