using System;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmAbsence : Form
    {
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private ComboBox cboMotif;

        public string DateDebut { get; private set; }
        public string DateFin { get; private set; }
        public string Motif { get; private set; }

        public FrmAbsence()
        {
            ConstruireInterface();
        }

        public FrmAbsence(string dateDebut, string dateFin, string motif)
        {
            ConstruireInterface();

            dtpDebut.Value = DateTime.Parse(dateDebut);
            dtpFin.Value = DateTime.Parse(dateFin);
            cboMotif.Text = motif;
        }

        private void ConstruireInterface()
        {
            this.Text = "Absence";
            this.Width = 400;
            this.Height = 260;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblDebut = new Label() { Text = "Date début :", Left = 40, Top = 40, Width = 100 };
            dtpDebut = new DateTimePicker() { Left = 160, Top = 40, Width = 160 };

            Label lblFin = new Label() { Text = "Date fin :", Left = 40, Top = 80, Width = 100 };
            dtpFin = new DateTimePicker() { Left = 160, Top = 80, Width = 160 };

            Label lblMotif = new Label() { Text = "Motif :", Left = 40, Top = 120, Width = 100 };
            cboMotif = new ComboBox()
            {
                Left = 160,
                Top = 120,
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cboMotif.Items.Add("vacances");
            cboMotif.Items.Add("maladie");
            cboMotif.Items.Add("motif familial");
            cboMotif.Items.Add("congé parental");

            Button btnValider = new Button() { Text = "Valider", Left = 80, Top = 170, Width = 100 };
            Button btnAnnuler = new Button() { Text = "Annuler", Left = 200, Top = 170, Width = 100 };

            btnValider.Click += (s, e) =>
            {
                if (cboMotif.Text == "")
                {
                    MessageBox.Show("Choisis un motif.");
                    return;
                }

                if (dtpFin.Value < dtpDebut.Value)
                {
                    MessageBox.Show("La date de fin doit être après la date de début.");
                    return;
                }

                DateDebut = dtpDebut.Value.ToShortDateString();
                DateFin = dtpFin.Value.ToShortDateString();
                Motif = cboMotif.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnAnnuler.Click += (s, e) =>
            {
                this.Close();
            };

            this.Controls.AddRange(new Control[]
            {
                lblDebut, dtpDebut,
                lblFin, dtpFin,
                lblMotif, cboMotif,
                btnValider, btnAnnuler
            });
        }
    }
}