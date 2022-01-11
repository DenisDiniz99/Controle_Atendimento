using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ICidadaoServico : IDisposable
    {
        Task Adicionar(Cidadao cidadao);
        Task Atualizar(Cidadao cidadao);
        Task Excluir(Cidadao cidadao);
    }
}
