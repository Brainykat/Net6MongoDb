using System.ComponentModel.DataAnnotations;

namespace CommonBase.Data.Dtos
{
  public class NationDto
  {
    [Required]
    [MaxLength(24)]
    [MinLength(24)]
    public string Id { get; set; }
    [Required]
    public string CountryName { get; set; } //": "Name",
    [Required]
    public string CurrencyName { get; set; } //": "Kenyan Shilling",
    [Required]
    public string CurrencySymbol { get; set; } //": "KSh",
    [Required]
    public string CurrencyId { get; set; } //": "KES",
    [Required]
    public string PhoneCode { get; set; } //": "+254"
    public decimal MinInitialAmount { get; set; } //15000
  }
}
