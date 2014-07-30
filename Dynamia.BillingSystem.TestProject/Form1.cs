using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dynamia.BillingSystem.SQLDAO;
using Dynamia.BillingSystem.BusinessManager;
using Dynamia.BillingSystem.Controller;

namespace Dynamia.BillingSystem.TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DAOGetSFDataTest();
        }

        //metodo de prueba de proyecto sqldao
        public void DAOGetSFDataTest()
        {
            BillingController billingController = new BillingController();
            billingController.CreateDynamiaBilling();
             
        }
    }
}
