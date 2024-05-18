using System.Text.Json.Serialization;


namespace AttandanceSystem.Models.ApiModels
{
    internal class AttendanceApiResponse
    {
        [JsonPropertyName("fieldCount")]
        public int FieldCount { get; set; }
        [JsonPropertyName("affectedRows")]
        public int AffectedRows { get; set; }
        [JsonPropertyName("insertId")]
        public int InsertId { get; set; }
        [JsonPropertyName("serverStatus")]
        public int ServerStatus { get; set; }
        [JsonPropertyName("warningCount")]
        public int WarningCount { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("protocol41")]
        public bool Protocol41 { get; set; }
        [JsonPropertyName("changedRows")]
        public int ChangedRows { get; set; }

    }




}
