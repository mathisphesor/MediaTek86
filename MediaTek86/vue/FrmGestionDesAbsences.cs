using System;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    public class FrmGestionDesAbsences : Form
    {
        private Controleur controleur;
        private int idpersonnel;
        private DataGridView dgvAbsences;

        public FrmGestionDesAbsences(Controleur controleur, int idpersonnel, string nomPrenom)
        {
            this.controleur = controleur;
            this.idpersonnel = idpersonnel;

            this.Text = "Absences de " + nomPrenom;
            this.Width = 800;
            this.Height = 550;
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnAjouter = new Button() { Text = "Ajouter", Left = 40, Top = 30, Width = 120 };
            Button btnModifier = new Button() { Text = "Modifier", Left = 180, Top = 30, Width = 120 };
            Button btnSupprimer = new Button() { Text = "Supprimer", Left = 320, Top = 30, Width = 120 };

            dgvAbsences = new DataGridView()
            {
                Left = 40,
                Top = 90,
                Width = 700,
                Height = 350,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            ChargerAbsences();

            btnAjouter.Click += (s, e) =>
            {
                FrmAbsence frm = new FrmAbsence(controleur);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    controleur.AjouterAbsence(idpersonnel, frm.DateDebut, frm.DateFin, frm.IdMotif);
                    ChargerAbsences();
                }
            };

            btnModifier.Click += (s, e) =>
            {
                if (dgvAbsences.CurrentRow == null) return;

                DateTime ancienneDateDebut = Convert.ToDateTime(dgvAbsences.CurrentRow.Cells["datedebut"].Value);
                DateTime datefin = Convert.ToDateTime(dgvAbsences.CurrentRow.Cells["datefin"].Value);
                int idmotif = Convert.ToInt32(dgvAbsences.CurrentRow.Cells["idmotif"].Value);

                FrmAbsence frm = new FrmAbsence(controleur, ancienneDateDebut, datefin, idmotif);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    controleur.ModifierAbsence(
                        idpersonnel,
                        ancienneDateDebut,
                        frm.DateDebut,
                        frm.DateFin,
                        frm.IdMotif
                    );

                    ChargerAbsences();
                }
            };

            btnSupprimer.Click += (s, e) =>
            {
                if (dgvAbsences.CurrentRow == null) return;

                DialogResult rep = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cette absence ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo
                );

                if (rep == DialogResult.Yes)
                {
                    DateTime datedebut = Convert.ToDateTime(dgvAbsences.CurrentRow.Cells["datedebut"].Value);
                    controleur.SupprimerAbsence(idpersonnel, datedebut);
                    ChargerAbsences();
                }
            };

            this.Controls.AddRange(new Control[]
            {
                btnAjouter,
                btnModifier,
                btnSupprimer,
                dgvAbsences
            });
        }

        private void ChargerAbsences()
        {
            dgvAbsences.DataSource = controleur.GetLesAbsences(idpersonnel);

            if (dgvAbsences.Columns["idpersonnel"] != null)
                dgvAbsences.Columns["idpersonnel"].Visible = false;

            if (dgvAbsences.Columns["idmotif"] != null)
                dgvAbsences.Columns["idmotif"].Visible = false;
        }
    }
}