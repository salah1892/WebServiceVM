using System;

namespace WebApp.Model
{
    public class Payement
    {
        public Payement(Guid idPayement, DateTime datePayement, float montant)
        {
            IdPayement = idPayement;
            DatePayement = datePayement;
            Montant = montant;
        }

        public Guid IdPayement { get; set; }
        public DateTime DatePayement { get; set; }
        public float Montant { get; set; }
    }
}
