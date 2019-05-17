using Autofac;
using Autofac.Integration.Mvc;
using KirsEntityModulMVC.Core.Interaces;
using KursEntityModulMVC.BuisnessLogic;
using KursEntityModulMVC.SQLDataAcces;
using KursEntityModulMVC.SQLDataAcces.Entities;
using KursEntityModulMVC.SQLDataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursEntityModulMVC
{
    public class Injection
    {
        public static void Inject()
        {
            CoursesDbContext context = new CoursesDbContext();
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
           // builder.RegisterType<DevManager>().As<IDevManager>();
            builder.Register(c => new Repository<Author,int>(context)).As<IGenericRepository<Author,int>>();
            builder.Register(c => new Repository<Book,Guid>(context)).As<IGenericRepository<Book,Guid>>();
            builder.Register(c => new Manager<Author,int>(new Repository<Author,int>(context))).As<IManager<Author,int>>();
            builder.Register(c => new Manager<Book,Guid>(new Repository<Book,Guid>(context))).As<IManager<Book,Guid>>();
            //builder.RegisterType<TeamManager>().As<ITeamManager>();
            //builder.Register(c => new TeamRepository(context)).As<ITeamRepository>();
            // builder.RegisterInstance<IDevRepository>(new DevRepository(context));

            //builder.RegisterType<GroupManager>().As<IGroupManager>();
            //builder.RegisterInstance<IGroupRepository>(new GroupRepository(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}