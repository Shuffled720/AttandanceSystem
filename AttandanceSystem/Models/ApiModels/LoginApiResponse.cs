﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AttandanceSystem.Models.ApiModels
{
    internal class LoginApiResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("shedName")]
        public string ShedName { get; set; }
        [JsonPropertyName("shedLocation_Lat")]
        public double ShedLocation_Lat { get; set; }
        [JsonPropertyName("shedLocation_Long")]
        public double ShedLocation_Long { get; set; }
    }



}
