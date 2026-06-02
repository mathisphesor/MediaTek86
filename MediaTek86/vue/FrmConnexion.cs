using System;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmConnexion : Form
    {
        public FrmConnexion()
        {
            this.Text = "MediaTek86 - Connexion";
            this.Width = 450;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitre = new Label();
            lblTitre.Text = "MediaTek86";
            lblTitre.Left = 160;
            lblTitre.Top = 30;
            lblTitre.Width = 150;
            lblTitre.Font = new System.Drawing.Font("Arial", 16);

            Label lblLogin = new Label();
            lblLogin.Text = "Login :";
            lblLogin.Left = 70;
            lblLogin.Top = 90;
            lblLogin.Width = 100;

            TextBox txtLogin = new TextBox();
            txtLogin.Left = 180;
            txtLogin.Top = 90;
            txtLogin.Width = 180;

            Label lblPwd = new Label();
            lblPwd.Text = "Mot de passe :";
            lblPwd.Left = 70;
            lblPwd.Top = 130;
            lblPwd.Width = 100;

            TextBox txtPwd = new TextBox();
            txtPwd.Left = 180;
            txtPwd.Top = 130;
            txtPwd.Width = 180;
            txtPwd.PasswordChar = '*';

            Button btnConnexion = new Button();
            btnConnexion.Text = "Se connecter";
            btnConnexion.Left = 150;
            btnConnexion.Top = 190;
            btnConnexion.Width = 140;

            btnConnexion.Click += (s, e) =>
            {
                if (txtLogin.Text == "" || txtPwd.Text == "")
                {
                    MessageBox.Show("Veuillez saisir le login et le mot de passe.");
                    return;
                }

                FrmPersonnel frm = new FrmPersonnel();
                frm.Show();
                this.Hide();
            };

            this.Controls.Add(lblTitre);
            this.Controls.Add(lblLogin);
            this.Controls.Add(txtLogin);
            this.Controls.Add(lblPwd);
            this.Controls.Add(txtPwd);
            this.Controls.Add(btnConnexion);
        }
    }
}