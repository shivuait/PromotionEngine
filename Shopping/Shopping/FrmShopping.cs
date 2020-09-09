using System;
using System.Windows.Forms;

namespace Shopping
{
    public partial class FrmShopping : Form
    {
  

        private void btnAddTocart_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProducts.Text == "A")
            {
                txtPrice.Text = "50";
            }
            else if (cmbProducts.Text == "B")
            {
                txtPrice.Text = "30";
            }
            else if (cmbProducts.Text == "C")
            {
                txtPrice.Text = "20";
            }
            else if (cmbProducts.Text == "D")
            {
                txtPrice.Text = "15";
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
          
        }

       
    }
}
