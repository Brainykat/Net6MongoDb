namespace CommonBase.Data.Entities
{
  public class County
  {
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid NationId { get; set; }
    private County() { }
    private County(Guid nationId, string code, string name)
    {
      if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
      if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
      Id = Guid.NewGuid().ToString();
      NationId = nationId;
      Name = name.Trim(); Code = code.Trim();
    }
    public static County Create(Guid nationId, string code, string name)
    {
      return new County(nationId, code, name);
    }
  }
}
