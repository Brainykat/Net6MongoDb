﻿namespace CommonBase.Data.Entities
{
  public class Bank
  {
    public void AddBranch(string id, string code, string name) =>
      BankBranches.Add(BankBranch.Create(Guid.Parse(Id), id, code, name));
    internal static Bank Create(Guid nationId, string id, string code, string name) =>
      new Bank(nationId, id, code, name);
    private Bank(Guid nationId, string id, string code, string name)
    {
      Id = id ?? throw new ArgumentNullException(nameof(id));
      NationId = nationId;
      Code = code ?? throw new ArgumentNullException(nameof(code));
      Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    private Bank() { }
    public string Id { get; set; }
    public Guid NationId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public virtual Nation Nation { get; set; }
    public virtual ICollection<BankBranch> BankBranches { get; set; } = new List<BankBranch>();
  }
}