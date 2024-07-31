using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalApiMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("status")]
        public bool? Status { get; set; }

        //Referencia aos produtos do pedido

        [BsonElement("productId")]
        public List<string>? ProductId { get; set; }
        public List<Product>? Products { get; set; }


        //Referencia ao cliente que esta fazendo pedido
        [BsonElement("clientId")]
        [BsonIgnore]
        public string? ClientId { get; set; }

        public Client? Client { get; set; }


        
    }
}

