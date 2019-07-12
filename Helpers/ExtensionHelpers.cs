using Discord;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HeroBot.Common.Helpers
{
    public static class ExtensionHelper
    {
        public static string SanitzeEntity(this string entity)
        {
            return entity.Replace("Entity", string.Empty);
        }

        public static string SanitizAssembly(this string module)
        {
            return module.Replace("Assembly", string.Empty);
        }

        public static bool HasPrefixes(this IUserMessage message, ref int argpos, params char[] prefixes)
        {
            var content = message.Content;
            var shouldContinue = false;

            if (string.IsNullOrWhiteSpace(content))
                shouldContinue = false;

            foreach (var prefix in prefixes)
            {
                if (content[0] == prefix)
                {
                    shouldContinue = true;
                    break;
                }
            }

            argpos = shouldContinue ? 1 : 0;
            return shouldContinue;
        }

        public static IServiceCollection AddImplementedInterfaces(this IServiceCollection service, Assembly assembly,
            params Type[] interfaces)
        {
            if (assembly is null || interfaces.Length is 0)
                return service;

            foreach (var inter in interfaces)
            {
                var matches = assembly.GetTypes().Where(x => !x.IsAbstract && inter.IsAssignableFrom(x))
                    .ToArray();

                if (matches.Length is 0)
                    continue;

                foreach (var match in matches)
                    service.AddSingleton(match);
            }
            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, params Type[] types)
        {
            if (types.Length is 0)
                return service;

            foreach (var type in types)
            {
                service.AddSingleton(type);
            }

            return service;
        }

        public static double ConvertToMb(this long value)
        {
            return (double)value / 1024 / 1024;
        }

        public static Cast CastTo<Cast>(this object obj)
        {
            return obj is Cast val ? val : default;
        }

        public static Cast CastAs<Cast>(this object obj)
        {
            return (Cast)obj;
        }

        public static string ObjectToString(this object obj)
        {
            var sf = new StringBuilder();
            var properties = obj.GetType().GetRuntimeProperties();

            var max = properties.Max(x => x.Name.Length) + 5;
            foreach (var property in properties)
            {
                var space = new string(' ', max - property.Name.Length);
                var value = property.GetValue(obj);

                sf.Append($"{property.Name}{space}: {value}\n");
            }

            return $"```ini\n===== [ {obj.GetType().Name} Information ] =====\n{sf.ToString()}\n```";
        }
    }
}
