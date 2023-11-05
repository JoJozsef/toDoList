using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable toDoList = new DataTable();
        bool istEiditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Descrption");

            toDoListView.DataSource = toDoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            istEiditing |= true;

            titleTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(istEiditing)
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Descrption"] = titleTextBox.Text;
            } else
            {
                toDoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }

            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            istEiditing = false;
        }
    }
}
