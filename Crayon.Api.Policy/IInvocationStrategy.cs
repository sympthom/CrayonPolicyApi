using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.Api.Policy
{
    public interface IInvocationStrategy
    {
        Task<ResponseMessage> Invoke(Func<Task<ResponseMessage>> action);

        Task<ResponseMessage<T>> Invoke<T>(Func<Task<ResponseMessage<T>>> action);
    }
}
