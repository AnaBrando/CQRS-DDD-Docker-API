using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Intefaces
{
    public interface IUser
    {
        string GetNome();
        Guid GetUserId();
        Guid GetEmpresaId();
        Guid GetSessaoId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaims();
        bool ValidadeClaim(string type, string value);
    }
}