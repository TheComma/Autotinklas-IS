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
    public partial class PadalinysAdd : Form
    {
        public PadalinysAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new AutotinklasDBEntities2())
            {
                Padalinys p = new Padalinys();
                p.adresas = textBox2.Text;
                p.miestas = textBox1.Text;
                db.Padalinys.Add(p);
                db.SaveChanges();
            }
        }
    }
}
