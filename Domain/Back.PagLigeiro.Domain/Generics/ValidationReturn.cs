using Back.PagLigeiro.Util.Validation.Error;
using System.Collections.Generic;

namespace Back.PagLigeiro.Domain.Generics
{
    public class ValidationReturn<T>
    {
        public ValidationReturn()
        {
            Errors = new List<FildErrorReturn>();
        }

        public ValidationReturn(List<FildErrorReturn> errors)
        {
            Errors = errors;
            Success = false;
            Message = "Errp de validação de dados";
        }

        public ValidationReturn(T data)
        {
            Data = data;
            Success = true;
        }

        public void Add(string field, string message)
        {
            Errors.Add(new FildErrorReturn
            {
                Field = field,
                Message = message
            });
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<FildErrorReturn> Errors { get; set; }
    }

    public class FildErrorReturn
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}