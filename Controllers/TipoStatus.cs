using TrilhaApiDesafio.Models;

namespace desafio_agendamento_de_tarefas.Controllers
{
    public class TipoStatus
    {
        public static TipoStatus Tudo { get; internal set; }

        public static implicit operator EnumStatusTarefa(TipoStatus v)
        {
            throw new NotImplementedException();
        }
    }
}