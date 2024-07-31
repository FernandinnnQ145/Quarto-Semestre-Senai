using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalApiMongo.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("userId")]
        public string? UserId { get; set; }

        public Dictionary<string, string> AdditonalAtributes { get; set; }

        public Client()
        {
            AdditonalAtributes = new Dictionary<string, string>();
        }

        
    }
}
