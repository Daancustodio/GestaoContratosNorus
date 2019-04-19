using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GestaoContratosNorus.Domain;
using Newtonsoft.Json;


namespace GestaoContratosNorus.Repository
{
    public class ContractRepository :  IContractRepository
    {
        private List<Contract> Contracts { get; set;}        
        private string _filePath = "./files/contratos.json";
        public ContractRepository()
        {
            
            if(!File.Exists(_filePath)){
            
                if(!Directory.Exists("./files"))
                    Directory.CreateDirectory("./files");

                File.Create(this._filePath);                

            }
            
            this.LoadJson();
        }

        private void LoadJson()
        {
            using (StreamReader r = new StreamReader(this._filePath))
            {
                string json = r.ReadToEnd();
                this.Contracts = JsonConvert.DeserializeObject<List<Contract>>(json);
                if(Contracts == null)
                    this.Contracts = new List<Contract>();
            }
        }
        private void SaveJson()
        {
            var json  = JsonConvert.SerializeObject(this.Contracts);
            
            using (StreamWriter r = new StreamWriter(this._filePath))
            {
                r.WriteLine(json);
            }
        }


        public Contract Add(Contract contract)
        {
            if(string.IsNullOrEmpty(contract.Id) || contract.Id == Guid.Empty.ToString())
                contract.Id =  Guid.NewGuid().ToString().Split("-")[0].ToUpper();
           
            contract.validate();

            this.Contracts.Add(contract);
            this.SaveJson();
            return contract;
        }

        public Contract Update(Contract contract)
        {
            this.Contracts = this.Contracts.Where(x => x.Id != contract.Id).ToList();
            this.Contracts.Add(contract);
            this.Contracts.OrderBy(x => x.ClientName).ToList();
            SaveJson();
            return contract;
        }

        public void Remove(string contractId)
        {
           this.Contracts = this.Contracts.Where(x => x.Id != contractId).ToList();
           this.SaveJson();
        }

        public Contract Get(string contractId)
        {
            return this.Contracts.Find(x => x.Id == contractId);
        }

        public List<Contract> GetAll()
        {
            return this.Contracts.OrderBy(x=> x.ClientName).ToList();
        }

        public List<Contract> GetByIdStringList(string contratcIds)
        {
            var ids = new List<string>(){contratcIds};
            if(contratcIds.Contains(';'))
                ids = contratcIds.Split(';').ToList();

            var selecionados = this.Contracts.Where(x => ids.Any(a => a == x.Id)).ToList();
           selecionados = selecionados.Select(c => {
                c.unread = false;
                this.Update(c);
                return c;
            }).ToList();
            
            return selecionados;
        }
    }
    
}