namespace CommonBase.Data.Entities
{
  public class BankBranch
  {
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid BankId { get; set; }
    public Bank Bank { get; set; }
    public BankBranch() { }
    internal static BankBranch Create(Guid bankId, string id, string code, string name) =>
      new BankBranch(bankId, id, code, name);
    internal BankBranch(Guid bankId, string id, string code, string name)
    {
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
