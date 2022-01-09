using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestApiClient.Models
{
    public class ImportLog
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Импорт начат в")]
        [UIHint("TextReadOnly")]
        public DateTime StartImport { get; set; }

        [Display(Name = "Импорт закончен в")]
        [UIHint("TextReadOnly")]
        public DateTime EndImport { get; set; }


        [Display(Name = "Количество добавленных записей")]
        [UIHint("TextReadOnly")]
        public int SuccessCount { get; set; }

        [Display(Name = "Количество не добавленных записей")]
        [UIHint("TextReadOnly")]
        public int FailedCount { get; set; }

        [Display(Name = "Отчет")]
        [UIHint("Logs")]
        public List<ImportItemLog> Logs { get; set; }
    }
}
