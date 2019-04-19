using System.Collections.Generic;
using System.Text;
using GestaoContratosNorus.Domain;

namespace GestaoContratosNorus.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(List<Contract> contratcs)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");
 
            foreach (var c in contratcs)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", c.ClientName, c.Quantity,c.Value, c.Months);
            }
 
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
 
            return sb.ToString();
        }
    }
}