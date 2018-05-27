using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThemeTest.Infrastructure
{
    public class ThemePageViewLocationExpander : IViewLocationExpander
    {
        private const string ThemeKey = "theme";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.TryGetValue(ThemeKey, out string theme))
            {
                viewLocations = new[] {
                    $"/Themes/{theme}/{{1}}/{{0}}.cshtml",
                    $"/Themes/{theme}/Shared/{{0}}.cshtml",
                    $"/Themes/{theme}/{{0}}.cshtml",
                }.Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values[ThemeKey] = "Dark";

            //Uncomment this to enable default layout
            //context.Values[ThemeKey] = string.Empty;
        }
    }
}
