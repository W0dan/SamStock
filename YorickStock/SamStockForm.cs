using System.Windows.Forms;
using YorickStock.Stock;

namespace YorickStock
{
    public partial class SamStockForm : Form
    {
        private readonly StockController _controller;

        public SamStockForm()
        {
            InitializeComponent();

            _controller = new StockController(this);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            _controller.GetStockOverzicht(StockOverviewListView);
        }

        private void StockButton_Click(object sender, System.EventArgs e)
        {
            HideAllGroupboxes();
            StockGroupBox.Visible = true;
        }

        private void PedalenButton_Click(object sender, System.EventArgs e)
        {
            HideAllGroupboxes();
            PedalenGroupBox.Visible = true;
        }

        private void UitgaandeBestellingenButton_Click(object sender, System.EventArgs e)
        {
            HideAllGroupboxes();
            BestellingenGroupBox.Visible = true;
        }

        private void HideAllGroupboxes()
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof (GroupBox))
                {
                    var groupBox = (GroupBox) control;
                    groupBox.Visible = false;
                }
            }
        }

        private void StockItemToevoegenButton_Click(object sender, System.EventArgs e)
        {
            _controller.ShowAddComponents();
        }
    }
}
