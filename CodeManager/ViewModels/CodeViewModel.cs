using CodeManager.Models;

namespace CodeManager.ViewModels
{
    public class CodeViewModel
    {
        public CodeViewModel()
        {
            Codes = new();
            Page = 1;
        }

        public List<Code> Codes { get; set; }

        public string? Search { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }

        public int StartPages { get; set; }

        public int EndPages { get; set; }
    }
}
