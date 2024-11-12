using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchulungQotd.Mvc.TagHelpers
{
    public class ImageDataUriTagHelper : TagHelper
    {
        public string? ImageMimeType { get; set; }
        public byte[]? Image { get; set; }
        public string Width { get; set; } = "120";
        public string AltSrc { get; set; } = "https://via.placeholder.com/150";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
        }
    }
}
