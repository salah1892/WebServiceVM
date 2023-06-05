using System;

namespace VM.WS.Model
{
    public class Payement
    {
        public Guid IdPayement { get; set; }
        public DateTime DatePayement { get; set; }
        public float Montant { get; set; }
    }
}
