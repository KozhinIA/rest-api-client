using System;

namespace RestApiClient.Models
{
    public class ImportItemLog
    {
        //public int Id { get; set; }
        public string Message { get; set; }
        public ImportItemLogType Type { get; set; }
    }
}
