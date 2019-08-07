using System.Collections.Generic;

namespace WebApplication1.Configuration
{
    public class Config
    {
        public string DiscordToken { get; set; }
        public string DiscordId { get; set; }
        public string DiscordSecret { get; set; }
        public string FasId { get; set; }
        public string FasSecret { get; set; }
        public ulong GuildId { get; set; }
        public Dictionary<string, ulong> DiscordRoles { get; set; }
        public Dictionary<string, string> RolesConditions { get; set; }
    }
}