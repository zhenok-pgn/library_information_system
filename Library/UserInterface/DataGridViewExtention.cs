using Library.Domain;
using Library.Infrastracture;
using Library.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UserInterface
{
    public static class DataGridViewExtention
    {
        public static void Load<T>(this DataGridView dataGridView, List<T> data)
            where T : IDisplayable
        {
            try
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = data;
                dataGridView.DataSource = bindingSource;
                dataGridView.SetTableHeaders(typeof(T).GetProperties());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static void SetTableHeaders(this DataGridView dataGrid, PropertyInfo[] prop)
        {
            if (prop == null)
                return;
            var cols = dataGrid.Columns;
            int delta = -1;
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].Frozen)
                    continue;
                if (delta == -1)
                    delta = i;
                var attribute = prop[i - delta].GetCustomAttributes(true).OfType<LabelAttribute>().First();
                cols[i].HeaderText = attribute.LabelText;
            }
        }
    }
}
