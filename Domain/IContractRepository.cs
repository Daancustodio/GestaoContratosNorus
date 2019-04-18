using System.Collections.Generic;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus.Domain
{
    public interface IContractRepository
    {
       void Add(Contract contract);
       void Update(Contract contract);
       void Remove(int contractId);
       Contract Get(int contractId);
       List<Contract> GetAll();

    }
    
}