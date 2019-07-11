using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Helpers
{
    public static class EmbedBuilderExtension
    {
        public static Random Random = new Random();
        public static Color[] Colors = new[] { new Color(172, 193, 255), new Color(199, 238, 255), new Color(255, 174, 174), new Color(255, 236, 148), new Color(176, 229, 124) };
        public static EmbedBuilder WithRandomColor(this EmbedBuilder embedBuilder) {
            return embedBuilder.WithColor(Colors[Random.Next() % Colors.Length]);
        }
        public static EmbedBuilder WithCoprightFooter(this EmbedBuilder embedBuilder,string userName = null,string command = null)
        {
            return embedBuilder.WithFooter(new EmbedFooterBuilder().WithIconUrl("https://cdn.discordapp.com/avatars/491673480006205461/30abe7a1feffb0b06a1611a94fbc1248.png").WithText($"{(command == null ? String.Empty : $"Command {command}")} © HeroBot {DateTime.Now.Year} - {(userName == null ? String.Empty : $"Requested by {userName}")}"));
        }
    }
}
