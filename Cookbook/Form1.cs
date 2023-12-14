using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class recipeManager : Form
    {
        public object editing = false;
        DataTable recipes = new DataTable();

        public recipeManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recipes.Columns.Add("Name");
            recipes.Columns.Add("Category");
            recipes.Columns.Add("Ingredients");
            recipes.Columns.Add("Recipe");

            recipesGridView.DataSource = recipes;
        }

        private void recipesGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nameTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
            categoryTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
            ingredientsTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
            recipeTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
            editing = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            categoryTextBox.Text = "";
            ingredientsTextBox.Text = "";
            recipeTextBox.Text = "";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
            categoryTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
            ingredientsTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
            recipeTextBox.Text = recipes.Rows[recipesGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
            editing = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if ((bool)editing)
            {
                recipes.Rows[recipesGridView.CurrentCell.RowIndex]["Name"] = nameTextBox.Text;
                recipes.Rows[recipesGridView.CurrentCell.RowIndex]["Category"] = categoryTextBox.Text;
                recipes.Rows[recipesGridView.CurrentCell.RowIndex]["Ingredients"] = ingredientsTextBox.Text;
                recipes.Rows[recipesGridView.CurrentCell.RowIndex]["Recipe"] = recipeTextBox.Text;
            }
            else
            {
                recipes.Rows.Add(nameTextBox.Text, categoryTextBox.Text, ingredientsTextBox.Text, recipeTextBox.Text);
            }
            nameTextBox.Text = "";
            categoryTextBox.Text = "";
            ingredientsTextBox.Text = "";
            recipeTextBox.Text = "";
            editing = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                recipes.Rows[recipesGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.WriteLine("Not a valid row"); }
        }
    }
}