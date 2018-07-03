using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.Api.Policy
{
    public interface IPolicyClient
    {
        Task<ResponseMessage<Policy>> GetByIdAsync(int id);

        Task<ResponseMessage<IEnumerable<Policy>>> GetAllAsync();

        Task<ResponseMessage> InsertAsync(Policy policy);

        Task<ResponseMessage> UpdateAsync(int id, Policy policy);

        Task<ResponseMessage> DeleteAsync(int id);
    }
}
