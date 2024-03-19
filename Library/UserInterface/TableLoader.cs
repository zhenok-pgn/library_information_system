using Library.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Domain;

namespace Library.UserInterface
{
    public class TableLoader
    {
        public static void SetTableHeaders(List<PropertyInfo> prop, DataGridView dataGrid)
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

        public static void LoadTable<T>(Func<List<T>> getDataFromRepository, DataGridView dataGridView)
        {
            try
            {
                var table = getDataFromRepository();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = table;
                dataGridView.DataSource = bindingSource;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void LoadTable<T1, T2, T3>(T1 condition1, T2 condition2, Func<T1, T2, List<T3>> getDataFromRepository, DataGridView dataGridView)
        {
            try
            {
                var table = getDataFromRepository(condition1, condition2);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = table;
                dataGridView.DataSource = bindingSource;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void LoadTable<T1, T2>(T1 condition, Func<T1, List<T2>> getDataFromRepository, DataGridView dataGridView)
        {
            try
            {
                var table = getDataFromRepository(condition);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = table;
                dataGridView.DataSource = bindingSource;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
