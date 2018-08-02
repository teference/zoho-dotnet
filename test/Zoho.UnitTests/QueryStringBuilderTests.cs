using System;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teference.Zoho.Api;
using Teference.Zoho.Api.Internals;

namespace Zoho.UnitTests
{
    [TestClass]
    public class QueryStringBuilderTests
    {
        private readonly Fixture Fixture = new Fixture();

        [TestMethod]
        public void QueryStringBuilderShouldCreateCorrectGetAllPlansUri()
        {
            // arrange
            var productId = this.Fixture.Create<string>();
            var page = this.Fixture.Create<ZsPage>();
            
            // act
            var requestUri = new QueryStringBuilder(ApiResources.ZsGetPlansAll);
            requestUri.Add("product_id", productId);
            
            var uri = page.AppendTo(requestUri).ToString();

            // assert
            var expected = string.Format("plans?product_id={0}&page={1}&per_page={2}", productId, page.PageNumber, page.RecordsPerPage);
            Assert.AreEqual(expected, uri);
        }
        
        [TestMethod]
        public void QueryStringBuilderShouldCreateCorrectGetAllSubscriptionsUri()
        {
            // arrange
            var customerId = this.Fixture.Create<string>();
            var page = this.Fixture.Create<ZsPage>();
            
            // act
            var requestUri = new QueryStringBuilder(ApiResources.ZsGetSubscriptionsAll);
            requestUri.Add("customer_id", customerId);
            
            var uri = page.AppendTo(requestUri).ToString();

            // assert
            var expected = string.Format("subscriptions?customer_id={0}&page={1}&per_page={2}", customerId, page.PageNumber, page.RecordsPerPage);
            Assert.AreEqual(expected, uri);
        }
        
        [TestMethod]
        public void QueryStringBuilderShouldCreateCorrectGetAllInvoicesUri()
        {
            // arrange
            var page = this.Fixture.Create<ZsPage>();
            
            // act
            var uri = page.AppendTo(ApiResources.ZsGetInvoicesAll);

            // assert
            var expected = string.Format("invoices?page={0}&per_page={1}", page.PageNumber, page.RecordsPerPage);
            Assert.AreEqual(expected, uri);
        }
    }
}
