sap.ui.define([
    "app/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/Device",
    "sap/m/MessageToast",	
    "sap/m/MessageBox",
    "sap/ui/core/BusyIndicator",
    "app/model/formatter",
    'sap/ui/model/Filter',
    "sap/ui/model/resource/ResourceModel"	
], 

function (BaseController, JSONModel, Device, MessageToast, MessageBox, BusyIndicator, formatter, Filter,ResourceModel) {
    "use strict";

    return BaseController.extend("app.controller.contratos.Edit", {

        onInit : function () {							
            
            this
            .getRouter()
            .getRoute('contrato')
            .attachPatternMatched(this._onRouteMatched, this);          
            
            
        }, 
        formatter : formatter,    
       
       
        _onRouteMatched : function(oEvent){ 
            this.setModel(new JSONModel(), "Contract") ;         
            this.setModel(new JSONModel([
                {Id: 0, Description: "Compra"},
                {Id: 1, Description: "Venda"}
            ]), "oContractTypes") ;  

            this.load();
        },

        load(){
            this.setModel(new JSONModel("https://norus.azurewebsites.net/api/contract"),
            "Contracts")
        },
        onCreate(){
            let model = this.getModel("Contract").getData();
            console.log(model)
        },

        onChangeTab(oEvent){
            let key = oEvent.getParameters();
            console.log(key)
        }
        
        
    });
});