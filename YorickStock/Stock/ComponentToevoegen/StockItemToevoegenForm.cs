using System;
using System.Windows.Forms;

namespace SamStock.Stock.ComponentToevoegen
{
    public partial class StockItemToevoegenForm : Form
    {
        private readonly StockController _controller;

        public StockItemToevoegenForm(StockController controller)
        {
            InitializeComponent();

            _controller = controller;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddComponentbutton_Click(object sender, EventArgs e)
        {
            _controller.AddComponent();
        }
    }
}
