using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWebApi.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Column("Contact Name", TypeName = "varchar(200)")]
        public string? ContactName { get; set; }

        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
