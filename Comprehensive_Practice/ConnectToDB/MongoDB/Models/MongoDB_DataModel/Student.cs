using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB.Models.MongoDB_DataModel
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string? name { get; set; }
        public int? age { get; set; }
        public string? grade { get; set; }

    }
}
