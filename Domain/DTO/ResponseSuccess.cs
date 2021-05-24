using System;

namespace Domain.DTO
{
     public class ResponseSuccess
    {
        public Guid Id { get; set; }
        public DateTime DataExecucao { get; set; }

        public ResponseSuccess(Guid id)
        {
            Id = id;
            DataExecucao = DateTime.Now;
        }
    }
}