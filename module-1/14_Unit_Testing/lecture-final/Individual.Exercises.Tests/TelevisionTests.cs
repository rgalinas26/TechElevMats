using Individual.Exercises.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Exercises.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void WhenTVIsCreated_DefaultValuesAreSet()
        {
            // Arrange - nothing to arrange

            // Act - create a new television
            Television tv = new Television();
            Television tv2 = new Television();

            // Assert - make sure default values are set properly
            Assert.IsFalse(tv.IsOn, "The TV should be OFF when first created.");
            Assert.AreEqual(3, tv.CurrentChannel, "The TV should be tuned in to channel 3 when first created.");
            Assert.AreEqual(2, tv.CurrentVolume, "The TV volume should be set to 2 when first created.");


            // Change the channel on TV and make sure the channel doesn't change on tv2
            tv.ChangeChannel(15);
            Assert.AreEqual(3, tv2.CurrentChannel, "Changing the channel on one tv should not have changed the channel on the second tv.");
        }

        [TestMethod]
        public void ChangingChannelToNegative_ShouldLeaveChannelAsIs()
        {
            // Arrange - create a new tv and turn it on, store the current channel
            Television tv = new Television();
            tv.TurnOn();
            int oldChannel = tv.CurrentChannel;

            // Act - change the channel to -1
            tv.ChangeChannel(-1);

            // Assert - make sure channel is still the original value.
            Assert.AreEqual(oldChannel, tv.CurrentChannel, 
                "Changing the channel to -1 should have left the current channel alone.");
        }
    }
}
