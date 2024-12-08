using GerenciadorDeProdutos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using GerenciadorDeProdutos.Contexts;

namespace GerenciadorDeProdutos.Controllers
{
        [Route("api/[controller]")]
        public class TokenController : Controller
        {
            private readonly IConfiguration _configuration;
            private readonly ProgramContext _context;

            // Construtor com injeção de dependência
            public TokenController(IConfiguration configuration, ProgramContext context)
            {
                _configuration = configuration;
                _context = context;
            }

            [HttpPost]
            public IActionResult TokenRequest([FromBody] Colaborador request)
            {
                if (string.IsNullOrWhiteSpace(request.Nome) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new { message = "Nome e senha são obrigatórios." });
                }

                // Consulta o colaborador no banco de dados usando _context
                var colaborador = _context.Colaboradores
                    .FirstOrDefault(c => c.Nome == request.Nome && c.Password == request.Password);

                if (colaborador == null)
                {
                    return Unauthorized(new { message = "Credenciais inválidas." });
                }

            var role = colaborador.Cargo.ToLower();
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, colaborador.Nome),
            new Claim(ClaimTypes.Role, role)
        };

                // Criação da chave e do token
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "felepe.net",
                    audience: "felepe.net",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    nome = colaborador.Nome,
                    cargo = colaborador.Cargo
                });
            }
        }

    }
