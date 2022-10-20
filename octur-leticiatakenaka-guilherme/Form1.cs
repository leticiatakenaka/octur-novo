using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace octur_leticiatakenaka_guilherme
{
    public partial class Form1 : Form
    {
        DataTable dadosTabela = new DataTable();
        DataTable dadosTabelaVolta = new DataTable();
        Estados estados = new Estados();

        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "fDQkkWqxk9mueX6L7oyZLyqEPtMviv3vbJLtqsMF",
            BasePath = "https://octur-331ee-default-rtdb.firebaseio.com",
        };

        IFirebaseClient client;
        private void Form1_Load(object sender, EventArgs e)
        {
            cbPessoas.SelectedIndex = 0;
            client = new FireSharp.FirebaseClient(config);
            dadosTabela.Columns.Add("Empresa");
            dadosTabela.Columns.Add("Partida");
            dadosTabela.Columns.Add("Chegada");
            dadosTabela.Columns.Add("Preço");
            dadosTabela.Columns.Add("PaisDestino");
            dadosTabela.Columns.Add("DataPartida");

            dadosTabelaVolta.Columns.Add("Empresa");
            dadosTabelaVolta.Columns.Add("Partida");
            dadosTabelaVolta.Columns.Add("Chegada");
            dadosTabelaVolta.Columns.Add("Preço");
            dadosTabelaVolta.Columns.Add("PaisOrigem");
            dadosTabelaVolta.Columns.Add("DataPartida");

            dataGridViewVolta.DataSource = dadosTabelaVolta;
            dataGridViewIda.DataSource = dadosTabela;

            carregaVoos();

            encheComboDestino(comboBox1);
            encheComboOrigem(comboBox2);

            radioButton1.Checked = true;

            dataGridViewIda.Columns[4].Visible = false;
            dataGridViewIda.Columns[5].Visible = false;
            dataGridViewVolta.Columns[5].Visible = false;
            dataGridViewVolta.Columns[4].Visible = false;

            dateTimeIda.CustomFormat = " ";
            dateTimeIda.Format = DateTimePickerFormat.Custom;

            dateTimeVolta.CustomFormat = " ";
            dateTimeVolta.Format = DateTimePickerFormat.Custom;
        }
        private void carregaVoos()
        {
            FirebaseResponse resp1 = client.Get("ListaVoos/");
            Dictionary<string, Voo> getVoo = resp1.ResultAs<Dictionary<string, Voo>>();
            if (getVoo != null)
            {
                foreach (var get in getVoo)
                {
                    var result = Convert.ToDateTime(get.Value.Partida);
                    var data = result.ToString("dd/MM/yyyy");

                    dadosTabela.Rows.Add(
                        get.Value.Aviao,
                        get.Value.Partida,
                        get.Value.Chegada,
                        get.Value.Preco,
                        get.Value.Pais + " / " + get.Value.Destino,
                        data
                        );
                    dadosTabelaVolta.Rows.Add(
                        get.Value.Aviao,
                        get.Value.Partida,
                        get.Value.Chegada,
                        get.Value.Preco,
                        get.Value.Pais + " / " + get.Value.Origem,
                        data
                        );
                }
            }
        }
        int valorIda;
        int valorVolta = 0;
        int total;
        private void dataGridViewIda_SelectionChanged(object sender, EventArgs e)

        {
            if ((radioButton2.Checked) && (dataGridViewIda.Rows.Count > 0))
            {
                string removeString = dataGridViewIda.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorIda = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + 0);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";

            }
            else if(dataGridViewIda.Rows.Count > 0)
            {

                string removeString = dataGridViewIda.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorIda = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + valorVolta);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";
            }
        }

        private void dataGridViewVolta_SelectionChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && dataGridViewVolta.Rows.Count > 0)
            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + 0);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";

            }
            else if (dataGridViewVolta.Rows.Count > 0)
            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + valorVolta + 40);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";
            }

        }

        private void cbPessoas_DropDownClosed(object sender, EventArgs e)
        {
            if ((radioButton2.Checked) && (dataGridViewVolta.Rows.Count > 0))
            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + 0);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";

            }
            else if (dataGridViewIda.Rows.Count > 0)

            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + valorVolta);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ { total + 40}";
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra Realizada!");
            Close();
        }


        private void encheComboDestino(ComboBox combo)
        {
            FirebaseResponse response = client.Get("ListaVoos/");
            Dictionary<string, Voo> getVoo = response.ResultAs<Dictionary<string, Voo>>();

            if (getVoo != null)
            {
                foreach (var get in getVoo)
                {
                    combo.Items.Add(
                        get.Value.Pais + " / " + get.Value.Destino
                        );
                }
            }
        }

        private void encheComboOrigem(ComboBox combo)
        {
            FirebaseResponse response = client.Get("ListaVoos/");
            Dictionary<string, Voo> getVoo = response.ResultAs<Dictionary<string, Voo>>();

            if (getVoo != null)
            {
                foreach (var get in getVoo)
                {
                    combo.Items.Add(
                        get.Value.Pais + " / " + get.Value.Origem
                        );
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dadosTabela.DefaultView.RowFilter = $"[PaisDestino] LIKE '{comboBox1.Text}'";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dadosTabelaVolta.DefaultView.RowFilter = $"[PaisOrigem] LIKE '{comboBox2.Text}'";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
            removeString = removeString.Replace("R$ ", "");
            valorVolta = Convert.ToInt32(removeString);
            total = Convert.ToInt32(cbPessoas.Text) * (valorIda + 0);
            subtotalText.Text = $"R$ {total}";
            txtEmbarque.Text = $"R$ 40";
            totalText.Text = $"R$ {total+40}";

            dataGridViewVolta.Visible = !radioButton2.Checked;
            label6.Visible = !radioButton2.Checked;
            dateTimeVolta.Visible = !radioButton2.Checked;
            labelVolta.Visible = !radioButton2.Checked;
            dataGridViewIda.Height = radioButton2.Checked ? 250 : 112;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && dataGridViewVolta.Rows.Count > 0)
            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + 0);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";

            }
            else if (dataGridViewIda.Rows.Count > 0)

            {
                string removeString = dataGridViewVolta.CurrentRow.Cells["Preço"].Value.ToString();
                removeString = removeString.Replace("R$ ", "");
                valorVolta = Convert.ToInt32(removeString);
                total = Convert.ToInt32(cbPessoas.Text) * (valorIda + valorVolta);
                subtotalText.Text = $"R$ {total}";
                totalText.Text = $"R$ {total + 40}";
            }
        }

        private void dateTimeIda_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 )
            {
                dateTimeIda.Format = DateTimePickerFormat.Short;
                var dataCalendario = dateTimeIda.Value;
                dadosTabela.DefaultView.RowFilter = $"[DataPartida] LIKE '{dataCalendario.ToString("dd/MM/yyyy")}'";
            }
            else if (comboBox1.SelectedIndex >=0) { 
            dateTimeIda.Format = DateTimePickerFormat.Short;
            var dataCalendario = dateTimeIda.Value;

            dadosTabela.DefaultView.RowFilter = $"[DataPartida] LIKE '{dataCalendario.ToString("dd/MM/yyyy")}' AND [PaisDestino] LIKE '{comboBox1.Text}'";
            }
        }

        private void dateTimeVolta_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                dateTimeVolta.Format = DateTimePickerFormat.Short;
                var dataCalendario = dateTimeVolta.Value;
                dadosTabelaVolta.DefaultView.RowFilter = $"[DataPartida] LIKE '{dataCalendario.ToString("dd/MM/yyyy")}'";
            }
            else if (comboBox2.SelectedIndex >= 0 ) { 
            dateTimeVolta.Format = DateTimePickerFormat.Short;
            var dataCalendario = dateTimeVolta.Value;

                dadosTabelaVolta.DefaultView.RowFilter = $"[DataPartida] LIKE '{dataCalendario.ToString("dd/MM/yyyy")}' AND [PaisOrigem] LIKE '{comboBox2.Text}'";
            }
        }
    }
}