using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class CidadaoServico : BaseServico
    {
        private readonly ICidadaoRepositorio _cidadaoRepositorio;

        public CidadaoServico(ICidadaoRepositorio cidadaoRepositorio, INotificador notificador) : base(notificador)
        {
            _cidadaoRepositorio = cidadaoRepositorio;
        }

        //Método de serviço para adicionar um novo cidadao
        public async Task Adicionar(Cidadao cidadao)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um cidadao
            if (!ExecutaValidacao(new CidadaoValidador(), cidadao)) return;
            await _cidadaoRepositorio.Adicionar(cidadao);
        }

        //Método de serviço para atualizar um cidadao
        public async Task Atualizar(Cidadao cidadao)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza o cidadao
            if (!ExecutaValidacao(new CidadaoValidador(), cidadao)) return;
            await _cidadaoRepositorio.Atualizar(cidadao);
        }

        //Método de serviço para excluir um cidadao
        public async Task Excluir(Cidadao cidadao)
        {
            await _cidadaoRepositorio.Excluir(cidadao);
        }

        public void Dispose()
        {
            _cidadaoRepositorio?.Dispose();
        }
    }
}
