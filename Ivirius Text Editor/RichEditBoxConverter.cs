using Windows.UI.Text;
using Windows.UI.Xaml.Controls;

namespace Ivirius_Text_Editor
{
    public class RichEditBoxConverter
    {
        public static string GetText(RichEditBox RichEditor)
        {
            RichEditor.Document.GetText(TextGetOptions.FormatRtf, out var Text);
            var Range = RichEditor.Document.GetRange(0, Text.Length);
            Range.GetText(TextGetOptions.FormatRtf, out var Value);
            return Value;
        }
    }
}
