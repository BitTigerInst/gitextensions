﻿using NUnit.Framework;
using ReleaseNotesGenerator;
using FluentAssertions;

namespace GitExtensionsTest.Plugins.ReleaseNotesGenerator
{
    [TestFixture]
    public class MainFixture
    {
        [Test]
        public void FormatStringTest()
        {
            HtmlFragment.To8DigitString(15).Should().Be("00000015");
        }

        [Test]
        public void CreateHtmlFormatClipboardDataObjectTest()
        {
            var dataObject = HtmlFragment.CreateHtmlFormatClipboardDataObject("<p>Hallo</p>");
            dataObject.GetFormats().Length.Should().Be(2);
            dataObject.GetText().Should().Be("<p>Hallo</p>");
            ((string)dataObject.GetData("HTML Format")).Should().Be(@"Version:0.9
StartHTML:00000097
EndHTML:00000177
StartFragment:00000131
EndFragment:00000143
<html><body>
<!--StartFragment--><p>Hallo</p><!--EndFragment-->
</body></html>");
        }

        [Test, RequiresSTA]
        public void CopyToClipboard()
        {
            HtmlFragment.CopyToClipboard("<p>Hallo</p>");
            // Verify manually that the content can be pasted as text and into MS Word or
            // LibreOffice Writer. There it should create a formatted table.
        }
    }
}
