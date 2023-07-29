using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Lagerbestand
{
    public partial class MainWindow : Form
    {
        private Lagerbestand bestand;
        public MainWindow()
        {
            InitializeComponent();
            bestand = Lagerbestand.DatenEinlesen();

            txtb_SchraubBestand.Text = bestand.SchraubenAnzahl.ToString();
            txtb_MutternBestand.Text = bestand.MutternAnzahl.ToString();
            txtb_UnterlegBestand.Text = bestand.UnterlegAnzahl.ToString();
            txtb_DreherBestand.Text = bestand.DreherAnzahl.ToString();

            bestand.schraubenAendern += SchraubenBestand;
            bestand.mutternAendern += MutternBestand;
            bestand.unterlegAendern += UnterlegBestand;
            bestand.dreherAendern += DreherBestand;
        }
        private void bt_Speichern_Click(object sender, EventArgs e)
        {
            if (txtb_SchraubNeu.Text != "")
                bestand.SchraubenAnzahl = int.Parse(txtb_SchraubNeu.Text);

            if (txtb_MutternNeu.Text != "")
                bestand.MutternAnzahl = int.Parse(txtb_MutternNeu.Text);

            if (txtb_UnterlegNeu.Text != "")
                bestand.UnterlegAnzahl = int.Parse(txtb_UnterlegNeu.Text);

            if (txtb_DreherNeu.Text != "")
                bestand.DreherAnzahl = int.Parse(txtb_DreherNeu.Text);

            txtb_DreherNeu.Text = "";
            txtb_MutternNeu.Text = "";
            txtb_SchraubNeu.Text = "";
            txtb_UnterlegNeu.Text = "";

            Lagerbestand.DatenSchreiben(bestand);
        }
        public void SchraubenBestand(object sender, EventArgs e)
        {
            txtb_SchraubBestand.Text = bestand.SchraubenAnzahl.ToString();
        }
        public void MutternBestand(object sender, EventArgs e)
        {
            txtb_MutternBestand.Text = bestand.MutternAnzahl.ToString();
        }
        public void UnterlegBestand(object sender, EventArgs e)
        {
            txtb_UnterlegBestand.Text = bestand.UnterlegAnzahl.ToString();
        }
        public void DreherBestand(object sender, EventArgs e)
        {
            txtb_DreherBestand.Text = bestand.DreherAnzahl.ToString();
        }
    }
}
