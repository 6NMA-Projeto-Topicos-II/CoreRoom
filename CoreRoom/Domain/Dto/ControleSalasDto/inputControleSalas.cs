namespace CoreRoom.Domain.Dto.ControleSalasDto
{
    public struct inputControleSalas
    {
        public string Bloco { get; set; }
        public int NumeroAndares { get; set; }
        public int NumeroDeSalas { get; set; }
        public InfAndares Infsala { get; set; }
    }
    public struct InfAndares
    {
        public int NumeroDoAndar { get; set; }
        public int NumeroSala { get; set; }
        public bool laboratorio { get; set; }
        public bool Auditorio { get; set; }
        public bool Bloqueada { get; set; }
        public int capacidadeDeAlunos { get; set; }


    }
}
