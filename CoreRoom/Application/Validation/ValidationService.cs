using Amazon.Runtime.Internal;
using CoreRoom.Domain;

namespace CoreRoom.Application.Validation
{
    public static class ValidationService
    {
        public static void ValidaServiceControle(BodyRequestSala bodyRequest)
        {
            if (string.IsNullOrEmpty(bodyRequest.Bloco) || bodyRequest.InfAndar.NumeroSala == 0)
                throw new BusinessException( "Obrigatorio passar Bloco e Numero da sala");
        }
        public static void ValidaBlocoServiceControle(BodyRequestSala bodyRequest)
        {
            if (string.IsNullOrEmpty(bodyRequest.Bloco) )
                throw new BusinessException("Obrigatorio passar Bloco ");

            if ( bodyRequest.Bloco.Count() != 1)
                throw new BusinessException("Apenas uma letra simbolizando o Bloco");

            if (bodyRequest.NumeroDeSalas == 0)
                throw new BusinessException("Obrigatorio informar o numero total de salas do bloco");

            if (bodyRequest.NumeroDeAndares == 0)
                throw new BusinessException("Obrigatorio informar o numero total de Andares do bloco");
        }
        public static void ValidaServiceControleNewRoom(BodyRequestSala bodyRequest)
        {
            ValidaServiceControle(bodyRequest);
            if(bodyRequest.InfAndar.CapacidadeDeAlunos == 0)
                throw new BusinessException("Obrigatorio informar a quantidade de alunos por sala");

            if (bodyRequest.InfAndar.NumeroDoAndar == 0)
                throw new BusinessException("Obrigatorio informar o numero do andar");

            if (bodyRequest.InfAndar.Auditorio == false && bodyRequest.InfAndar.Laboratorio == false)
                throw new BusinessException("Obrigatorio informar se é um labotario ou Auditorio");

        }
    }
}
