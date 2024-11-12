using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchulungQotd.Mvc.TagHelpers
{
    //Standard => <email>
    //Custom => <kontakt>
    [HtmlTargetElement("kontakt")]
    public class EmailTagHelper : TagHelper
    {
        public string DisplayName { get; set; }
        public string Adresse { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // <a...         

            var href = !string.IsNullOrEmpty(Adresse)
                ? $"mailto:{Adresse}"
                : "";
            output.Attributes.SetAttribute("href", href);
            output.Content.SetContent(DisplayName);
        }
    }
}
