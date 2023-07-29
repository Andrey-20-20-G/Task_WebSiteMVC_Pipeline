using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Task_WebSiteMVC_Pipeline.Extentions
{
    public static class EnumExtentions
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "Неопределенный";
        }
    }
}
