namespace API.Configuration
{
    public static class CookieConfiguration
    {
        public const int CookieValidityTime = 60; // set in config
        public const string CookieIdentifier = "CookieIdentifier"; // set in config

        public static IServiceCollection AddCookieConfiguration(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.EventsType = typeof(RevokeAuthenticationEvents);
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(CookieValidityTime);
                options.LoginPath = "/";
                options.LogoutPath = "/";
                options.Cookie = new CookieBuilder
                {
                    Name = CookieIdentifier,
                    IsEssential = true,
                };
            });

            services.AddScoped<RevokeAuthenticationEvents>();

            return services;
        }
    }
}
