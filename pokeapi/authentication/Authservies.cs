using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pokeapi.models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pokeapi.authentication
{
    public class Authservies : Iauthservies
    {
        private readonly UserManager<Applicationuser> _Usermanagr;
        private readonly IConfiguration config;

        public Authservies(UserManager<Applicationuser> Usermanagr, IConfiguration config)
        {
            _Usermanagr = Usermanagr;
            this.config = config;
        }

       

        public async Task<Authmodel> Registeradmin(Registermodel model)
        {
            var cheekemil = await _Usermanagr.FindByEmailAsync(model.Email);
            var cheekuser = await _Usermanagr.FindByNameAsync(model.Email);
            if (cheekemil is not null || cheekuser is not null)
            {
                return new Authmodel { Message = "the user is already exist " };
            }
           
            Applicationuser newuser = new()
            {
                Email = model.Email,
                Name = model.Username,
                UserName = model.Username,
                Lastname = model.Lastname,
                Firstname = model.Firstname
            };
           var result = await _Usermanagr.CreateAsync(newuser , model.Password);
            if (!result.Succeeded)
            {
                string error = string.Empty;
                foreach (var err in result.Errors)
                {
                    error += $"{err.Description},";
                    _ = error.TrimEnd();
                }
                return new Authmodel { Message = error };
            }
            _ = await _Usermanagr.AddToRoleAsync(newuser, "Admin");
            var jwttoken = await Createjwttoken(newuser);
            return new Authmodel
            {
                Email = newuser.Email ,
                Experationdate = jwttoken.ValidTo ,
                Isauthanticated = true , 
                Roles = new List<string> { "Admin" } ,
                Token = new JwtSecurityTokenHandler().WriteToken(jwttoken),
                Username = newuser.Name
            };
        }
        public async Task<Authmodel> Login(loginmodel model)
        {
            
            var user = await _Usermanagr.FindByNameAsync(model.Name);
           
            if (user is null)
            {
                return new Authmodel { Message = " you need to signup " };
            }
            if (!string.Equals(user.Email, model.Email, StringComparison.OrdinalIgnoreCase))
            {
                return new Authmodel { Message = " the data is incorrect " };
            }
            var chekerorr = await _Usermanagr.CheckPasswordAsync(user, model.Password);
            if(!chekerorr)
            {
                return new Authmodel { Message = " the pssword is incorrect " };
            }
            var roles = await _Usermanagr.GetRolesAsync(user);
            var jwttoken = await Createjwttoken(user);
    
            return new Authmodel
            {
                Email = user.Email,
                Experationdate = jwttoken.ValidTo,
                Isauthanticated = true,
                Roles = (List<string>)roles,
                Token = new JwtSecurityTokenHandler().WriteToken(jwttoken),
                Username = user.Name
            };
        }
        public async Task<JwtSecurityToken> Createjwttoken(Applicationuser user)
        {
            var userclaims = await _Usermanagr.GetClaimsAsync(user);
            var roles = await _Usermanagr.GetRolesAsync(user);
            var rolesclaim = new List<Claim>();
            foreach (var role in roles)
            {
                rolesclaim.Add(new Claim("roles", role));
            }
            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub,user.Name),
                new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Email,user.Email),
                new Claim ("uid",user.Id)
            }
            .Union(userclaims).Union(rolesclaim);
            SecurityKey securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            SigningCredentials signincred = new(securitykey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audince"],
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToDouble(config["JWT:Durationofdays"])),
                signingCredentials: signincred
                );
            return token;

        }

        public async Task<Authmodel> Registerowner(Registermodel model)
        {
            var cheekemil = await _Usermanagr.FindByEmailAsync(model.Email);
            var cheekuser = await _Usermanagr.FindByNameAsync(model.Email);
            if (cheekemil is not null || cheekuser is not null)
            {
                return new Authmodel { Message = "the Owner is already exist " };
            }
           
            Applicationuser newuser = new()
            {
                Email = model.Email,
                Name = model.Username,
                UserName = model.Username,
                Lastname = model.Lastname,
                Firstname = model.Firstname
            };
            var result = await _Usermanagr.CreateAsync(newuser, model.Password);
            if (!result.Succeeded)
            {
                string error = string.Empty;
                foreach (var err in result.Errors)
                {
                    error += $"{err.Description},";
                    _ = error.TrimEnd();
                }
                return new Authmodel { Message = error };
            }
            await _Usermanagr.AddToRoleAsync(newuser, "Owner");
            var jwttoken = await Createjwttoken(newuser);
            return new Authmodel
            {
                Email = newuser.Email,
                Experationdate = jwttoken.ValidTo,
                Isauthanticated = true,
                Roles = new List<string> { "Owner" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwttoken),
                Username = newuser.Name
            };
        }

       
    }
}
