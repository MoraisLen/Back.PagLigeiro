using System;
using System.Collections.Generic;

namespace Back.PagLigeiro.Util.Validation.Error
{
    public class ErrorValidation : Exception
    {
        public List<FildErrorValidation> lstErros { get; set; }

        public ErrorValidation()
        {
            lstErros = new List<FildErrorValidation>();
        }

        public static ErrorValidation getError(string field, string message)
        {
            var val = new ErrorValidation();
            val.Add(field, message);

            return val;
        }

        public void Add(string field, string message)
        {
            lstErros.Add(new FildErrorValidation
            {
                Field = field,
                Message = message
            });
        }

        public void Disparar()
        {
            throw this;
        }

    }

    public class FildErrorValidation
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
