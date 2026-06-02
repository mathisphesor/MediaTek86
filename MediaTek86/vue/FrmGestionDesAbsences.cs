using System;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmGestionDesAbsences : Form
    {
        private DataGridView dgvAbsences;

        public FrmGestionDesAbsences()
        {
            this.Text = "Gestion des absences";
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
                AllowUserToAddRows = false
            };

            dgvAbsences.Columns.Add("dateDebut", "Date début");
            dgvAbsences.Columns.Add("dateFin", "Date fin");
            dgvAbsences.Columns.Add("motif", "Motif");

            btnAjouter.Click += (s, e) =>
            {
                FrmAbsence frm = new FrmAbsence();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvAbsences.Rows.Add(frm.DateDebut, frm.DateFin, frm.Motif);
                }
            };

            btnModifier.Click += (s, e) =>
            {
                if (dgvAbsences.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne une absence à modifier.");
                    return;
                }

                FrmAbsence frm = new FrmAbsence(
                    dgvAbsences.CurrentRow.Cells[0].Value.ToString(),
                    dgvAbsences.CurrentRow.Cells[1].Value.ToString(),
                    dgvAbsences.CurrentRow.Cells[2].Value.ToString()
                );

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvAbsences.CurrentRow.Cells[0].Value = frm.DateDebut;
                    dgvAbsences.CurrentRow.Cells[1].Value = frm.DateFin;
                    dgvAbsences.CurrentRow.Cells[2].Value = frm.Motif;
                }
            };

            btnSupprimer.Click += (s, e) =>
            {
                if (dgvAbsences.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne une absence à supprimer.");
                    return;
                }

                dgvAbsences.Rows.Remove(dgvAbsences.CurrentRow);
            };

            this.Controls.AddRange(new Control[]
            {
                btnAjouter,
                btnModifier,
                btnSupprimer,
                dgvAbsences
            });
        }
    }
}