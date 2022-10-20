using Lab1.Models.Cells;
using Lab1.Models.Tables;
using Lab1.Models.Expressions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Lab1.Parsers;
using Lab1.Models.Parsers.Exceptions;

namespace Lab1.Utils
{
    static internal class TableSerializer
    {
        static public string Serialize(ITable table)
        {
            var cells = new Dictionary<string, string?>();
            foreach (KeyValuePair<string, ICell> entry in table.ExportCells())
                cells.Add(entry.Key, entry.Value.Expression == null ? null : entry.Value.Expression.ToString());

            var jsonModel = new TableJson
            {
               ColumnsNumber = table.ColumnsNumber,
               RowsNumber = table.RowsNumber,
               Cells = cells
            };
            return JsonSerializer.Serialize(jsonModel);
        }
        static public ITable Deserialize(string json, IParser parser)
        {
            TableJson jsonModel = JsonSerializer.Deserialize<TableJson>(json);

            var table = new SimpleTable(jsonModel.ColumnsNumber, jsonModel.RowsNumber);
            foreach (KeyValuePair<string, string?> entry in jsonModel.Cells)
            {
                ICell cell = table.GetCell(entry.Key);
                if (entry.Value != null)
                {
                    try
                    {
                        cell.Expression = parser.ParseExpression(entry.Value);
                    }
                    catch (ParserException)
                    {
                        cell.Expression = new InvalidExpression(entry.Value);
                    }
                }
            }
            return table;
        }
    }
}
