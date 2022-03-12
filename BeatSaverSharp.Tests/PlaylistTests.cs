﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BeatSaverSharp.Tests.TestHelper;

namespace BeatSaverSharp.Tests
{
    [TestClass]
    public class PlaylistTests
    {
        [TestMethod]
        public async Task TestPlaylistByID()
        {
            // Re:Zero Pack
            // Bytrius, Joshabi, and Alice
            // November 23rd, 2021
            var iLoveRem = await Client.Playlist(23);
            Assert.IsNotNull(iLoveRem);
            Assert.IsFalse(iLoveRem.Empty);
            Assert.IsNotNull(iLoveRem._playlist.Owner);
            // Please do not uncurate this Helen
            Assert.IsNotNull(iLoveRem._playlist.Curator);
            
            // Testing going forward
            var whoIsRem = await iLoveRem.Next();
            Assert.IsNotNull(whoIsRem);
            Assert.IsTrue(iLoveRem._playlist.Equals(whoIsRem._playlist));
            Assert.IsTrue(whoIsRem.Empty);
            
            // And back
            var iRember = await whoIsRem.Previous();
            Assert.IsNotNull(iRember);
            Assert.IsTrue(iLoveRem._playlist.Equals(iRember._playlist));
            Assert.IsFalse(iRember.Empty);
        }
    }
}