using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Text.Json;

namespace ApiConselho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        class Slip
        {
            public int id { get; set; }
            public string advice { get; set; }
        }

        class Retorno
        {
            public Slip slip { get; set; }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://api.adviceslip.com");
            var request = new RestRequest("advice", Method.Get);
            var response = client.Execute(request);

            if (response.IsSuccessStatusCode) 
            {
                Retorno retorno = JsonSerializer.Deserialize<Retorno>(response.Content);
                txtFrase.Text = retorno.slip.advice;
            } else
            {
                MessageBox.Show(response.ErrorMessage); 
            }
                
        }
    }
}
