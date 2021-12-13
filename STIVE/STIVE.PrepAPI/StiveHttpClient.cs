using Newtonsoft.Json;
using STIVE.PrepAPI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI
{
	public class StiveHttpClient : HttpClient
	{
		public StiveHttpClient()
		{
			this.BaseAddress = new Uri("https://localhost:5001/api/");
		}
		public async Task<T> GetAsync<T>(string uri)
		{
			HttpResponseMessage response = await GetAsync(uri);
			string jsonResponse = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		public async Task<T> PostAsync<U, T>(string uri, U elem) where U : IApiModelBase
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PostAsync(uri, content);
			string jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		public async Task PutAsync<U, T>(string uri, U elem) where U : IApiModelBase
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PutAsync(uri, content);
		}

		public async Task CustomDeleteAsync(string uri)
		{
			HttpResponseMessage response = await DeleteAsync(uri);
		}
	}
}
