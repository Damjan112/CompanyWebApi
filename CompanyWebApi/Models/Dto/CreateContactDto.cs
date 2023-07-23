namespace CompanyWebApi.Models.Dto
{
    public class CreateContactDto
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
