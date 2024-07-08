using System.Text.Json.Serialization;


namespace AttandanceSystem.Models.ApiModels
{
    internal class AttendanceApiResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("shedIncharge_StaffNo")]
        public string ShedIncharge_StaffNo { get; set; }
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
        [JsonPropertyName("checkIn")]
        public string CheckIn { get; set; }
        [JsonPropertyName("checkInTime")]
        public string CheckInTime { get; set; }
        [JsonPropertyName("checkOut")]
        public object CheckOut { get; set; }
        [JsonPropertyName("checkOutTime")]
        public object CheckOutTime { get; set; }





       

    }




}
