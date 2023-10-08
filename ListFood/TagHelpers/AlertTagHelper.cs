using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ListFood.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {
        public string? Texto { get; set; }

        public string? Attribute { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                switch (Attribute)
                {
                    case "dismissible":
                        {
                            output.TagName = "div";
                            output.Attributes.SetAttribute("class", "alert alert-dismissible alert-secondary");
                            output.Content.SetContent(Texto);
                        }
                        break;
                    default:
                        {
                            output.TagName = "div";
                            output.Attributes.SetAttribute("class", "alert alert-success");
                            output.Content.SetContent(Texto);
                        }
                        break;
                }
            }
        }
    }
}
