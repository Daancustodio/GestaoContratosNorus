using System.Collections.Generic;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus.Domain
{
    public interface IContractRepository
    {
       Contract Add(Contract contract);
       Contract Update(Contract contract);
       void Remove(string contractId);
       Contract Get(string contractId);
       List<Contract> GetAll();

    }
    
}