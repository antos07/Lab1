using Lab1.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Lab1
{
    public class Controller
    {
        private readonly IParser _parser;

        public Controller(IParser parser)
        {
            _parser = parser;
        }

        public void CreteTable()
        { }

        public void OpenTable(string filename) 
        { }

        public int GetColumnsNumber()
        {
            return 20;
        }

        public int GetRowsNumber()
        {
            return 50;
        }
    }
}
