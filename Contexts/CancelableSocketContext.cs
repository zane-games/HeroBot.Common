using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Contexts
{
    public class CancelableSocketContext : SocketCommandContext
    {
        public CancelableSocketContext(DiscordSocketClient client, SocketUserMessage msg) : base(client, msg)
        {
        }

        public bool CooldownCancelled { get; set; } = false;
    }
}
