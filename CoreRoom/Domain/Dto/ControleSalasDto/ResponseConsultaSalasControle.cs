namespace CoreRoom.Domain.Dto.ControleSalasDto
{
    public struct ResponseConsultaSalasControle
    {
        public string bloco { get; set; }
        public int numeroDoAndar { get; set; }
        public int NumeroDaSala { get; set; }
        public bool Bloqueada { get; set; }
        public bool EmAula { get; set; }
        public int capacidadeDeAlunos { get; set; }

    }
}
