using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchulungMvc.Common.TagHelpers
{
    [HtmlTargetElement("imagedataurl")]
    public class ImageDataUrlTagHelper : TagHelper
    {
        public string? ImageMimeType { get; set; }
        public byte[]? Image { get; set; }
        public string Width { get; set; } = "120";
        public string AltSrc { get; set; } = "/images/noimg.jpg";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.Attributes.SetAttribute("width", Width);

            var src = !string.IsNullOrEmpty(ImageMimeType) && Image?.Length > 0
                ? $"data:{ImageMimeType};base64,{Convert.ToBase64String(Image)}"
                : AltSrc;

            output.Attributes.SetAttribute("src",src);
            output.TagMode = TagMode.SelfClosing;
        }
    }
}
