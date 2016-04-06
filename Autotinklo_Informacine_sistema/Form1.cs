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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new AutotinklasDBEntities2())
            {
                var log = db.Login.Where(x => x.username == textBox1.Text).FirstOrDefault();
                if (log != null)
                {
                    if (log.password == textBox2.Text)
                    {
                        if (log.role == 0)
                        {
                            MessageBox.Show("Admin Authenticated");
                            PadalinysAdd f1 = new PadalinysAdd();
                            f1.Show();
                        }
                        else
                        {
                            var pad = db.Padalinys.Where(x => x.id == log.role).FirstOrDefault();
                            MessageBox.Show("User from " + pad.miestas + " Authenticated");
                        }

                    }
                    else
                        MessageBox.Show("Wrong password");
                }
                else
                    MessageBox.Show("User not found");
            }
        }
    }
 }
