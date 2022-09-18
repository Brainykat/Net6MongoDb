namespace CommonBase.Data.Entities
{
  public class Bank : EntityBase
  {
    public void AddBranch(Guid id, string code, string name) =>
      BankBranches.Add(BankBranch.Create(this.Id, id, code, name));
    internal static Bank Create(Guid nationId, Guid id, string code, string name) =>
      new Bank(nationId, id, code, name);
    private Bank(Guid nationId, Guid id, string code, string name)
    {
      if(id==Guid.Empty) throw new ArgumentNullException(nameof(id));
      Id = id;
      NationId = nationId;
      Code = code ?? throw new ArgumentNullException(nameof(code));
      Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    private Bank() { }
    public Guid NationId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public virtual Nation Nation { get; set; }
    public virtual ICollection<BankBranch> BankBranches { get; set; } = new List<BankBranch>();
  }
}
