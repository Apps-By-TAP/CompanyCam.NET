using CompanyCam.NET.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using static CompanyCam.NET.Utils.Utils;
using System.Text.Json;

namespace CompanyCam.NET.Services
{
    public class ProjectService
    {
        private RestClient _client;

        public ProjectService(RestClient client)
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

            RestRequest request = new RestRequest($"projects{queryString}");
            return await _client.GetAsync<List<Project>>(request);
        }

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="userEmail">Email of CompanyCam user to be designated as the creator</param>
        /// <param name="createProjectRequest">The project request object</param>
        /// <returns>CreateProjectResponse</returns>
        public async Task<CreateProjectResponse> CreateProjectAsync(string userEmail, CreateProjectRequest createProjectRequest)
        {
            RestRequest request = new RestRequest("projects");
            request.AddHeader("accept", "application/json");
            request.AddHeader("X_COMPANYCAM_USER", userEmail);
            request.AddJsonBody(JsonSerializer.Serialize(createProjectRequest));

            var response = await _client.PostAsync(request);

            if (response.IsSuccessful)
            {
                CreateProjectResponse result = JsonSerializer.Deserialize<CreateProjectResponse>(response.Content);
                result.Success = true;
                return result;
            }
            else
            {
                return new CreateProjectResponse
                {
                    Success = false,
                    Error = response.Content
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
            RestRequest request = new RestRequest($"projects/{projectId}");
            request.AddHeader("accept", "application/json");
            try
            {
                return (await _client.DeleteAsync(request)).IsSuccessful;
            }
            catch
            {
                return false;
            }
        }
    }
}
