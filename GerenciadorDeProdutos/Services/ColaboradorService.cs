using GerenciadorDeProdutos.Contexts;
using GerenciadorDeProdutos.Entities;
using GerenciadorDeProdutos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Services
{
    public class ColaboradorService
    {
        private readonly ProgramContext _context;

        public ColaboradorService(ProgramContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "gerente")]
        public async Task AdicionarColaborador(ColaboradorDTO colaboradorDTO)
        {
            var novoColaborador = new Colaborador
            {
                Nome = colaboradorDTO.Nome,
                Email = colaboradorDTO.Email,
                Password = colaboradorDTO.Password,
                Cargo = colaboradorDTO.Cargo,
            };
            _context.Colaboradores.Add(novoColaborador);
            await _context.SaveChangesAsync();
        }
        [Authorize(Roles = "gerente")]
        
        public async Task<bool> AtualizarColaborador(int id, ColaboradorDTO colaboradorDTO)
        {
            var checar = await _context.Colaboradores.FirstOrDefaultAsync(x => x.Id == id);
            if (checar == null)
            {
                return false;
            }
            checar.Nome = colaboradorDTO.Nome;
            checar.Email = colaboradorDTO.Email;
            checar.Password = colaboradorDTO.Password;
            checar.Cargo = colaboradorDTO.Cargo;
            await _context.SaveChangesAsync();
            return true;
        }
        [Authorize(Roles = "gerente")]
        public async Task<bool> ExcluirColaborador(int id) 
        {
            var checar = await _context.Colaboradores.FirstOrDefaultAsync(x => x.Id == id);
            if (checar == null) 
            {
                return false;
            }
            _context.Colaboradores.Remove(checar);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
