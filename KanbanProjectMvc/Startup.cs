using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KanbanProjectMvc.Startup))]
namespace KanbanProjectMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
