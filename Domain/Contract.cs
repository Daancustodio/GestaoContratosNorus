using System;

namespace GestaoContratosNorus.Domain
{
    public class Contract
    {
        public Contract()
        {
            this.Id = Guid.NewGuid().ToString().Split('-')[0].ToUpper();
            this.unread = true;
        }
        public string Id { get; set; }
        public Boolean unread { get; set; }
        public string ClientName { get; set; }
        public ContractType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal ContractTotal {get { return getContratTotal();} }

        private decimal getContratTotal()
        {
            var total = this.Quantity * Value;
            return total;
        }

        public string StartMonth { get; set; }
        
        public int Months { get; set; }
    
        public void Minuta(){
            
        }

        public void validate(){
            
            if(string.IsNullOrEmpty(this.ClientName))
                throw new Exception("Informe o nome do cliente.");
           
            if(string.IsNullOrEmpty(this.StartMonth))
                throw new Exception("Informe a data de início do contrato.");
           
            if(this.Quantity == decimal.Zero)
                throw new Exception("Informe a quantidade negociada no contrato.");
           
            if(Value == decimal.Zero)
                throw new Exception("Informe o valor negociado no contrato.");
            
            if(this.Months == decimal.Zero)
                throw new Exception("Informe a duração em meses do contrato.");
            
            
            
        }
    }
}