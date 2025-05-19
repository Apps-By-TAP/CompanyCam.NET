using CompanyCam.NET.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CompanyCam.NET.Utils.Utils;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections;

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

            var response = await _client.GetAsync($"projects{queryString}");

            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Project>>();
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


            HttpResponseMessage response = await _client.DeleteAsync($"projects/{projectId}");

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Retrieves a project by ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Project</returns>
        public async Task<Project> RetrieveProject(string projectId)
        {
            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");

            var response = await _client.GetAsync($"projects/{projectId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Project>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lists all photos for a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="userIDs"></param>
        /// <param name="groupIds"></param>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task<List<Photo>> ListPhotos(string projectId, int page = -1, int perPage = -1, 
            DateTime? startDate = null, DateTime? endDate = null, List<string> userIDs = null, 
            List<string> groupIds = null, List<string> tagIds = null)
        {

            string queryString = string.Empty;

            if (page >= 0) queryString = AddQueryParameter(queryString, "page", page.ToString());
            if (perPage >= 0) queryString = AddQueryParameter(queryString, "per_page", perPage.ToString());
            if (startDate.HasValue) queryString = AddQueryParameter(queryString, "start_date", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (endDate.HasValue) queryString = AddQueryParameter(queryString, "end_date", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if(userIDs is not null && userIDs.Count > 0) AddQueryParameter(queryString, "user_ids", string.Join(",", userIDs));
            if (groupIds is not null && groupIds.Count > 0) AddQueryParameter(queryString, "group_ids", string.Join(",", groupIds));
            if (tagIds is not null && tagIds.Count > 0) AddQueryParameter(queryString, "tag_ids", string.Join(",", tagIds));

            _client.DefaultRequestHeaders.Remove("X_COMPANYCAM_USER");

            var response = await _client.GetAsync($"projects/{projectId}/photos{queryString}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Photo>>();
            }
            else
            {
                return new List<Photo>();
            }
        }
    }
}
