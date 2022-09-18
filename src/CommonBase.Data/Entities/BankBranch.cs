namespace CommonBase.Data.Entities
{
  public class BankBranch :EntityBase
  {
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid BankId { get; set; }
    public Bank Bank { get; set; }
    public BankBranch() { }
    internal static BankBranch Create(Guid bankId, Guid id, string code, string name) =>
      new BankBranch(bankId, id, code, name);
    internal BankBranch(Guid bankId, Guid id, string code, string name)
    {
      if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));
      Id = id;
      if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
      if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
      if (bankId == Guid.Empty) throw new ArgumentNullException(nameof(bankId));
      Code = code;
      Name = name;
      BankId = bankId;
    }
  }
}
