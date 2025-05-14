using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCam.NET.Models
{
    public class CompanyCamConfiguration
    {
        public string AccessToken { get; set; }
        public string CompanyCampUrl { get; } = "https://api.companycam.com/v2/";
    }
}
