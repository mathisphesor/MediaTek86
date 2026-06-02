using System;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86.vue
{
    public class FrmConnexion : Form
    {
        private Controleur controleur;

        public FrmConnexion()
        {
            controleur = new Controleur();

            this.Text = "MediaTek86 - Connexion";
            this.Width = 450;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitre = new Label() { Text = "MediaTek86", Left = 150, Top = 30, Width = 200 };
            Label lblLogin = new Label() { Text = "Login :", Left = 70, Top = 90 };
            TextBox txtLogin = new TextBox() { Left = 180, Top = 90, Width = 180 };

            Label lblPwd = new Label() { Text = "Mot de passe :", Left = 70, Top = 130, Width = 100 };
            TextBox txtPwd = new TextBox() { Left = 180, Top = 130, Width = 180, PasswordChar = '*' };

            Button btnConnexion = new Button() { Text = "Se connecter", Left = 150, Top = 190, Width = 140 };

            btnConnexion.Click += (s, e) =>
            {
                if (controleur.ControleAuthentification(txtLogin.Text, txtPwd.Text))
                {
                    FrmPersonnel frm = new FrmPersonnel(controleur);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            };

            this.Controls.AddRange(new Control[] { lblTitre, lblLogin, txtLogin, lblPwd, txtPwd, btnConnexion });
        }
    }
}