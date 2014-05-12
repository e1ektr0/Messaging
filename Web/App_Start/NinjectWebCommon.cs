using System.Security.Principal;
using DataBaseModel;
using DomainEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Extensions.Conventions;
using Repositories;
using Services.Contracts;
using Services.Security;
using Services.Security.SecurityServices;
using Shared;
using Shared.Extensions;
using Shared.IoC;
using Web.SignalR.Hubs;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = IoC.Instance;
            try
            {
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //������������ �������� �������������
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

                //������������ ������������ ����������� � ����������
                kernel.Bind<ISendMessageNotification>().To<SendMessageNotification>();
                
                //��������� ���� ������������� ���������
                kernel.Bind<Context>().To<Context>().InRequestScope();

                //��������� ������ ����������� ��� Membership UserManager
                kernel.Bind<IUserStore<MembershipUser>>().ToMethod(x => new UserStore<MembershipUser>(new Context())).InRequestScope();

                //������������ �������� ������������
                kernel.Bind<IPrincipal>().ToMethod(x => HttpContext.Current.GetSafety(n => n.User) ?? new NullPrincipal()).InRequestScope();

                //������������ ��� ������� �������������
                kernel.Bind(n => n.FromAssemblyContaining<MessageSecurityService>()
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom(typeof(ISecurityService<,>))
                            .BindAllInterfaces());

                //������ �������� ����� �������� �� ������
                kernel.Bind(typeof (IContext<>)).To(typeof (ContextWrapper<>));

                //������������ ��� �����������
                kernel.Bind(n => n.FromAssemblyContaining<MessagesRepository>()
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom(typeof(IRepository<,>))
                            .BindAllInterfaces());

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

    }
}
