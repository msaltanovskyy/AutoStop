using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class BusyPlaces
    {
        [Key]
        public int Number { get; set; }
        [Display(Name = "Номер поездки")]
        public int TravelId { get; set; }
        public Travels Traverl { get; set; }
        [Display(Name = "Коло-во мест")]
        [Range(1,99,ErrorMessage = "Range 1-99")]
        public int BusyPlace { get; set; }
        [Display(Name = "Индификатор акк")]
        public string AccountId { get; set; }
        public Accounts Accounts { get; set; }  
    }
}
