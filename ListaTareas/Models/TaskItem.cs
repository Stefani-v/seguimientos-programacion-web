namespace To_doList.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }= string.Empty; //string.Empty es equivalente a "". Es mejor poner esto que un igual a null
        //aunque también se puede poner "". Con el null se corre el riesgo de tener un NullReferenceException 
        public bool IsCompleted { get; set; }
    }
}
