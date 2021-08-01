/*
    ListPluginsPlugin, list loaded plugins
    Copyright (C) 2021  Arthri

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
            Console.WriteLine($"    {Name}  Copyright (C) 2021  {Author}");
            Console.WriteLine($"    This program comes with ABSOLUTELY NO WARRANTY; see {Name}.COPYING for details");
            Console.WriteLine($"    This is free software, and you are welcome to redistribute it");
            Console.WriteLine($"    under certain conditions; see {Name}.COPYING for details.");

            Commands.ChatCommands.Add(new Command("listpluginsplugin.listplugins", ListPlugins, "listplugins", "lplgs"));
        }

        private void ListPlugins(CommandArgs args)
        {
            // It's in ABGR format
            var color = Color.Purple.packedValue;

            // Flip color, because Terraria uses RGB
            color = ((color & 0x000000FF) << 16) | (color & 0x0000FF00) | ((color & 0x00FF0000) >> 16);

            // Colorize name to avoid confusion with comma-d names
            var colorTag = $"[c/{color:X}:";
            var plugins = ServerApi.Plugins.Select(p => $"{colorTag}{p.Plugin.Name.Replace("]", $"]{colorTag}]")}]");
            var result = string.Join(", ", plugins);
            args.Player.SendInfoMessage(result);
        }
    }
}
