using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Shared.Configurations;
using System.Threading.Tasks;

namespace FechaduraEletronica.Borders.Executors.Client
{
    public interface IGetClientExecutor : IExecutor<GetClientRequest, GetClientResponse>
    {
        Task<GetClientResponse> Execute(GetClientRequest getClientRequest);
    }
}
