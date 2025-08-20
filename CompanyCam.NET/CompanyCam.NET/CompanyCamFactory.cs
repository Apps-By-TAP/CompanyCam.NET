using CompanyCam.NET.Models;
using CompanyCam.NET.Services;
using System;
using System.Net.Http;

namespace CompanyCam.NET
{
    public class CompanyCamFactory
    {
        private HttpClient _httpClient;

        public CompanyCamFactory(CompanyCamConfiguration configuration)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(configuration.CompanyCampUrl) };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration.AccessToken}");
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
        }

        public ProjectService CreateProjectService() => new ProjectService(_httpClient);
        public PhotoService CreatePhotoService() => new PhotoService(_httpClient);
    }
}
