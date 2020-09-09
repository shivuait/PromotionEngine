using Repository.Abstraction;
using System;
using System.Windows.Forms;
using Repository.Implementation;

namespace Shopping
{
    public partial class FrmShopping : Form
    {
        ICartRepository cart;

        public FrmShopping()
        {
            cart = new CartRepository();
            InitializeComponent();
        }

        private void btnAddTocart_Click(object sender, EventArgs e)
        {
            try
            {
                cart.AddCart(cmbProducts.SelectedIndex, cmbProducts.Text, int.Parse(txtPrice.Text), 1);

                decimal total = 0;
                //lblCount.Text = Convert.ToString(cart.calculateCart(out total));
                lblTotalPrice.Text = total.ToString();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }

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
            cart = new CartRepository();
            lblCount.Text = "0";
            lblTotalPrice.Text ="0";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
           //var totalPrice= cart.CheckOut();
           // MessageBox.Show("Total price is : " + totalPrice);
        }

       
    }
}
