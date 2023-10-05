using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard.Forms
{
    public partial class FormInventory : Form
    {
        private int customerId;
        public FormInventory(int customer_id)
        {
            InitializeComponent();
            this.customerId = customer_id;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            // label1.ForeColor = ThemeColor.SecondaryColor;
            // label2.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
