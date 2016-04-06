using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autotinklo_Informacine_sistema
{
    public partial class AutodalisAdd : Form
    {
        public AutodalisAdd()
        {
            InitializeComponent();
            fillCombo(comboBox1);
        }
        public void fillCombo(ComboBox c)
        {
            using(var db = new AutotinklasDBEntities2())
            {
                List<Parduotuve> list;
                list = db.Parduotuve.ToList();
                foreach (Parduotuve p in list)
                    c.Items.Add(p.pavadinimas);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new AutotinklasDBEntities2())
            {
                Autodalis a = new Autodalis();
                a.pavadinimas = textBox1.Text;
                a.kaina = double.Parse(textBox2.Text);
                a.gamintojas = textBox3.Text;
                a.fk_parduotuve = db.Parduotuve.Where(x => x.pavadinimas == (string)comboBox1.SelectedItem).FirstOrDefault().id;
                db.Autodalis.Add(a);
                db.SaveChanges();
                MessageBox.Show("Prekė sėkmingai pridėta");
            }
            Close();
        }
    }
}
