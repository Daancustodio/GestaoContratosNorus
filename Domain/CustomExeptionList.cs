using System.Collections.Generic;
using System.Linq;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus
{
    public class CustomExeptionList : System.Exception
    {
        public List<CustomExeption> AllExceptions { get; set; }
        public CustomExeptionList() : base("Ocorreu um erro tratado pelo sistema")
        {
            this.AllExceptions = new List<CustomExeption>();
        }

        public void Add(CustomExeption ex)
        {
            this.AllExceptions.Add(ex);
        }

        public void AddError(string msg, string description)
        {
            var ex = new CustomExeption(ExceptionType.Error, msg, description);
            this.AllExceptions.Add(ex);
            
        }
        public void AddSuccess(string msg, string description)
        {
            var ex = new CustomExeption(ExceptionType.Success, msg, description);
            this.AllExceptions.Add(ex);
        }
        public void AddWarnning(string msg, string description)
        {
            var ex = new CustomExeption(ExceptionType.Warning, msg, description);
            this.AllExceptions.Add(ex);
        }

        public bool HasExceptions(bool ignoreInfoAndWarning)
        {
            if (ignoreInfoAndWarning)
                return this.AllExceptions.Any(x => x.ExceptionType == nameof(ExceptionType.Error));

            return this.AllExceptions.Any(x => x.ExceptionType != nameof(ExceptionType.Success));
        }

        public void AddInformation(string msg, string description)
        {
            var ex = new CustomExeption(ExceptionType.Information, msg, description);
            this.AllExceptions.Add(ex);
        }
    }

}