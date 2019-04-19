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
                        <html>
                            <head>
                            <style>
                                #contractPdfTable {
                                font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;
                                border-collapse: collapse;
                                width: 100%;
                                }

                                #contractPdfTable td, #contractPdfTable th {
                                border: 1px solid #ddd;
                                padding: 8px;
                                }

                                #contractPdfTable tr:nth-child(even){background-color: #f2f2f2;}

                                #contractPdfTable tr:hover {background-color: #ddd;}

                                #contractPdfTable th {
                                padding-top: 12px;
                                padding-bottom: 12px;
                                text-align: left;
                                background-color: #0077c8;
                                color: white;
                                }
                                .toLeft {
                                        text-align: end;
                                }
                                </style>
                            </head>
                            <body>
                                <div class='header'>
                                <h1>NORUS - Relatório de contratos</h1></div>
                                
                                </div>
                                <table id='contractPdfTable'>
                                    <tr>
                                        <th>Cliente</th>
                                        <th>Tipo</th>
                                        <th>Inicício</th>
                                        <th>Duração</th>
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
                                    <td class='toLeft'>{6}</td>
                                  </tr>", c.ClientName, c.Type.ToString(), c.StartMonth , c.Months + " (meses)", c.Quantity, "R$: " + c.Value, "R$: "+ c.ContractTotal);
            }
 
            sb.AppendFormat(@"
                                </table>
                                Solicitado por {0} {1}
                            </body>
                        </html>",solicitante, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
 
            return sb.ToString();
        }
    }
}