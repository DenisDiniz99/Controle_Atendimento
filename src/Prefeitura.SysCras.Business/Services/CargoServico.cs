using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class CargoServico : BaseServico
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public CargoServico(ICargoRepositorio cargoRepositorio, INotificador notificador) : base(notificador)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        //Método de serviço para adicionar um novo cargo
        public async Task Adicionar(Cargo cargo)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um cargo
            if (!ExecutaValidacao(new CargoValidador(), cargo)) return;
            await _cargoRepositorio.Adicionar(cargo);
        }

        //Método de serviço para atualizar um cargo
        public async Task Atualizar(Cargo cargo)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza um cargo
            if (!ExecutaValidacao(new CargoValidador(), cargo)) return;
            await _cargoRepositorio.Atualizar(cargo);
        }

        //Método de serviço para excluir um cargo
        public async Task Excluir(Cargo cargo)
        {
            await _cargoRepositorio.Excluir(cargo);
        }

        public void Dispose()
        {
            _cargoRepositorio?.Dispose();
        }
    }
}
