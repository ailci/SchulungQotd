using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchulungMvc.Common.TagHelpers
{
    //  <email display-name="admin" adresse="mailto:admin@admin.com">admin</email>
    //  => <a href="mailto:admin@admin.com">admin</a>
    public class EmailTagHelper : TagHelper
    {
        //PascalCase wird in lower-kebab-case übersetzt
        public string? DisplayName { get; set; }
        public string? Adresse { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";  //ersetzt <email> mit <a>
            var adresse = $"mailto:{Adresse}";
            output.Attributes.SetAttribute("href",adresse);
            output.Content.SetContent(DisplayName);
        }
    }
}
