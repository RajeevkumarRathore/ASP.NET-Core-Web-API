using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class CallLocation : IEntity
    {
        public int Id { get; set; }

        public string locationName { get; set; }

        public string fullAddress { get; set; }

        public string state { get; set; }
        [MaxLength(100)]
        public string city { get; set; }

        public string township { get; set; }

        public string cross { get; set; }
        [MaxLength(250)]
        public string street { get; set; }

        public string zip { get; set; }

        public string apt { get; set; }

        public string room { get; set; }

        public string floor { get; set; }

        public string entryCode { get; set; }

        [Column(TypeName = "decimal(18,12)")]
        public decimal? latitude { get; set; }

        [Column(TypeName = "decimal(18,12)")]
        public decimal? longitude { get; set; }

        public string google_apt { get; set; }

        public string google_street { get; set; }

        public string google_cross { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        public string cross1_name { get; set; }
        public decimal? cross1_lat { get; set; }
        public decimal? cross1_lng { get; set; }
        public string cross2_name { get; set; }
        public decimal? cross2_lat { get; set; }
        public decimal? cross2_lng { get; set; }
        public bool IsDeletedFromHistory { get; set; }
        public string stateShortName { get; set; }
        [MaxLength(100)]
        public string Area { get; set; }

        [NotMapped]
        public string addressFromLocationName { get; set; }
        public string Access { get; set; }
        [NotMapped]
        public bool? isFromAreaSearch { get; set; }
        [NotMapped]
        public List<string> otherCrossStreets { get; set; }
        [NotMapped]
        public bool? isHwy { get; set; }

    }
}
