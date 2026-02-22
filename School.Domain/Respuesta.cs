namespace School.Domain
{
    public class Respuesta<T>
    {
        
        public bool Exito { get; set; }
        public T Valor { get; set; } = default!;
        public string? Error { get; set; }
       
    }
}
