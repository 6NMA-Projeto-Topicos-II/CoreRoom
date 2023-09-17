namespace CoreRoom.Domain.Dto
{
    public record InputMongoRepository
    {
        public string id { get; set; } = null!;
        public string bloco { get; set; } = null!;
        public int numeroSala { get; set; } = 0;
        public string materia { get; set; } = null!;
        public int matricula { get; set; } = 0;
        public string professor { get; set; } = null!;
        public string curso { get; set; } = null!;
        public DateTime? dataHoraInicio { get; set; } = null!;
        public DateTime? dataHoraFim { get; set; } = null!;
    }
}
