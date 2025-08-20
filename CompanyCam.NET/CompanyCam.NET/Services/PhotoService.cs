using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using static CompanyCam.NET.Utils.Utils;

namespace CompanyCam.NET.Services
{
    public  class PhotoService
    {
        private HttpClient _client;

        internal PhotoService(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves tags for a specific photo
        /// </summary>
        /// <param name="photoId">Photo ID</param>
        /// <param name="page">Which tag page</param>
        /// <param name="perPage">Number of tags per page</param>
        /// <returns></returns>
        public async Task<List<string>> ListPhotoTagsAsync(string photoId, int page = -1, int perPage = -1)
        {
            string queryString = string.Empty;

            if (page >= 0) queryString = AddQueryParameter(queryString, "page", page.ToString());
            if (perPage >= 0) queryString = AddQueryParameter(queryString, "per_page", perPage.ToString());

            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");

            var response = await _client.GetAsync($"photos/{photoId}/tags{queryString}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<string>>();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
