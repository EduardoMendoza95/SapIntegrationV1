using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;namespace Wee.SapIntegration.Core.Entities
{
    public class TokenLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AuthorizationBase64 { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}