using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

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
            Commands.ChatCommands.Add(new Command("listpluginsplugin.listplugins", ListPlugins, "listplugins", "lplgs"));
        }

        private void ListPlugins(CommandArgs args)
        {
            var plugins = ServerApi.Plugins.Select(p => $"[c/{Color.Purple}:{p.Plugin.Name}]");
            var result = string.Join(" ,", plugins);
            args.Player.SendInfoMessage(result);
        }
    }
}
