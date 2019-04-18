using System;

namespace GestaoContratosNorus.Domain
{
    public class Contract
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public ContractType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }

        public DateTime Start { get; set; }

        public int Duration { get; set; }

        public void Minuta(){
            
        }
    }
}