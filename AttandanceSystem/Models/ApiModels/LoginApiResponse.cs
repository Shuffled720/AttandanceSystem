using System.Text.Json.Serialization;


namespace AttandanceSystem.Models.ApiModels
{
    internal class LoginApiResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("shedIncharge_StaffNo")]
        public string SedIncharge_StaffNo { get; set; }
        [JsonPropertyName("contactNo")]
        public string ContactNo { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("attendanceUserId")]
        public string AttendanceUserId { get; set; }
        [JsonPropertyName("adminTag")]
        public bool AdminTag { get; set; }
        [JsonPropertyName("zonalRLY")]
        public string ZonalRLY { get; set; }
        [JsonPropertyName("shed_Name")]
        public string Shed_Name { get; set; }
        [JsonPropertyName("shed_Latitude")]
        public string Shed_Latitude { get; set; }
        [JsonPropertyName("shed_Longitude")]
        public string Shed_Longitude { get; set; }
    }




    public class Rootobject
    {
        public string shedIncharge_StaffNo { get; set; }
        public string contactNo { get; set; }
        public string name { get; set; }
        public string attendanceUserId { get; set; }
        public bool adminTag { get; set; }
        public string zonalRLY { get; set; }
        public string shed_Name { get; set; }
        public string shed_Latitude { get; set; }
        public string shed_Longitude { get; set; }
    }



}
