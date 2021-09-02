using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositoryFilmes<F>
    {
        List<F> Lista();

         F RetornaPorId(int id);

         void Insere(F Entidade);

         void Exclui(int id);

         void Atualiza(int id, F entidade);

         int ProximoId();
    }
}