using Microsoft.AspNetCore.Authentication.Certificate;


namespace NetlyncAPI.Services
{
    public static class AuthenticationExtension
    {
        public static void ConfigureAuthetication(this IServiceCollection services)
        {
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate(options =>
            {
                options.AllowedCertificateTypes = CertificateTypes.SelfSigned;
                options.Events = new CertificateAuthenticationEvents
                {
                    OnCertificateValidated = context =>
                    {
                        var validationService = context.HttpContext.RequestServices.GetService<CertificateValidationService>();

                        if (validationService != null && validationService.ValidateCertificate(context.ClientCertificate))
                        {
                            context.Success();
                        }
                        else
                        {
                            context.Fail("invalid cert");
                        }

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.Fail("invalid cert");
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();
        }
    }
}
