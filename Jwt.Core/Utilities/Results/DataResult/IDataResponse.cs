using Jwt.Utilities.Results.Result;

namespace Jwt.Utilities.Results.DataResult
{
    
    public interface IDataResponse<out T> : IResponse
    {
        T Data { get; }
    }
}