using Slugify;
using Krovato.Application.Interfaces;

namespace Krovato.Infrastructure.Services
{
    public class SlugifyService : ISlugGenerator
    {
        private readonly SlugHelper _helper;

        public SlugifyService()
        {
            _helper = new SlugHelper();
        }

        public string GenerateSlug(string input)
        {
            return _helper.GenerateSlug(input);
        }
    }
}
