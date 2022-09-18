namespace CommonBase.Data.Entities
{
  public class Nation: EntityBase
  {
    public Nation(Guid id, string countryName, string currencyName, string currencySymbol, string currencyId, string phoneCode,
      decimal minInitialAmount)
    {
      if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));
      Id = id;
      CountryName = countryName ?? throw new ArgumentNullException(nameof(countryName));
      CurrencyName = currencyName ?? throw new ArgumentNullException(nameof(currencyName));
      CurrencySymbol = currencySymbol ?? throw new ArgumentNullException(nameof(currencySymbol));
      CurrencyId = currencyId ?? throw new ArgumentNullException(nameof(currencyId));
      PhoneCode = phoneCode ?? throw new ArgumentNullException(nameof(phoneCode));
      MinInitialAmount = minInitialAmount;
    }
    private Nation() { }
    public string CountryName { get; set; } //": "Name",
    public string CurrencyName { get; set; } //": "Kenyan Shilling",
    public string CurrencySymbol { get; set; } //": "KSh",
    public string CurrencyId { get; set; } //": "KES",
    public string PhoneCode { get; set; } //": "+254"
    public decimal MinInitialAmount { get; set; } //15000
    public ICollection<Bank> Banks { get; set; } = new List<Bank>();
    public ICollection<County> Counties { get; set; } = new List<County>();
    public void AddCounty(Guid id,string code, string name) =>
      Counties.Add(County.Create(this.Id,id, code, name));
    public void AddBank(Bank bank) => Banks.Add(bank);
  }
}
