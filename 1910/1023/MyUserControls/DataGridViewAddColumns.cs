﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewAddColumns
{
    public class DataGridViewAddColumns
    {
        public void AddNewColumnToDataGridView(string headerText, string dataPropertyName,
                                                                    DataGridView dataGridView, Type type, int colWidth = 100, string name = null, bool visibility = true,
                                                                    DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleCenter)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headerText;
            col.DataPropertyName = dataPropertyName;
            col.Name = name ?? dataPropertyName;
            col.Width = colWidth;
            col.Visible = visibility;
            col.ValueType = type;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = alignment;
            dataGridView.Columns.Add(col);
        }
    }
}
