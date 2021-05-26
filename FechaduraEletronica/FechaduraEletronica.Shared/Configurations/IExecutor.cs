using System.Threading.Tasks;

namespace FechaduraEletronica.Shared.Configurations
{
    public interface IExecutor<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }

    public interface IExecutor<TRequest>
    {
        void Execute(TRequest request);
    }
}
