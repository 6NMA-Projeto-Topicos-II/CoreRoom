using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreRoom.Adapters.MongoDBAdapter.EntitiesMongo
{
    public record EntityBlockAndRooms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Bloco { get; set; }
        [BsonElement("Responsavel")]
        public string Responsavel { get; set; }
        [BsonElement("Andares")]
        public int Andares { get; set; }
        [BsonElement("NumeroDeSalas")]
        public int NumeroDeSalas { get; set; }
        [BsonElement("Andar01")]
        public IList<Floorinformation> Andar01 { get; set; }

    }
    public record Floorinformation
    {
        [BsonElement("NumeroSala")]
        public int NumeroSala { get; set; }
        [BsonElement("Laboratorio")]
        public bool Laboratorio { get; set; }
        [BsonElement("Auditorio")]
        public bool Auditorio { get; set; }
        [BsonElement("Ativa")]
        public bool Ativa { get; set; }
        [BsonElement("Bloqueada")]
        public bool Bloqueada { get; set; }
        [BsonElement("Professor")]
        public string Professor { get; set; }
        [BsonElement("Materia")]
        public string Materia { get; set; }
        [BsonElement("Curso")]
        public string Curso { get; set; }
        [BsonElement("CapacidadeDeAlunos")]
        public int CapacidadeDeAlunos { get; set; }
        [BsonElement("DataHoraInicio")]
        public DateTime DataHoraInicio { get; set; }
        [BsonElement("DataHoraFim")]
        public DateTime DataHoraFim { get; set; }

    }
}
