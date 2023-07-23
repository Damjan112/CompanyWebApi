using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWebApi.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Column("Country Name", TypeName = "varchar(200)")]
        public string? CountryName { get; set; }
    }
}
