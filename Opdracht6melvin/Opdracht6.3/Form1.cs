using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht6._3
{
    public partial class Form1 : Form
    {
        AdventureWorks2016CTP3Entities1 _db = new AdventureWorks2016CTP3Entities1();

        public Form1()
        {
            InitializeComponent();
        }

        private void countryRegionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.countryRegionBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.adventureWorks2016CTP3DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorks2016CTP3DataSet.CountryRegion' table. You can move, or remove it, as needed.
            this.countryRegionTableAdapter.Fill(this.adventureWorks2016CTP3DataSet.CountryRegion);

        }

        private void countryRegionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dataSender = (DataGridView)sender;
            string cre = (string)dataSender.CurrentCell.Value;
            var test3 = _db.CountryRegionCurrency.Join(_db.CountryRegion,
                                                       crc => crc.CountryRegionCode,
                                                       cr => cr.CountryRegionCode,
                                                       (crc, cr) => new {Crc = crc, CrName = cr.Name, CrCRC = cr.CountryRegionCode})
                                                 .Join(_db.Currency,
                                                       crc => crc.Crc.CurrencyCode,
                                                       c => c.CurrencyCode,
                                                       (crc, c) => new {CCrc = crc, CName = c.Name})
                                                 .Where(cr => cr.CCrc.CrCRC == cre || cr.CCrc.CrName == cre)
                                                 .Select(y => y.CName).ToList();

            MessageBox.Show(test3.ToString());

            foreach (string c in test3)
            {
                MessageBox.Show("" + c);
            }

        }
    }
}
