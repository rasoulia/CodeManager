using CodeManager.Models;
using CodeManager.Services.Interfaces;
using CodeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodeManager.Services
{
    public class CodeService : ICodeService
    {
        private readonly CodeDbContext _context;

        public CodeService(CodeDbContext context)
        {
            _context = context;
        }

        public async Task AddCode(Code code)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            await _context.AddAsync(code);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateCode(Code code)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            _context.Update(code);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteCode(Code code)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            _context.Remove(code);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Code?> GetCodeById(int id)
        {
            Code? code = await _context.Set<Code>().FirstOrDefaultAsync(c => c.Id == id);

            code ??= new();

            return await Task.FromResult(code);
        }

        public CodeViewModel GetAllCodes(int page)
        {
            IQueryable<Code> allCodes = _context.Set<Code>().OrderByDescending(c => c.CreatedDate);

            int skip = (page - 1) * 12;
            int take = 12;
            int total = (int)Math.Ceiling(allCodes.Count() / (double)12);

            CodeViewModel codeViewModel = new()
            {
                Codes = allCodes.Skip(skip).Take(take).ToList(),
                Page = page,
                TotalPages = total,
                StartPages = (page - 5) > 0 ? page - 5 : 1,
                EndPages = (page + 5) > total ? total : page + 5,
            };

            return codeViewModel;
        }

        public CodeViewModel GetAllCodesBySearch(int page, string search)
        {
            IQueryable<Code> allCodes = _context.Set<Code>().OrderByDescending(c => c.CreatedDate).Where(c => c.Title!.Contains(search) || c.Description!.Contains(search));

            int skip = (page - 1) * 12;
            int take = 12;
            int total = (int)Math.Ceiling(allCodes.Count() / (double)12);

            CodeViewModel codeViewModel = new()
            {
                Codes = allCodes.Skip(skip).Take(take).ToList(),
                Page = page,
                TotalPages = total,
                StartPages = (page - 5) > 0 ? page - 5 : 1,
                EndPages = (page + 5) > total ? total : page + 5,
                Search = search
            };

            return codeViewModel;
        }
    }
}
