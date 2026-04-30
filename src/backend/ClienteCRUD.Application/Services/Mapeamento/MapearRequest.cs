using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Domain.Entities;

namespace ClienteCRUD.Application.Services.Mapeamento
{
    public static class MapearRequest
    {
        public static User RequestParaEntidade(RequestRegistrarUsuario request)
        {
            return new User()
            {
                Nome = request.Nome,
                Email = request.Email
            };
        }
    }
}
