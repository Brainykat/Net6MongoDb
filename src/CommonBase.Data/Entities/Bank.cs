namespace CommonBase.Data.Entities
{
  public class Bank : EntityBase
  {
    public void AddBranch(string id, string code, string name) =>
      BankBranches.Add(BankBranch.Create(this.Id, id, code, name));
    internal static Bank Create(string nationId, string id, string code, string name) =>
      new Bank(nationId, id, code, name);
    private Bank(string nationId, string id, string code, string name)
    {
      if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
      Id = id.ToString();
      NationId = nationId;
      Code = code ?? throw new ArgumentNullException(nameof(code));
      Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    private Bank() { }
    public string NationId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public virtual Nation Nation { get; set; }
    public virtual ICollection<BankBranch> BankBranches { get; set; } = new List<BankBranch>();
  }
}
