using System.Collections.Generic;
using System.Linq;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus.Repository
{
    public class ContractRepository :  IContractRepository
    {
        private List<Contract> Contracts { get; set;}        

        public ContractRepository()
        {
            this.Contracts = new List<Contract>();
        }

        public void Add(Contract contract)
        {
            this.Contracts.Add(contract);
        }

        public void Update(Contract contract)
        {
            this.Contracts = this.Contracts.Where(x => x.Id == contract.Id).ToList();
            this.Contracts.Add(contract);
            this.Contracts.OrderBy(x => x.Id).ToList();
        }

        public void Remove(int contractId)
        {
           this.Contracts = this.Contracts.Where(x => x.Id != contractId).ToList();
        }

        public Contract Get(int contractId)
        {
            return this.Contracts.Find(x => x.Id == contractId);
        }

        public List<Contract> GetAll()
        {
            return this.Contracts;
        }
    }
    
}