using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Medilab.UserInterface.Utilities
{
    public static class FormHandler
    {
        static readonly Dictionary<Type, Form> MTypeFormLookup = new Dictionary<Type, Form>();

        static public T GetInstance<T>(Form owner) where T : Form
        {
            return GetInstance<T>(owner, null);
        }

        static public T GetInstance<T>(Form owner, params object[] args) where T : Form
        {
            if (!MTypeFormLookup.ContainsKey(typeof(T)))
            {
                var f = (Form)Activator.CreateInstance(typeof(T), args);
                MTypeFormLookup.Add(typeof(T), f);
                f.Owner = owner;
                f.FormClosed += new FormClosedEventHandler(Remover);
            }
            return (T)MTypeFormLookup[typeof(T)];
        }

        static void Remover(object sender, FormClosedEventArgs e)
        {
            var f = sender as Form;
            if (f == null) return;

            f.FormClosed -= new FormClosedEventHandler(Remover);
            MTypeFormLookup.Remove(f.GetType());
        }

        public static void ShowForm<T>(Form parent, bool isDialog = false) where T : Form
        {
            var frm = GetInstance<T>(parent);
            if (isDialog)
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = parent;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
                frm.Activate();
            }
        }

        public static void CleanFormControls(Control.ControlCollection controls)
        {
            foreach (var control in controls)
            {
                var formControl = (Control) control;
                if (formControl.Controls.Count > 0)
                {
                    CleanFormControls(formControl.Controls);
                }
                var controlType = formControl.GetType();
                if (controlType == typeof(TextBox))
                {
                    ((TextBox)formControl).Text = string.Empty;
                }
                else if (controlType == typeof(ComboBox))
                {
                    ((ComboBox)formControl).SelectedIndex = 0;
                }
            }
        }
    }
}
