using System.ComponentModel.DataAnnotations;

namespace ngSpa.Model.Requests
{
    public class ScrapeAddRequest
    {
        [Required]
        public string ScrapedData { get; set; }

        [Required]
        public string ModifiedBy { get; set; }
    }
}
