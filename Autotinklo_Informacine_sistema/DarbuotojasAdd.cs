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
    public partial class DarbuotojasAdd : Form
    {
        public DarbuotojasAdd()
        {
            InitializeComponent();
            comboFill(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new AutotinklasDBEntities2())
            {
                Darbuotojas d = new Darbuotojas();
                d.pavarde = textBox1.Text;
                d.vardas = textBox2.Text;
                d.telefonas = textBox3.Text;
                d.adresas = textBox4.Text;
                d.fk_Padalinys = db.Padalinys.Where(x => x.adresas == (string)comboBox1.SelectedItem).FirstOrDefault().id;
                db.Darbuotojas.Add(d);
                db.SaveChanges();
                MessageBox.Show("Darbuotojas sėkmingai pridėtas");
            }
            Close();
        }
        public void comboFill(ComboBox c)
        {
            using (var db = new AutotinklasDBEntities2())
            {
                List<Padalinys> list;
                list = db.Padalinys.ToList();
                foreach (Padalinys p in list)
                    c.Items.Add(p.adresas);                
            }
        }

        private void DarbuotojasAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
