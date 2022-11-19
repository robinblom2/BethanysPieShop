using BethanysPieShop.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopTests.TagHelpers
{
    public class EmailTagHelperTests
    {
        // Verifies that the EmailTagHelper generates the expected output
        [Fact]
        public void Generate_Email_Link()
        {
            // Arrange
            EmailTagHelper emailTagHelper = new EmailTagHelper() { Address = "test@bethanyspieshop.com", Content = "Email" }; ;         // We create a taghelper which will be passed as input/context
            var tagHelperContext = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), string.Empty);

            var content = new Mock<TagHelperContent>();                                                                                 // We create the expected output
            var tagHelperOutput = new TagHelperOutput("a", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(content.Object));

            // Act
            emailTagHelper.Process(tagHelperContext, tagHelperOutput);

            // Assert
            Assert.Equal("Email", tagHelperOutput.Content.GetContent());
            Assert.Equal("a", tagHelperOutput.TagName);
            Assert.Equal("mailto:test@bethanyspieshop.com", tagHelperOutput.Attributes[0].Value);
        }
    }
}
