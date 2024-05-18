using System.Text.Json.Serialization;


namespace AttandanceSystem.Models.ApiModels
{
    internal class LoginApiResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("SHED_ID")]
        public int SHED_ID { get; set; }
        [JsonPropertyName("SHED_NAME")]
        public string SHED_NAME { get; set; }
        [JsonPropertyName("Shed_Incharge_Name")]
        public string Shed_Incharge_Name { get; set; }
        [JsonPropertyName("Shed_Incharge_Address_Office")]
        public string Shed_Incharge_Address_Office { get; set; }
        [JsonPropertyName("Address_Home")]
        public string Address_Home { get; set; }
        [JsonPropertyName("ATTENDANCE_USER_ID")]
        public string ATTENDANCE_USER_ID { get; set; }
        [JsonPropertyName("Attendance_PASSWORD")]
        public string Attendance_PASSWORD { get; set; }
        [JsonPropertyName("Admin_tag")]
        public int Admin_tag { get; set; }
        [JsonPropertyName("SHED_LATITUDE")]
        public float SHED_LATITUDE { get; set; }
        [JsonPropertyName("SHED_LONGITUDE")]
        public float SHED_LONGITUDE { get; set; }
    }



    public class Rootobject
    {


    }



}
