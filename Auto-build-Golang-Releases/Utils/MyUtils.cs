using System.Reflection;
using Auto_build_Golang_Releases.Model;

namespace Furion.Tools.CommandLine
{
    public static class MyUtils
    {
        public static GoInfo GetGoInfo(string propName)
        {
            var propertyInfo = typeof(MyOptions).GetProperty(propName);
            return propertyInfo.GetCustomAttribute<GoInfo>();
        }
    }
}