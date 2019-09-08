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
