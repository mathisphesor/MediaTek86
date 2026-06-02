using System;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmPersonnel : Form
    {
        public FrmPersonnel()
        {
            this.Text = "Gestion du personnel";
            this.Width = 1150;
            this.Height = 750;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblNom = new Label() { Text = "Nom :", Left = 60, Top = 40 };
            TextBox txtNom = new TextBox() { Left = 180, Top = 40, Width = 250 };

            Label lblPrenom = new Label() { Text = "Prénom :", Left = 60, Top = 80 };
            TextBox txtPrenom = new TextBox() { Left = 180, Top = 80, Width = 250 };

            Label lblTel = new Label() { Text = "Téléphone :", Left = 60, Top = 120 };
            TextBox txtTel = new TextBox() { Left = 180, Top = 120, Width = 250 };

            Label lblMail = new Label() { Text = "Mail :", Left = 60, Top = 160 };
            TextBox txtMail = new TextBox() { Left = 180, Top = 160, Width = 250 };

            Label lblService = new Label() { Text = "Service :", Left = 60, Top = 200 };
            ComboBox cboService = new ComboBox()
            {
                Left = 180,
                Top = 200,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cboService.Items.Add("administratif");
            cboService.Items.Add("médiation culturelle");
            cboService.Items.Add("prêt");

            Button btnAjouter = new Button() { Text = "Ajouter", Left = 520, Top = 40, Width = 140 };
            Button btnModifier = new Button() { Text = "Modifier", Left = 520, Top = 80, Width = 140 };
            Button btnSupprimer = new Button() { Text = "Supprimer", Left = 520, Top = 120, Width = 140 };
            Button btnAbsences = new Button() { Text = "Gérer absences", Left = 520, Top = 160, Width = 140 };

            DataGridView dgvPersonnel = new DataGridView()
            {
                Left = 60,
                Top = 280,
                Width = 1020,
                Height = 350,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false
            };

            dgvPersonnel.Columns.Add("nom", "Nom");
            dgvPersonnel.Columns.Add("prenom", "Prénom");
            dgvPersonnel.Columns.Add("tel", "Téléphone");
            dgvPersonnel.Columns.Add("mail", "Mail");
            dgvPersonnel.Columns.Add("service", "Service");

            btnAjouter.Click += (s, e) =>
            {
                if (txtNom.Text == "" || txtPrenom.Text == "" || txtTel.Text == "" ||
                    txtMail.Text == "" || cboService.Text == "")
                {
                    MessageBox.Show("Tous les champs doivent être remplis.");
                    return;
                }

                dgvPersonnel.Rows.Add(txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, cboService.Text);

                txtNom.Clear();
                txtPrenom.Clear();
                txtTel.Clear();
                txtMail.Clear();
                cboService.SelectedIndex = -1;
            };

            dgvPersonnel.SelectionChanged += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow != null)
                {
                    txtNom.Text = dgvPersonnel.CurrentRow.Cells[0].Value?.ToString();
                    txtPrenom.Text = dgvPersonnel.CurrentRow.Cells[1].Value?.ToString();
                    txtTel.Text = dgvPersonnel.CurrentRow.Cells[2].Value?.ToString();
                    txtMail.Text = dgvPersonnel.CurrentRow.Cells[3].Value?.ToString();
                    cboService.Text = dgvPersonnel.CurrentRow.Cells[4].Value?.ToString();
                }
            };

            btnModifier.Click += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne une ligne à modifier.");
                    return;
                }

                dgvPersonnel.CurrentRow.Cells[0].Value = txtNom.Text;
                dgvPersonnel.CurrentRow.Cells[1].Value = txtPrenom.Text;
                dgvPersonnel.CurrentRow.Cells[2].Value = txtTel.Text;
                dgvPersonnel.CurrentRow.Cells[3].Value = txtMail.Text;
                dgvPersonnel.CurrentRow.Cells[4].Value = cboService.Text;
            };

            btnSupprimer.Click += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne une ligne à supprimer.");
                    return;
                }

                dgvPersonnel.Rows.Remove(dgvPersonnel.CurrentRow);
            };

            btnAbsences.Click += (s, e) =>
            {
                FrmGestionDesAbsences frm = new FrmGestionDesAbsences();
                frm.ShowDialog();
            };

            this.Controls.AddRange(new Control[]
            {
                lblNom, txtNom,
                lblPrenom, txtPrenom,
                lblTel, txtTel,
                lblMail, txtMail,
                lblService, cboService,
                btnAjouter, btnModifier, btnSupprimer, btnAbsences,
                dgvPersonnel
            });
        }
    }
}