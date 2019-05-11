using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MYaSyncQL.Client.Forms.Common;

namespace MYaSyncQL.Client.Forms.Controls {

    public partial class UCClassBuilder : UserControl {

        public UCClassBuilder() {
            InitializeComponent();
            Load += LoadEvent;
        }

        private void LoadEvent(object sender, EventArgs e) {
            // reloads all data
            StaticElements.ConMan.DatabaseServerChanged += (s, e) => {

            };

        }

        private async Task InitControls() {

        }

        private async Task InitHandlers() {
            
        }

        private void InitBindings() {

        }
    }
}
