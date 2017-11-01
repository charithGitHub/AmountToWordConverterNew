using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmountInWords.BusinessContract;
using AmountInWords.BusinessImplementation;
using AmountInWords.Utilities;

namespace AmountInWords.UnitTest {
    [TestClass]
    public class BusinessLogicTest {

        public BusinessLogicTest() {
            IApplication app = new Application();
            app.ResolveDependencies();            
        }

        [TestMethod]
        public void TestValidApplication() {
            
            Assert.IsTrue(DependencyFactory.Resolve<IApplication>().IsValidApplication("APPAIW"));
                        
        }

        [TestMethod]
        public void TestNumberWithoutDecimals() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("100");
            Assert.Equals(result, "One HUNDRED DOLLARS");
        }

        [TestMethod]
        public void TestNumberWithTeen() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("15");
            Assert.Equals(result, "FIFTEEN DOLLARS");
        }

        [TestMethod]
        public void TestNumberBellowTen() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("8");
            Assert.Equals(result, "EIGHT DOLLARS");
        }

        [TestMethod]
        public void TestNumberThousand() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("2500");
            Assert.Equals(result, "TWO THOUSAND FIVE HUNDRED");
        }

        [TestMethod]
        public void TestNumberThousandwithCents() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("2430.50");
            Assert.Equals(result, "TWO THOUSAND FOUR HUNDRED AND THIRTY DOLLARS AND FIFTY CENTS");
        }

        [TestMethod]
        public void TestNumberMillions() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("1000000.50");
            Assert.Equals(result, "ONE MILLION DOLLARS AND FIFTY CENTS");
        }

        [TestMethod]
        public void TestNumberFiveDigit() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("25050");
            Assert.Equals(result, "TWENTY FIVE THOUSAND AND FIFTY DOLLARS");
        }

        [TestMethod]
        public void TestNumberBlank() {
            var result = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter("");
            Assert.Equals(result, "");
        }

    }
}
