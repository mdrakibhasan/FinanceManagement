using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared.Extensation.Result
{
    public class QueryResult<T>
    {
        public QueryResult(T result, QueryResultTypeEnum type)
        {
            Result = result;
            Type = type;
        }
        public T Result { get; set; }
        public QueryResultTypeEnum Type { get; set; }
    }

    public enum QueryResultTypeEnum
    {
        Success,
        InvalidInput,
        UnprocessableEntity,
        NotFound
    }
}
