using ChipmunkEventListing.Models;
using System;
using Xunit;

namespace ChipmunkEventListing.Tests
{
    public class EventTest
    {
         [Fact]
        public void EventShouldNotBeEmpty()
        {
            Event e = new Event { OwnerID = "1", EventDescription = "This is an event"};
            Assert.Equal("1", e.OwnerID);
            Assert.Equal("This is an event", e.EventDescription);
        }
    }
}
