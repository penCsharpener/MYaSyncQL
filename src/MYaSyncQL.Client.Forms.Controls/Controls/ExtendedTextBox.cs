using System.ComponentModel;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Controls {
    public partial class ExtendedTextBox : TextBox {

        public ExtendedTextBox() {
            InitializeComponent();
            Constructor();
        }

        public ExtendedTextBox(IContainer container) {
            container.Add(this);

            InitializeComponent();
            Constructor();
        }

        private void Constructor() {
            DoubleBuffered = true;
            AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
