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
    public partial class Form2 : Form
    {
        DataTable dadosTabela = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        //Conexão com banco de dados
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "fDQkkWqxk9mueX6L7oyZLyqEPtMviv3vbJLtqsMF",
            BasePath = "https://octur-331ee-default-rtdb.firebaseio.com",
        };

        IFirebaseClient client;

        // metodo para carregar o dataGridView
        private void Form2_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            dadosTabela.Columns.Add(" ", typeof(bool));
            dadosTabela.Columns.Add("Destinos");
            dadosTabela.Columns.Add("Pais");
            dadosTabela.Columns.Add("Estados");

            dataGridViewDestinos.DataSource = dadosTabela;
            carregaVoos();
            carregaPaises();
            dataGridViewDestinos.Columns[2].Visible = false;
            dataGridViewDestinos.Columns[3].Visible = false;
        }

        // metodos para carregar dados no dataGridView conectados ao banco de dados
        private void carregaOrigens()
        {

        }

        private void carregaPaises()
        {
            Pais paises = new Pais();
            foreach (var pais in paises.paises)
            {
                cbPaises.Items.Add(pais);
            }
        }

        private void carregaVoos()
        {
            FirebaseResponse resp1 = client.Get("ListaVoos/");
            Dictionary<string, Voo> getVoo = resp1.ResultAs<Dictionary<string, Voo>>();
            if (getVoo != null)
            {
                foreach (var get in getVoo)
                {
                    dadosTabela.Rows.Add(
                        get.Value.isSelected,
                        get.Value.Destino + " " + "/" + " " + get.Value.Origem,
                        get.Value.Origem,
                        get.Value.Destino
                        );
                }
            }
        }

        // metodos relacionadas a filtragem de dados 
        bool valor = false;

        public void filtroTexto(string coluna, string dados, string coluna2)
        {
            while (valor == false)
            {
                dadosTabela.DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%' AND [{2}] = '{3}'", coluna, dados, coluna2, valor);
                break;
            }
        }
        public void filtroTexto2(string coluna, string dados, string coluna2)
        {
            dadosTabela.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}'+'{2}'", coluna, dados, coluna2);
        }
        public void filtroTodos(string coluna, string linha)
        {
            dadosTabela.DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", coluna, linha);
        }

        public void filtroCheckBox(string coluna, bool valor)
        {
            dadosTabela.DefaultView.RowFilter = String.Format("[{0}] = '{1}' ", coluna, valor);
            this.valor = valor;
        }

        private void limparFiltro()
        {
            dadosTabela.DefaultView.RowFilter = null;
            cbOrigens.SelectedIndex = -1;
            cbPaises.SelectedIndex = -1;
        }

        private void filtroDuplo(string coluna1, string dados, string coluna2, string dados2)
        {
            dadosTabela.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}' AND [{2}] LIKE '{3}'", coluna1, dados, coluna2, dados2);
        }

        //mexer aki
        private void filtroTriplo(string coluna1, string dados, string coluna2, string dados2, string coluna3, bool dados3)
        {
            dadosTabela.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}' AND [{2}] LIKE '{3}' AND [{4}] = '{5}'", coluna1, dados, coluna2, dados2, coluna3, dados3);
        }

        // Funçoes das ferramentas da tela

        private void btnTodos_CheckedChanged(object sender, EventArgs e)
        {
            filtroDuplo("Pais", cbPaises.Text, "Estados", cbOrigens.Text);
            //filtroTodos("Destinos", cbPaises.Text);
            //filtroTodos("Destinos", cbOrigens.Text);
        }

        private void btnMarcados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPaises.SelectedIndex < 0 && cbOrigens.SelectedIndex <0) 
            {
                filtroCheckBox(" ", true);
            }
            else if (cbPaises.SelectedIndex >= 0 && cbOrigens.SelectedIndex >= 0)
            {
                filtroTriplo("Pais", cbPaises.Text, "Estados", cbOrigens.Text, " ", true);
            }
        }

        private void limpar_Click(object sender, EventArgs e)
        {
            limparFiltro();
        }

        private void origens_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estados estados = new Estados();

            if (cbPaises.SelectedIndex == 0)
            {
                cbOrigens.Items.Clear();
                foreach (var origem in estados.brasil)
                {
                    cbOrigens.Items.Add(origem);
                }
            }
            else if (cbPaises.SelectedIndex == 1)
            {
                cbOrigens.Items.Clear();
                foreach (var origem in estados.portugal)
                {
                    cbOrigens.Items.Add(origem);
                }
            }
            filtroTodos("Pais", cbPaises.Text);
            //filtroTexto("Destinos", cbPaises.Text, " ");
        }

        private void paises_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estados origens = new Estados();

            if (cbPaises.SelectedIndex == 0)
            {
               // cbOrigens.Items.Clear();
                foreach (var origem in origens.brasil)
                {
                    cbOrigens.Items.Add(origem);
                }
            }
            else if (cbPaises.SelectedIndex == 1)
            {
               // cbOrigens.Items.Clear();
                foreach (var origem in origens.portugal)
                {
                    cbOrigens.Items.Add(origem);
                }
            }

            filtroDuplo("Pais", cbPaises.Text, "Estados", cbOrigens.Text);
            //filtroTodos("Destinos", cbPaises.Text);
            //filtroTodos("Destinos", cbOrigens.Text);
        }

        private void origem_Click(object sender, EventArgs e)
        {

        }
    }
}
