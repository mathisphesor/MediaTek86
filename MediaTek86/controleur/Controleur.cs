using MediaTek86.dal;
using System;
using System.Data;

namespace MediaTek86.controleur
{
    public class Controleur
    {
        private readonly ResponsableAccess responsableAccess;
        private readonly PersonnelAccess personnelAccess;
        private readonly AbsenceAccess absenceAccess;
        private readonly ServiceAccess serviceAccess;
        private readonly MotifAccess motifAccess;

        public Controleur()
        {
            responsableAccess = new ResponsableAccess();
            personnelAccess = new PersonnelAccess();
            absenceAccess = new AbsenceAccess();
            serviceAccess = new ServiceAccess();
            motifAccess = new MotifAccess();
        }

        public bool ControleAuthentification(string login, string pwd)
        {
            return responsableAccess.ControleAuthentification(login, pwd);
        }

        public DataTable GetLesPersonnels()
        {
            return personnelAccess.GetLesPersonnels();
        }

        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idservice)
        {
            personnelAccess.AjouterPersonnel(nom, prenom, tel, mail, idservice);
        }

        public void ModifierPersonnel(int idpersonnel, string nom, string prenom, string tel, string mail, int idservice)
        {
            personnelAccess.ModifierPersonnel(idpersonnel, nom, prenom, tel, mail, idservice);
        }

        public void SupprimerPersonnel(int idpersonnel)
        {
            personnelAccess.SupprimerPersonnel(idpersonnel);
        }

        public DataTable GetLesAbsences(int idpersonnel)
        {
            return absenceAccess.GetLesAbsences(idpersonnel);
        }

        public void AjouterAbsence(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif)
        {
            absenceAccess.AjouterAbsence(idpersonnel, datedebut, datefin, idmotif);
        }

        public void ModifierAbsence(int idpersonnel, DateTime ancienneDateDebut, DateTime nouvelleDateDebut, DateTime datefin, int idmotif)
        {
            absenceAccess.ModifierAbsence(idpersonnel, ancienneDateDebut, nouvelleDateDebut, datefin, idmotif);
        }

        public void SupprimerAbsence(int idpersonnel, DateTime datedebut)
        {
            absenceAccess.SupprimerAbsence(idpersonnel, datedebut);
        }

        public DataTable GetLesServices()
        {
            return serviceAccess.GetLesServices();
        }

        public DataTable GetLesMotifs()
        {
            return motifAccess.GetLesMotifs();
        }
    }
}