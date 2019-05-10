using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Extensions {
    public static class ControlExtensions {

        /// <summary>
        /// Enabled protected property DoubleBuffered on any control. Especially important for DataGridViews.
        /// </summary>
        /// <param name="ctrl"></param>
        public static void DoubleBuffered(this Control ctrl) {
            // with help of: https://stackoverflow.com/a/1506066/6454517
            ctrl.GetType().InvokeMember("DoubleBuffered",
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                        null, ctrl, new object[] { true });
        }

        /// <summary>
        /// get all controls of a certain type inside a control and do stuff with them.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetChildControls(this Control ctrl, Type type) {
            /// with help of: https://stackoverflow.com/a/3426721/6454517
            var controls = ctrl.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetChildControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        /// <summary>
        /// Useful for adding a user control to a panel.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="childCtrl"></param>
        /// <param name="clearFirst"></param>
        /// <param name="dockStyle"></param>
        public static void AddControl(this Control ctrl, Control childCtrl, bool clearFirst = true, DockStyle dockStyle = DockStyle.Fill) {
            if (clearFirst) ctrl.Controls.Clear();
            childCtrl.Dock = dockStyle;
            ctrl.Controls.Add(childCtrl);
        }

        public static void AddControls(this Control ctrl, IEnumerable<Control> childCtrls, bool clearFirst = true, DockStyle dockStyle = DockStyle.Fill) {
            if (clearFirst) ctrl.Controls.Clear();
            foreach (var childCtrl in childCtrls) {
                childCtrl.Dock = dockStyle;
                ctrl.Controls.Add(childCtrl);
            }
        }
    }
}
