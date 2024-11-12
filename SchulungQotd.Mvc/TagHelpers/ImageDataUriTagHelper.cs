using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchulungQotd.Mvc.TagHelpers
{
    // <imagedataurl....
    public class ImageDataUriTagHelper : TagHelper
    {
        public string? ImageMimeType { get; set; }
        public byte[]? Image { get; set; }
        public string Width { get; set; } = "120";
        public string AltSrc { get; set; } = "/images/noimg.jpg";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";  // <img 
            output.Attributes.SetAttribute("width", Width);  // <img width="150"

            // <img src="Inhalt"
            var src = !string.IsNullOrEmpty(ImageMimeType) && Image is not null && Image?.Length > 0
                ? $"data:{ImageMimeType};base64,{Convert.ToBase64String(Image)}"
                : AltSrc;

            output.Attributes.SetAttribute("src", src);
            output.TagMode = TagMode.SelfClosing;
        }
    }
}
