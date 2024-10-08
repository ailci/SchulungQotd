using Microsoft.AspNetCore.Razor.TagHelpers;
using static System.Net.WebRequestMethods;

namespace SchulungQotd.Mvc.TagHelpers
{
    // <image-data-url....
    //[HtmlTargetElement("pommes-currywurst")] //Alternativer Tag-Name
    public class ImageDataUrlTagHelper : TagHelper
    {
        public string? ImageMimeType { get; set; }
        public byte[]? Image { get; set; }
        public string Width { get; set; } = "120";
        public string AltSrc { get; set; } = "/images/noimg.jpg";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";  //Der Html-Tag der erstellt wird =>  <img 
            output.Attributes.SetAttribute("width", Width);  // => <img width="Width"

            var src = !string.IsNullOrEmpty(ImageMimeType) && Image is not null && Image?.Length > 0
                ? $"data:{ImageMimeType};base64,{Convert.ToBase64String(Image)}"
                : AltSrc;

            output.Attributes.SetAttribute("src",src); // => <img width="Width" src="src">
            output.TagMode = TagMode.SelfClosing;  // => <img width="Width" src="src" />
        }
    }
}
