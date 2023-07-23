using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CompanyWebApi.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Column("Company Name", TypeName = "varchar(200)")]
        public string? CompanyName { get; set; }
        
       
    }
}
