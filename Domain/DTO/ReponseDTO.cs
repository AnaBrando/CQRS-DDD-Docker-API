namespace Domain.DTO
{
    public class ReponseDTO <T> where T : class
    {
        public ReponseDTO(bool Success, T Data = null)
        {
            this.Success = Success;
            this.Data = Data;
        }
        public bool Success { get; }
        public T Data { get; }
    }
    
}