using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TareasITIC91.Data
{
    public class TareaManager
    {
        const string url = "http://192.168.100.10:3000/tareas/";

        public async Task<IEnumerable<Tarea>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Tarea>>(result);
        }

        public async Task<Tarea> Add(string titulo, string detalle, Date fecha)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle, 
                Fecha = fecha,
            };

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tarea>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task Delete(string Id)
        {
            HttpClient client = new HttpClient();

            var response = await client.DeleteAsync(url + Id);
        }
    }
}
