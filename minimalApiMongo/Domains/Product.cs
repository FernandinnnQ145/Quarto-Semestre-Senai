using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimalApiMongo.Domains
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? name { get; set; }

        [BsonElement("price")]
        public decimal? Price { get; set; }

        public Dictionary<string, string> AdditonalAtributes { get; set; }

        public Product() { 
            AdditonalAtributes = new Dictionary<string, string>();
        }

    }
}
