using Book.RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : BaseRazorPage where TFilterParam : BaseFilterParam, new()
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }

    public BaseRazorFilter()
    {
        FilterParams = new TFilterParam();
    }
}