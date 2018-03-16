using System;
using System.Collections;

namespace ANSDNPM.Interfaces
{
    public interface IDal
    {
        IList Listar();
        void Cadastrar(Object obj);
        void Excluir(Object obj);
        void Alterar(Object obj);
    }
}
