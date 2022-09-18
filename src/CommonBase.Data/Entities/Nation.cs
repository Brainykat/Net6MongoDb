using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CommonBase.Data.Entities
{
  public class Nation: EntityBase
  {
    public static Nation Create(string id, string countryName, string currencyName, string currencySymbol, string currencyId, string phoneCode,
      decimal minInitialAmount) => 
      new Nation(id, countryName, currencyName, currencySymbol, currencyId, phoneCode,
        minInitialAmount);
    public Nation(string id, string countryName, string currencyName, string currencySymbol, string currencyId, string phoneCode,
      decimal minInitialAmount)
    {
      if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
      Id = id.ToString();
      CountryName = countryName ?? throw new ArgumentNullException(nameof(countryName));
      CurrencyName = currencyName ?? throw new ArgumentNullException(nameof(currencyName));
      CurrencySymbol = currencySymbol ?? throw new ArgumentNullException(nameof(currencySymbol));
      CurrencyId = currencyId ?? throw new ArgumentNullException(nameof(currencyId));
      PhoneCode = phoneCode ?? throw new ArgumentNullException(nameof(phoneCode));
      MinInitialAmount = minInitialAmount;
    }
    private Nation() { }
    //[BsonElement("Name")]
    //[JsonPropertyName("Name")]
    public string CountryName { get; set; } //": "Name",

    //[JsonPropertyName("Currency")]
    public string CurrencyName { get; set; } //": "Kenyan Shilling",

    //[JsonPropertyName("Currency")]
    public string CurrencySymbol { get; set; } //": "KSh",
    public string CurrencyId { get; set; } //": "KES",
    public string PhoneCode { get; set; } //": "+254"
    public decimal MinInitialAmount { get; set; } //15000
    public ICollection<Bank?> Banks { get; set; } = new List<Bank?>();
    public ICollection<County?> Counties { get; set; } = new List<County?>();
    public void AddCounty(string id,string code, string name) =>
      Counties.Add(County.Create(this.Id,id, code, name));
    public void AddBank(Bank bank) => Banks.Add(bank);
  }
}
