using CompanyCam.NET.Models;
using CompanyCam.NET.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CompanyCam.NET
{
    public class CompanyCamFactory
    {
        private HttpClient _httpClient;

        public CompanyCamFactory(CompanyCamConfiguration configuration)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(configuration.CompanyCampUrl) };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration.AccessToken}");
        }

        public ProjectService CreateProjectService() => new ProjectService(_httpClient);
    }
}
