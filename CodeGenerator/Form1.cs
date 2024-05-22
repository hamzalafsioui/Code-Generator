using CodeGeneratorBusinessLayers;
using System;
using System.Data;
using System.Windows.Forms;


namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _FillNameDataBase()
        {
            DataTable dt = clsDatabase.GetAllDataBase();

            foreach (DataRow item in dt.Rows)
            {
                cmbDatabase.Items.Add(item[0]);
            }
            cmbDatabase.SelectedIndex = 0;
        }

        private void _RefreshTableInfo()
        {
            dgvTableInfo.DataSource = clsDatabase.GetTableInfo(cmbDatabase.SelectedItem.ToString(), cmbTable.SelectedItem.ToString());
        }

        private void _FillNameTableFromDatabase()
        {
            cmbTable.Items.Clear();
            DataTable dt = clsDatabase.GetAllTables(cmbDatabase.SelectedItem.ToString());

            foreach (DataRow item in dt.Rows)
            {
                cmbTable.Items.Add(item[0]);
            }
            if (cmbTable.SelectedIndex != 0)
            {
                cmbTable.SelectedIndex = 0;
            }
        }

        private void _GetColumnName()
        {
            clbTables.Items.Clear();
            DataTable dt = clsDatabase.GetColumnName(cmbDatabase.SelectedItem.ToString(),
              cmbTable.SelectedItem.ToString());
            short counter = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (counter > 0)
                {
                    clbTables.Items.Add(item[0].ToString());
                }
                counter++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            _FillNameDataBase();
            _FillNameTableFromDatabase();
        }

        private void cmbDatabase_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _FillNameTableFromDatabase();
        }

        private DataTable _ConvertSelectedColumnToDataTable()
        {
            DataTable dt = clsDatabase.GetColumnName(cmbDatabase.SelectedItem.ToString(),
            cmbTable.SelectedItem.ToString());

            DataTable ColUmnSelected = new DataTable();
            ColUmnSelected.Columns.Add("Name", typeof(string));
            ColUmnSelected.Columns.Add("DataType", typeof(string));

            if (clbTables.CheckedItems.Count == 0)
                return null;



            short counter = 0;
            for (int i = 0; i < clbTables.Items.Count; i++)
            {

                foreach (DataRow item in dt.Rows)
                {

                    if (counter == clbTables.CheckedItems.Count)
                    {
                        break;
                    }
                    if (item[0].ToString() == clbTables.CheckedItems[i].ToString())
                    {

                        counter++;
                        ColUmnSelected.Rows.Add(item[0].ToString(), item[1].ToString());

                    }
                }
            }
            return ColUmnSelected;
        }

        private void FillAllTxtDataAccess()
        {
            string NameBaseTable = cmbTable.SelectedItem.ToString().Substring(0, cmbTable.SelectedItem.ToString().Length - 1);

            clsCreateDataAccess DataAccess = new clsCreateDataAccess();

            DataAccess.BasicParameters
              (clsDatabase.GetTableInfo(cmbDatabase.SelectedItem.ToString(),
              cmbTable.SelectedItem.ToString()), NameBaseTable, cmbTable.SelectedItem.ToString(), _ConvertSelectedColumnToDataTable());

            WebTxtDataAccsess.DocumentText = DataAccess.AllFunctionForDataAccess();

        }
        private void FillAllTxtBusinessLayer()
        {
            string NameBaseTable = cmbTable.SelectedItem.ToString().Substring(0, cmbTable.SelectedItem.ToString().Length - 1);

            clsCreateBusinessLayer BusinessLayers = new clsCreateBusinessLayer(clsDatabase.GetTableInfo(cmbDatabase.SelectedItem.ToString(),
               cmbTable.SelectedItem.ToString()), NameBaseTable, cmbTable.SelectedItem.ToString(), _ConvertSelectedColumnToDataTable());


            WebTxtBusinessLayers.DocumentText = BusinessLayers.AllFunctionForBusinessLayers();


        }
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            FillAllTxtDataAccess();
            FillAllTxtBusinessLayer();
        }

        private void btnCopyDataAcc_Click(object sender, EventArgs e)
        {
            if (WebTxtDataAccsess.DocumentText != "")
                Clipboard.SetText(WebTxtDataAccsess.DocumentText);
        }

        private void cmbTable_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _RefreshTableInfo();
            _GetColumnName();
            txtTableName.Text = cmbTable.Text;
        }

        private void btnCopyBusinessLayer_Click(object sender, EventArgs e)
        {
            if (WebTxtBusinessLayers.DocumentText != "")
                Clipboard.SetText(WebTxtBusinessLayers.DocumentText);
        }
    }
}
