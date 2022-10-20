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
    public partial class Form3 : Form
    {
        DataTable vervoos = new DataTable();
        Estados estados = new Estados(); 

        public Form3()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "fDQkkWqxk9mueX6L7oyZLyqEPtMviv3vbJLtqsMF",
            BasePath = "https://octur-331ee-default-rtdb.firebaseio.com",
        };

        IFirebaseClient client;
        private void Form3_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            chegadaDataHora.Format = DateTimePickerFormat.Custom;
            chegadaDataHora.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            vervoos.Columns.Add("Aviao");
            vervoos.Columns.Add("Destino");
            vervoos.Columns.Add("Partida");
            vervoos.Columns.Add("Chegada");
            vervoos.Columns.Add("Preço");
            vervoos.Columns.Add("ID");
            vervoos.Columns.Add("Pais");
            vervoos.Columns.Add("Partida Data");
            vervoos.Columns.Add("Origem");

            tabelaForm3.DataSource = vervoos;

            //Desabilita a coluna do ID e Pais, Origem e data
            //Colunas que criei para conseguir filtrar pela tabela kk
            tabelaForm3.Columns[8].Visible = false;
            tabelaForm3.Columns[7].Visible = false;
            tabelaForm3.Columns[6].Visible = false;
            tabelaForm3.Columns[5].Visible = false;

            //Esconde o botao de salvar (só mostra quando edita)
            btnSalvar.Hide();

            //Esconde campo de ID
            idText.Hide();
            cbDestinoAdd.Enabled = false;
            cbOrigemAdd.Enabled = false;
            carregaVoos();
            carregaListaPaises(cbPais);
            carregaListaPaises(cbPaisesAdd);
            carregaListaAvioes(cbAviaoAdd);
            cbOrigem.Enabled = false;
            partidaTimePicker.Enabled = false;


            partidaTimePicker.CustomFormat = " ";
            partidaTimePicker.Format = DateTimePickerFormat.Custom;
        }

        //Adiciona voo
        private async void addVooBtn_Click(object sender, EventArgs e)
        {
            var voo = new Voo
            {
                Pais = cbPaisesAdd.Text,
                Origem = cbOrigemAdd.Text,
                Aviao = cbAviaoAdd.Text,
                Destino = cbDestinoAdd.Text,
                Partida = partidaHora.Value.ToString(),
                Chegada = chegadaDataHora.Value.ToString(),
                Preco = precoText.Text,
            };

            FirebaseResponse response = await client.PushAsync(path: "ListaVoos/", voo);
            Voo result = response.ResultAs<Voo>();
            MessageBox.Show("Voo de " + voo.Origem + " para " + voo.Destino + " foi adicionado!", "Octur");
            vervoos.Rows.Clear();
            limpaCampos();
            carregaVoos();
        }

        //Remove Voo
        private void btnRemoverVoo_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete(path: "ListaVoos/" + tabelaForm3.CurrentRow.Cells["ID"].Value.ToString());
            MessageBox.Show("Voo deletado", "Octur");
            vervoos.Rows.Clear();
            carregaVoos();
        }

        //Busca voos no banco
        private void carregaVoos()
        {
            FirebaseResponse response = client.Get("ListaVoos/");
            Dictionary<string, Voo> getVoo = response.ResultAs<Dictionary<string, Voo>>();

            if (getVoo != null)
            {
                foreach (var get in getVoo)
                {
                    var result = Convert.ToDateTime(get.Value.Partida);
                    var data = result.ToString("dd/MM/yyyy");

                    vervoos.Rows.Add(
                        get.Value.Aviao,
                        get.Value.Destino,
                        get.Value.Partida,
                        get.Value.Chegada,
                        get.Value.Preco,
                        get.Key.ToString(),
                        get.Value.Pais,
                        data,
                        get.Value.Origem
                        );
                }
            }
        }

        //Busca paises
        private void carregaListaPaises(ComboBox cb)
        {
            Pais paises = new Pais();
            foreach (var pais in paises.paises)
            {
                cb.Items.Add(pais);
            }
        }

        //Busca aviões
        private void carregaListaAvioes(ComboBox cb)
        {
            Aviao avioes = new Aviao();
            foreach (var aviao in avioes.aviao)
            {
                cb.Items.Add(aviao);
            }
        }

        //Botao de editar voo
        private void btnEditar_Click(object sender, EventArgs e)
        {
            addVooBtn.Hide();
            btnSalvar.Show();

            FirebaseResponse response = client.Get("ListaVoos/" + tabelaForm3.CurrentRow.Cells["ID"].Value.ToString());
            Voo result = response.ResultAs<Voo>();

            cbPaisesAdd.Text = result.Pais;
            cbOrigemAdd.Text = result.Origem;
            cbDestinoAdd.Text = result.Destino;
            partidaHora.Value = Convert.ToDateTime(result.Partida);
            chegadaDataHora.Value = Convert.ToDateTime(result.Chegada);
            precoText.Text = result.Preco;
            cbAviaoAdd.Text = result.Aviao;
            idText.Text = tabelaForm3.CurrentRow.Cells["ID"].Value.ToString();

            enableBtnDesOrig();
            addVooBtn.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbPaisesAdd.SelectedIndex >= 0)
            {
                cbDestinoAdd.Enabled = true;
            }
            else
            {
                cbDestinoAdd.Enabled = false;
            }
            editaVoo(idText.Text);
            limpaCampos();
        }

        private void editaVoo(string key)
        {
            var voo = new Voo
            {
                Pais = cbPaisesAdd.Text,
                Origem = cbOrigemAdd.Text,
                Aviao = cbAviaoAdd.Text,
                Destino = cbDestinoAdd.Text,
                Partida = partidaHora.Value.ToString(),
                Chegada = chegadaDataHora.Value.ToString(),
                Preco = precoText.Text
            };

            FirebaseResponse response = client.Update(path: "ListaVoos/" + key, voo);

            MessageBox.Show("Voo Editado", "Octur");
            btnSalvar.Hide();
            vervoos.Rows.Clear();
            carregaVoos();
        }

        private void cbPaisesAdd_DropDownClosed(object sender, EventArgs e)
        {
            enableBtnDesOrig();

            if (cbPaisesAdd.SelectedIndex == 0)
            {
                cbDestinoAdd.Items.Clear();
                cbOrigemAdd.Items.Clear();

                foreach (var destino in estados.brasil)
                {
                    cbDestinoAdd.Items.Add(destino);
                }

                foreach (var origem in estados.brasil)
                {
                    cbOrigemAdd.Items.Add(origem);
                }
            }
            else if (cbPaisesAdd.SelectedIndex == 1)
            {
                cbDestinoAdd.Items.Clear();
                cbOrigemAdd.Items.Clear();

                foreach (var destino in estados.portugal)
                {
                    cbDestinoAdd.Items.Add(destino);
                }

                foreach (var origem in estados.portugal)
                {
                    cbOrigemAdd.Items.Add(origem);
                }
            }
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estados origens = new Estados();
            cbOrigem.Enabled = true;

            if (partidaTimePicker.Enabled)
            {
                var dataCalendario = partidaTimePicker.Value;
                filtro("Pais", cbPais.Text,"Origem",cbOrigem.Text, "Partida Data", dataCalendario.ToString("dd/MM/yyyy"));
            }
            if (cbPais.SelectedIndex == 0)
            {
                cbOrigem.Items.Clear();
                foreach (var origem in origens.brasil)
                {
                    cbOrigem.Items.Add(origem);
                }
            }
            else if (cbPais.SelectedIndex == 1)
            {
                cbOrigem.Items.Clear();
                foreach (var origem in origens.portugal)
                {
                    cbOrigem.Items.Add(origem);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            partidaTimePicker.Format = DateTimePickerFormat.Short;
            var dataCalendario = partidaTimePicker.Value;
            filtro("Pais", cbPais.Text, "Origem", cbOrigem.Text, "Partida Data", dataCalendario.ToString("dd/MM/yyyy"));
        }

        public void limpaCampos()
        {
            cbPaisesAdd.SelectedIndex = -1;
            cbDestinoAdd.SelectedIndex = -1;
            cbOrigemAdd.SelectedIndex = -1;
            partidaHora.Value = DateTime.Now;
            chegadaDataHora.Value = DateTime.Now;
            precoText.Text = "";
            cbAviaoAdd.SelectedIndex = -1;
            idText.Text = "";
        }

        private void enableBtnDesOrig()
        {
            if (cbPaisesAdd.SelectedIndex >= 0)
            {
                cbDestinoAdd.Enabled = true;
                cbOrigemAdd.Enabled = true;
            }
            else
            {
                cbDestinoAdd.Enabled = false;
                cbOrigemAdd.Enabled = false;
            };
        }

        public void filtro(string coluna, string dados, string coluna2, string dados2,string coluna3, string dados3)
        {
            vervoos.DefaultView.RowFilter = $"[{coluna}] LIKE '{dados}' AND [{coluna2}] LIKE '{dados2}' AND [{coluna3}] LIKE '{dados3}'";
        }

        private void cbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partidaTimePicker.Enabled)
            {
                var dataCalendario = partidaTimePicker.Value;
                filtro("Pais", cbPais.Text, "Origem", cbOrigem.Text, "Partida Data", dataCalendario.ToString("dd/MM/yyyy"));
            }
            partidaTimePicker.Enabled = true;
            toolTip1.SetToolTip(tabelaForm3, "Selecione uma data para filtrar");

        }

        //Essa função é para que quando editar, venha os dados, pois a função do DropDown não funciona
        //nesse caso de edição, pois o usuário não aciona o DropDown
        private void cbPaisesAdd_TextChanged(object sender, EventArgs e)
        {
            Estados estados = new Estados();

            enableBtnDesOrig();

            if (cbPaisesAdd.SelectedIndex == 0)
            {
                cbDestinoAdd.Items.Clear();
                cbOrigemAdd.Items.Clear();

                foreach (var destino in estados.brasil)
                {
                    cbDestinoAdd.Items.Add(destino);
                }

                foreach (var origem in estados.brasil)
                {
                    cbOrigemAdd.Items.Add(origem);
                }
            }
            else if (cbPaisesAdd.SelectedIndex == 1)
            {
                cbDestinoAdd.Items.Clear();
                cbOrigemAdd.Items.Clear();

                foreach (var destino in estados.portugal)
                {
                    cbDestinoAdd.Items.Add(destino);
                }

                foreach (var origem in estados.portugal)
                {
                    cbOrigemAdd.Items.Add(origem);
                }
            }
        }

    }
}
