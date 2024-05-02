using Microsoft.AspNetCore.Mvc;
using pokeapi.models;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace pokeapi.authentication
{
    public interface Iauthservies
    {
        Task<Authmodel> Registeradmin(Registermodel model);
        Task<JwtSecurityToken> Createjwttoken(Applicationuser user);
        Task<Authmodel> Login(loginmodel model);

        Task<Authmodel> Registerowner(Registermodel model);
        

    }
}
