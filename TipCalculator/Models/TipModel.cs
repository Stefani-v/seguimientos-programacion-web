namespace TipCalculator.Models
{
    public class TipModel
    {
        public decimal BillAmount { get; set; } //monto factura
        public int TipPercentage { get; set; } //porcent de la propina
        public decimal TipAmount { get; set; }// monto de la prop
        public decimal TotalToPay { get; set; }
    }
}

