using System;
using System.Collections.Generic;
using System.Text;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(List<Contract> contratcs, string solicitante)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                            <div>
                                <style>
                                #contractPdfTable {
                                    font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;
                                    min-width: 600px;
                                    width: 600px;
                                }

                                #contractPdfTable td, #contractPdfTable th {
                                    border: 1px solid #ddd;
                                    padding: 1px;                 
                                }

                                #contractPdfTable tr:nth-child(even){background-color: #f2f2f2;}

                                #contractPdfTable th {
                                    padding: 4px;
                                    text-align: left;
                                    background-color: #535c68;
                                    color: white;
                                }
                                
                                .total{
                                    width:120px; 
                                    min-width:120px; 
                                }
                                .toLeft {
                                        text-align: end;
                                }
                                #header{
                                    whidth: 100%;
                                    h1 {
                                        diplay: block;
                                    }
                                }
                                #cliente{
                                    min-width: 190px;
                                    width: 190px;
                                }
                                </style>
                                <div id='header'>
                                    <h1>NORUS - Relatório de contratos</h1>
                                </div>                                
                                
                                <table id='contractPdfTable'>
                                    <tr>
                                        <th id='cliente'>Cliente</th>
                                        <th>Tipo</th>
                                        <th>Inicício</th>
                                        <th>Meses</th>
                                        <th>Qtd</th>
                                        <th>Valor</th>
                                        <th>Total</th>
                                    </tr>");
 
            foreach (var c in contratcs)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td class='toLeft'>{2}</td>
                                    <td>{3}</td>
                                    <td class='toLeft'>{4}</td>
                                    <td class='toLeft'>{5}</td>
                                    <td class='toLeft total'>{6}</td>
                                  </tr>", c.ClientName, c.Type.ToString(), c.StartMonth , c.Months , c.Quantity, "R$: " + c.Value, "R$: "+ c.ContractTotal);
            }
 
            sb.AppendFormat(@"
                                </table>
                                <br />
                                
                                Solicitado por {0} {1}
                            </div>
                        ",solicitante, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
 
            return sb.ToString();
        }
    }
}