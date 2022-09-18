using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CommonBase.Data.Entities
{
  public class EntityBase
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
  }
}
