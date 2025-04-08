using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.Models
{
    public partial class Department : BaseEntity
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Code { get; set; } = null;

        [BsonElement("Name")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
