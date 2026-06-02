using System;
using System.Data;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    public class FrmPersonnel : Form
    {
        private Controleur controleur;
        private DataGridView dgvPersonnel;
        private ComboBox cboService;
        private TextBox txtNom, txtPrenom, txtTel, txtMail;

        public FrmPersonnel(Controleur controleur)
        {
            this.controleur = controleur;

            this.Text = "Gestion du personnel";
            this.Width = 1150;
            this.Height = 750;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblNom = new Label() { Text = "Nom :", Left = 60, Top = 40 };
            txtNom = new TextBox() { Left = 180, Top = 40, Width = 250 };

            Label lblPrenom = new Label() { Text = "Prénom :", Left = 60, Top = 80 };
            txtPrenom = new TextBox() { Left = 180, Top = 80, Width = 250 };

            Label lblTel = new Label() { Text = "Téléphone :", Left = 60, Top = 120 };
            txtTel = new TextBox() { Left = 180, Top = 120, Width = 250 };

            Label lblMail = new Label() { Text = "Mail :", Left = 60, Top = 160 };
            txtMail = new TextBox() { Left = 180, Top = 160, Width = 250 };

            Label lblService = new Label() { Text = "Service :", Left = 60, Top = 200 };
            cboService = new ComboBox()
            {
                Left = 180,
                Top = 200,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Button btnAjouter = new Button() { Text = "Ajouter", Left = 520, Top = 40, Width = 140 };
            Button btnModifier = new Button() { Text = "Modifier", Left = 520, Top = 80, Width = 140 };
            Button btnSupprimer = new Button() { Text = "Supprimer", Left = 520, Top = 120, Width = 140 };
            Button btnAbsences = new Button() { Text = "Gérer absences", Left = 520, Top = 160, Width = 140 };

            dgvPersonnel = new DataGridView()
            {
                Left = 60,
                Top = 280,
                Width = 1020,
                Height = 350,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            ChargerServices();
            ChargerPersonnel();

            dgvPersonnel.SelectionChanged += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow != null)
                {
                    txtNom.Text = dgvPersonnel.CurrentRow.Cells["nom"].Value.ToString();
                    txtPrenom.Text = dgvPersonnel.CurrentRow.Cells["prenom"].Value.ToString();
                    txtTel.Text = dgvPersonnel.CurrentRow.Cells["tel"].Value.ToString();
                    txtMail.Text = dgvPersonnel.CurrentRow.Cells["mail"].Value.ToString();
                    cboService.SelectedValue = dgvPersonnel.CurrentRow.Cells["idservice"].Value;
                }
            };

            btnAjouter.Click += (s, e) =>
            {
                if (!ChampsRemplis()) return;

                controleur.AjouterPersonnel(
                    txtNom.Text,
                    txtPrenom.Text,
                    txtTel.Text,
                    txtMail.Text,
                    Convert.ToInt32(cboService.SelectedValue)
                );

                ChargerPersonnel();
                ViderChamps();
            };

            btnModifier.Click += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow == null || !ChampsRemplis()) return;

                int idpersonnel = Convert.ToInt32(dgvPersonnel.CurrentRow.Cells["idpersonnel"].Value);

                controleur.ModifierPersonnel(
                    idpersonnel,
                    txtNom.Text,
                    txtPrenom.Text,
                    txtTel.Text,
                    txtMail.Text,
                    Convert.ToInt32(cboService.SelectedValue)
                );

                ChargerPersonnel();
                ViderChamps();
            };

            btnSupprimer.Click += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow == null) return;

                DialogResult rep = MessageBox.Show(
                    "Voulez-vous vraiment supprimer ce personnel ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo
                );

                if (rep == DialogResult.Yes)
                {
                    int idpersonnel = Convert.ToInt32(dgvPersonnel.CurrentRow.Cells["idpersonnel"].Value);
                    controleur.SupprimerPersonnel(idpersonnel);
                    ChargerPersonnel();
                    ViderChamps();
                }
            };

            btnAbsences.Click += (s, e) =>
            {
                if (dgvPersonnel.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne un personnel.");
                    return;
                }

                int idpersonnel = Convert.ToInt32(dgvPersonnel.CurrentRow.Cells["idpersonnel"].Value);
                string nomPrenom = dgvPersonnel.CurrentRow.Cells["nom"].Value + " " +
                                   dgvPersonnel.CurrentRow.Cells["prenom"].Value;

                FrmGestionDesAbsences frm = new FrmGestionDesAbsences(controleur, idpersonnel, nomPrenom);
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

        private void ChargerPersonnel()
        {
            dgvPersonnel.DataSource = controleur.GetLesPersonnels();

            if (dgvPersonnel.Columns["idpersonnel"] != null)
                dgvPersonnel.Columns["idpersonnel"].Visible = false;

            if (dgvPersonnel.Columns["idservice"] != null)
                dgvPersonnel.Columns["idservice"].Visible = false;
        }

        private void ChargerServices()
        {
            cboService.DataSource = controleur.GetLesServices();
            cboService.DisplayMember = "nom";
            cboService.ValueMember = "idservice";
        }

        private bool ChampsRemplis()
        {
            if (txtNom.Text == "" || txtPrenom.Text == "" || txtTel.Text == "" ||
                txtMail.Text == "" || cboService.SelectedValue == null)
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return false;
            }

            return true;
        }

        private void ViderChamps()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtTel.Clear();
            txtMail.Clear();
            cboService.SelectedIndex = -1;
        }
    }
}