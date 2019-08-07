using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using WebApplication1.Configuration;

namespace WebApplication1.Services
{
    public class RoleService
    {
        private readonly SocketGuild _guild;
        public readonly Config Config;

        public RoleService(Config config, DiscordSocketClient client)
        {
            Config = config;
            _guild = client.Guilds.FirstOrDefault(x => x.Id == Config.GuildId);
        }

        public async Task AssignRoleAsync(ulong userId, IEnumerable<string> roles)
        {
            var rolesToAdd = new List<IRole>();
            foreach (var x in roles)
            {
                var roleId = Config.DiscordRoles[x];
                rolesToAdd.Add(_guild.GetRole(roleId));
            }

            await _guild.GetUser(userId).AddRolesAsync(rolesToAdd);
        }
    }
}