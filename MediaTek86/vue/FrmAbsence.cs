using System;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    public class FrmAbsence : Form
    {
        private Controleur controleur;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private ComboBox cboMotif;

        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public int IdMotif { get; private set; }

        public FrmAbsence(Controleur controleur)
        {
            this.controleur = controleur;
            ConstruireInterface();
        }

        public FrmAbsence(Controleur controleur, DateTime datedebut, DateTime datefin, int idmotif)
        {
            this.controleur = controleur;
            ConstruireInterface();

            dtpDebut.Value = datedebut;
            dtpFin.Value = datefin;
            cboMotif.SelectedValue = idmotif;
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

            cboMotif.DataSource = controleur.GetLesMotifs();
            cboMotif.DisplayMember = "libelle";
            cboMotif.ValueMember = "idmotif";

            Button btnValider = new Button() { Text = "Valider", Left = 80, Top = 170, Width = 100 };
            Button btnAnnuler = new Button() { Text = "Annuler", Left = 200, Top = 170, Width = 100 };

            btnValider.Click += (s, e) =>
            {
                if (cboMotif.SelectedValue == null)
                {
                    MessageBox.Show("Choisis un motif.");
                    return;
                }

                if (dtpFin.Value < dtpDebut.Value)
                {
                    MessageBox.Show("La date de fin doit être après la date de début.");
                    return;
                }

                DateDebut = dtpDebut.Value;
                DateFin = dtpFin.Value;
                IdMotif = Convert.ToInt32(cboMotif.SelectedValue);

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