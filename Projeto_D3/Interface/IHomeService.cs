using Projeto_D3.Models;
using System.Collections.Generic;

namespace Projeto_D3.Interface
{
    public interface IHomeService
    {
        void AddCadastro(string CRM, string Nome);

        IEnumerable<Cadastro> GetMonitorar();

    }
}
