using System;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teference.Zoho.Api;
using Teference.Zoho.Api.Internals;

namespace Zoho.UnitTests
{
    [TestClass]
    public class ZsPageContextTests
    {
        private readonly Fixture Fixture = new Fixture();

        [TestMethod]
        public void QueryStringBuilderShouldCreateCorrectGetAllPlansUri()
        {
            // arrange
            var pageContext = this.Fixture.Create<ZsPageContext>();
            
            // act
            var page = pageContext.NextPage();

            // assert
            Assert.AreEqual(pageContext.PageNumber + 1, page.PageNumber);
            Assert.AreEqual(pageContext.RecordsPerPage, page.RecordsPerPage);
        }
    }
}
