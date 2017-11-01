using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmountInWords.DataInterfaces;
using AmountInWords.Utilities;
using AmountInWords.DataRepository;
using AmountInWords.DataModel;
using AmountInWords.DataStore;

namespace AmountInWords.UnitTest {
    [TestClass]
    public class RepositoryTest {
        [TestMethod]
        public void TestGetApplicationId() {
            IAIWGlobals _dbGlobals = new AIWGlobalsRepository();
            Assert.IsTrue(_dbGlobals.GetApplicationId() != string.Empty);
            
        }
        [TestMethod]
        public void TestSaveTFNTransactionLog() {
            IAIWTransactionLogs _dbTransactions = new AIWTransactionLogsRepository();
            Assert.IsTrue(_dbTransactions.SaveAIWTransactionLog(new AIWTransactionLog() {                
                CreateBy = "191.1.1.0",
                CreateDate = DateTime.Now,
                Amount = "1500.40",
                Name = "Charith",
                Words = "ONE THOUSAND FIVE HUNDRED DOLLARS AND FOURTY CENTS"
            }) > 0);

        }
        
    }
}
