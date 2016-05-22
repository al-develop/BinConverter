using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinConverter
{
    public class Result<T>
    {
        public Result(T val, string msg, bool success)
        {
            Value = val;
            Message = msg;
            IsSuccess = success;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
