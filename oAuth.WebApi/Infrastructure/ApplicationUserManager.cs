using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spartane.Core.Data;
//using Spartane.Core.Classes.User;
using Spartane.Data.EF;
using Spartane.Services.CustomAuthentication;

namespace Spartane.WebApi.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {

        //Modified Code
        private ICustomAuthenticationService service = null;
        //Modified Code
        public ApplicationUserManager(IUserStore<ApplicationUser> store, ICustomAuthenticationService service)
            : base(store)
        {
            this.service = service;
        }




        public override Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType)
        {
            try
            {


                return Task.FromResult(new ClaimsIdentity()
                {
                    Actor = null,
                    // AuthenticationType="JWT",
                    BootstrapContext = null,
                    Label = null




                });

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Used to overide the basic membership authentication process
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            //try
            //{

                //var padUserInformation = service.GetUserDetails(userName, password);
                //if (padUserInformation == null)
                //    return Task.FromResult(new ApplicationUser() { Id = Convert.ToString(-1), });

                //return Task.FromResult(new ApplicationUser()
                //{
                //    UserName = padUserInformation.Clave_de_Acceso,
                //    Email = "",
                //    Id = Convert.ToString(padUserInformation.IdUsuario),
                //    FirstName = padUserInformation.Nombre,
                //    LastName = "",
                //    Level = 1,
                //    EmailConfirmed = true,
                //    //Claims = new  


                //});


           

            return Task.FromResult(new ApplicationUser()
            {
                UserName = "Administrador",
                Email = "",
                Id = "1",
                FirstName = "Administrador",
                LastName = "",
                Level = 1,
                EmailConfirmed = true,
                //Claims = new  


            });

            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }



        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<ApplicationDbContext>();

            //modified Code
            var applicationManagerDependencyResolver = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomAuthenticationService)) as ICustomAuthenticationService;


            //Modified  Code
            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext), applicationManagerDependencyResolver);

            // Configure validation logic for usernames
            appUserManager.UserValidator = new UserValidator<ApplicationUser>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            //appUserManager.EmailService = new AspNetIdentity.WebApi.Services.EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromMinutes(30)
                };
            }

            return appUserManager;
        }
    }
}