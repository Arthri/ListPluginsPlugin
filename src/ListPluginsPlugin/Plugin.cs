using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;

namespace ListPluginsPlugin
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {
        public override string Name => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

        public override string Description => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public override string Author => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;

        public Plugin(Main game) : base(game)
        {

        }

        public override void Initialize()
        {

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
