//using Book.RazorPage.Infrastructure.CookieUtils;

using Book.RazorPage.Infrastructure.CookieUtils;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Services.Auth;
using Book.RazorPage.Services.Banners;
using Book.RazorPage.Services.Categories;
using Book.RazorPage.Services.Comments;
using Book.RazorPage.Services.MainPage;
using Book.RazorPage.Services.Orders;
using Book.RazorPage.Services.Products;
using Book.RazorPage.Services.Roles;
using Book.RazorPage.Services.Sellers;
using Book.RazorPage.Services.ShippingMethods;
using Book.RazorPage.Services.Sliders;
using Book.RazorPage.Services.Transactions;
using Book.RazorPage.Services.UserAddress;
using Book.RazorPage.Services.Users;

namespace Book.RazorPage.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        var baseAddress = "https://localhost:44372/api/";

        services.AddHttpContextAccessor();

        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();

        services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
        services.AddScoped<IMainPageService, MainPageService>();

        services.AddScoped<ShopCartCookieManager>();

        services.AddCookieManager();

        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ITransactionService, TransactionService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


        services.AddHttpClient<IShippingMethodService, ShippingMethodService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IBannerService, BannerService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICommentService, CommentService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IOrderService, OrderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IProductService, ProductService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IRoleService, RoleService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ISellerService, SellerService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ISliderService, SliderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IUserAddressService, UserAddressService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IUserService, UserService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


        return services;
    }
}