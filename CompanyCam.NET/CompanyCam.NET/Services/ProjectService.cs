using CompanyCam.NET.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CompanyCam.NET.Utils.Utils;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace CompanyCam.NET.Services
{
    public class ProjectService
    {
        private HttpClient _client;

        internal ProjectService(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Lists all projects
        /// </summary>
        /// <param name="page">Which page number</param>
        /// <param name="perPage">How many results per page</param>
        /// <param name="query">Filter projects by name or address line 1</param>
        /// <param name="modifiedSince">Filter projects modified on or after the provided value</param>
        /// <returns>List<Project></returns>
        public async Task<List<Project>> GetProjectsAsync(int page = -1, int perPage = -1, string query = "", DateTime? modifiedSince = null)
        {
            string queryString = string.Empty;

            if(page >= 0) queryString = AddQueryParameter(queryString, "page", page.ToString());
            if(perPage >= 0) queryString = AddQueryParameter(queryString, "per_page", perPage.ToString());
            if (!string.IsNullOrEmpty(query)) queryString = AddQueryParameter(queryString, "query", query);
            if (modifiedSince.HasValue) queryString = AddQueryParameter(queryString, "modified_since", modifiedSince.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));

            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");
            _client.DefaultRequestHeaders.Remove("accept");

            var response = await _client.GetAsync($"projects{queryString}");

            if(response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<Project>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return new List<Project>();
            }
        }

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="userEmail">Email of CompanyCam user to be designated as the creator</param>
        /// <param name="createProjectRequest">The project request object</param>
        /// <returns>CreateProjectResponse</returns>
        public async Task<CreateProjectResponse> CreateProjectAsync(string userEmail, CreateProjectRequest createProjectRequest)
        {
            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");
            _client.DefaultRequestHeaders.Remove("accept");

            _client.DefaultRequestHeaders.Add("accept", "application/json");
            _client.DefaultRequestHeaders.Add("X_COMPANYCAM_USER", userEmail);

            HttpResponseMessage response = null;


            response = await _client.PostAsJsonAsync("projects", createProjectRequest);

            if (response.IsSuccessStatusCode)
            {
                CreateProjectResponse result = await response.Content.ReadFromJsonAsync<CreateProjectResponse>();
                result.Success = true;
                return result;
            }
            else
            {
                return new CreateProjectResponse
                {
                    Success = false,
                    Error = await response.Content.ReadAsStringAsync()
                };
            }
        }
    
        /// <summary>
        /// Deletes a project
        /// </summary>
        /// <param name="projectId">The Project ID</param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteProjectAsync(string projectId)
        {
            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");
            _client.DefaultRequestHeaders.Remove("accept");

            _client.DefaultRequestHeaders.Add("accept", "application/json");

            HttpResponseMessage response = await _client.DeleteAsync($"projects/{projectId}");

            return response.IsSuccessStatusCode;
        }
    }
}
