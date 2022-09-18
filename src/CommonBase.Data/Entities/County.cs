namespace CommonBase.Data.Entities
{
  public class County :EntityBase
  {
    public string Code { get; set; }
    public string Name { get; set; }
    public string NationId { get; set; }
    private County() { }
    private County(string nationId, string id, string code, string name)
    {
      if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
      if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
      if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id)); 
      Id = id.ToString();
      NationId = nationId;
      Name = name.Trim(); Code = code.Trim();
    }
    public static County Create(string nationId, string id, string code, string name)
    {
      return new County(nationId,id, code, name);
    }
  }
}
