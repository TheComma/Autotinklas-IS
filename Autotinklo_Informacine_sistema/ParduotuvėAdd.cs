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
    public partial class ParduotuvėAdd : Form
    {
        public ParduotuvėAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new AutotinklasDBEntities2())
            {
                Parduotuve p = new Parduotuve();
                p.miestas = textBox2.Text;
                p.pavadinimas = textBox1.Text;
                p.adresas = textBox3.Text;
                db.Parduotuve.Add(p);
                db.SaveChanges();
            }
        }
    }
}
