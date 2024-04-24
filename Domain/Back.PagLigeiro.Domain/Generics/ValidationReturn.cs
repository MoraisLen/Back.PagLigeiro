using System.Collections.Generic;

namespace Back.PagLigeiro.Domain.Generics
{
    public class ValidationReturn<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<FildErrorReturn>? Errors { get; set; }

        public static ValidationReturn<T> Ok(T _data = default(T))
        {
            return new ValidationReturn<T>
            {
                Success = true,
                Data = _data,
                Errors = null
            };
        }

        public static ValidationReturn<T> WithErrors(List<FildErrorReturn> _errors = null)
        {
            return new ValidationReturn<T>
            {
                Success = false,
                Data = default(T),
                Errors = _errors
            };
        }
    }

    public class FildErrorReturn
    {
        public FildErrorReturn(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public string Field { get; set; }
        public string Message { get; set; }
    }
}