namespace CoreRoom.Domain.Dto
{
    public record InputMongoRepository
    {
        public string? id { get; set; } = null;
        public string? bloco { get; set; } = null;
        public string? responsavel { get; set; } = null;
        public int? NumeroAndares { get; set; } = null;
        public int? NumeroDeSalas { get; set; } = null;
        public int? NumeroDoAndar { get; set; } = null;
        public int? numeroSala { get; set; } = null;
        public bool? laboratorio { get; set; } = null;
        public bool? Auditorio { get; set; } = null;
        public bool? salaAtiva { get; set; } = null;
        public bool? Bloqueada { get; set; } = null;
        public string? materia { get; set; } = null;
        public string? professor { get; set; } = null;
        public string? curso { get; set; } = null;
        public int? capacidadeDeAlunos { get; set; } = null;
        public DateTime? dataHoraInicio { get; set; } = null;
        public DateTime? dataHoraFim { get; set; } = null;
    }
}
