using CodeManager.Models;
using CodeManager.ViewModels;

namespace CodeManager.Services.Interfaces
{
    public interface ICodeService
    {
        Task AddCode(Code code);
        Task UpdateCode(Code code);
        Task DeleteCode(Code code);

        Task<Code?> GetCodeById(int id);

        CodeViewModel GetAllCodes(int page);
        CodeViewModel GetAllCodesBySearch(int page, string search);
    }
}
