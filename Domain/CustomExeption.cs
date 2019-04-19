using System;

namespace GestaoContratosNorus.Domain
{
     public class CustomExeption : Exception
    {
        public CustomExeption(string message)
            :base(message)
        {
            this.ExceptionType = GestaoContratosNorus.Domain.ExceptionType.Error.ToString();            
        }

       
        public CustomExeption(ExceptionType type, string message, string description)
          : base(message)
        {
            this.ExceptionType = type.ToString();
            this.Description = description;
        }

        public string Description { get; set; }
        public string ExceptionType { get; protected set; }       
       
    }

    public enum ExceptionType
    {
        Success,
        Error,
        Warning,
        Information
    }

}