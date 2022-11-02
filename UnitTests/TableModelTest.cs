using Lab1.Models.Cells;
using Lab1.Models.Expressions;
using Lab1.Models.Tables;


namespace UnitTests
{
    [TestClass]
    public class TableModelTest
    {
        [TestMethod]
        public void GetCell_ForNewCellId_CreatesNewCell()
        {
            var table = new SimpleTable();

            ICell cellA1 = table.GetCell("A1");
            ICell cellA2 = table.GetCell("A2");

            Assert.IsNotNull(cellA1);
            Assert.IsNotNull(cellA2);
            Assert.AreNotSame(cellA1, cellA2);
            Assert.AreSame(cellA1, table.GetCell("A1"));
            Assert.AreSame(cellA2, table.GetCell("A2"));
        }

        [TestMethod]
        public void GetCell_ClearsBigEmptyTables()
        {
            var table = new SimpleTable();
            int trashhold = 50;
            var cells = new List<ICell>();
            for (int i = 0; i < trashhold; i++)
                cells.Add(table.GetCell($"A{i + 1}"));

            for (int i = 0; i < trashhold; i++)
                Assert.AreNotSame(table.GetCell($"A{i + 1}"), cells[i]);
        }

        [TestMethod]
        public void InsertRow_BeforeA2_MovesRowsForward()
        {
            var table = new SimpleTable();
            ICell cellExpectedToStay = table.GetCell("A1");
            ICell cellExpectedToBeMoved = table.GetCell("B2");

            table.InsertRow("2");

            Assert.AreSame(cellExpectedToStay, table.GetCell("A1"));
            Assert.AreSame(cellExpectedToBeMoved, table.GetCell("B3"));
        }
    }
}   