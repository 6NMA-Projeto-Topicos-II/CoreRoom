namespace CoreRoom.Domain.Dto
{
    public record InputMongoRepository
    {
        public string id { get; set; } = null!;
        public char? bloco { get; set; } = null       
        public string responsavel { get; set; } = null!;
        public int NumeroAndares { get; set; }
        public int NumeroDeSalas { get; set; }
        public int NumeroDoAndar { get; set; } = 0!;
        public int numeroSala { get; set; } = 0;
        public bool laboratorio { get; set; }
        public bool Auditorio { get; set; }
        public bool salaAtiva { get; set; }
        public bool Bloqueada { get; set; }
        public string materia { get; set; } = null!;
        public string professor { get; set; } = null!;
        public string curso { get; set; } = null!;
        public int capacidadeDeAlunos { get; set; }
        public DateTime? dataHoraInicio { get; set; } = null!;
        public DateTime? dataHoraFim { get; set; } = null!;
    }
}
