using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Controls {
    public partial class ExtendedDGV : DataGridView {
        public ExtendedDGV() {
            InitializeComponent();
            Constructor();
        }

        public ExtendedDGV(IContainer container) {
            container.Add(this);

            InitializeComponent();
            Constructor();
        }

        private void Constructor() {
            DoubleBuffered = true;
        }
    }
}
