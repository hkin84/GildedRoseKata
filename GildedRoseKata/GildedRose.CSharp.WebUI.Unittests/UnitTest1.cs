using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.CSharp.WebUI.Views.Home;

namespace GildedRose.CSharp.WebUI.Unittests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemsDegradanCalidadTest()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Elixir of the Mongoose");
            expected = foundItemAntes.Quality - 1;
            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Elixir of the Mongoose");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
            
        }

        [TestMethod]
        public void CalidadDegradaDobleCuandoFechaVentaHaPasado()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Elixir of the Mongoose");
            foundItemAntes.SellIn = 0;

            expected = foundItemAntes.Quality - 2;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Elixir of the Mongoose");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadNuncaNegativa()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Elixir of the Mongoose");
            foundItemAntes.Quality = 0;

            expected = 0;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Elixir of the Mongoose");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void AgedBrieAumentaCalidad()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Aged Brie");

            expected = foundItemAntes.Quality + 1;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Aged Brie");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadItemNuncaMayorQue50()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Aged Brie");
            foundItemAntes.Quality = 50;
            expected = 50;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Aged Brie");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void SulfurasNoDisminuyeSuCalidad()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Sulfuras, Hand of Ragnaros");

            expected = foundItemAntes.Quality;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Sulfuras, Hand of Ragnaros");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadIncrenta2CuandoFaltan10Dias()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");
            foundItemAntes.SellIn = 10;
            expected = foundItemAntes.Quality + 2;
           
            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadIncrenta3CuandoFaltan5Dias()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");
            foundItemAntes.SellIn = 5;
            expected = foundItemAntes.Quality + 3;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadEs0DespuesConcierto()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");
            foundItemAntes.SellIn = 0;
            expected = 0;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Backstage passes to a TAFKAL80ETC concert");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        [TestMethod]
        public void CalidadBajax2()
        {
            // ARRANGE
            GildedRoseAdminPanel sut;
            sut = new GildedRoseAdminPanel();

            int expected;
            Item foundItemAntes = BuscarItem(sut, "Conjured Mana Cake");
            expected = foundItemAntes.Quality - 2;

            // ACT
            sut.UpdateQuality();
            Item actual = BuscarItem(sut, "Conjured Mana Cake");

            // ASSERT
            Assert.AreEqual(expected, actual.Quality);
        }

        private Item BuscarItem(GildedRoseAdminPanel gildedRoseAdminPanel, string nombre)
        {
            Item foundItem = new Item();
            foreach (Item item in gildedRoseAdminPanel.Items)
            {
                if (item.Name == nombre)
                {
                    foundItem = item;
                }
            }
            return foundItem;
        }
    }
}
