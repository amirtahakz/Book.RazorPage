using Book.RazorPage.Models;
using Book.RazorPage.Services.Auth;
using Book.RazorPage.Services.MainPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Book.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthService _authService;
        private readonly IMainPageService _mainPageService;
        private readonly IMemoryCache _memoryCache;
        public IndexModel(ILogger<IndexModel> logger, IAuthService authService, IMemoryCache memoryCache, IMainPageService mainPageService)
        {
            _logger = logger;
            _authService = authService;
            _memoryCache = memoryCache;
            _mainPageService = mainPageService;
        }
        public MainPageDto MainPageData { get; set; }
        public async Task OnGet()
        {
            MainPageData = await _memoryCache.GetOrCreateAsync("main-page", (entry) =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15);
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return _mainPageService.GetMainPageData();
            });
        }
    }
}