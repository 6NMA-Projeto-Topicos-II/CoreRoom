namespace CoreRoom.Domain.Dto
{
    public struct InputMongoRepository
    {
        public string bloco { get; set; }
        public int numeroSala { get; set; }
        public string materia { get; set; }
        public int matricula { get; set; }
        public string professor { get; set; }
        public string curso { get; set; }
        public DateTime dataHoraInicio { get; set; }
        public DateTime dataHoraFim { get; set; }
    }
}
