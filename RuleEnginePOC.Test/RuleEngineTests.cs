using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEnginePOC;

namespace RuleEnginePOC.Test
{
    [TestClass]
    public class RuleEngineTests
    {

        [TestMethod]
        public void Rule_true_should_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
            };
            var rule = "true";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_false_should_not_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
            };
            var rule = "false";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Rule_service_code_1_should_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
            };
            var rule = "ServiceCode = \"1\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_service_code_0_should_not_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "0",
            };
            var rule = "ServiceCode = \"1\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_service_code_1_and_service_owner_A_should_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
                ServiceOwner = "A",
            };
            var rule = "ServiceCode = \"1\" AND ServiceOwner = \"A\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_service_code_1_and_service_owner_B_should_not_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
                ServiceOwner = "A",
            };
            var rule = "ServiceCode = \"1\" AND ServiceOwner = \"B\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_service_code_1_and_service_owner_A_Or_ShipmentHandler_SH1_should_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
                ServiceOwner = "C",
                ShipmentHandler = "SH1"
            };
            var rule = "(ServiceCode = \"1\" AND ServiceOwner = \"A\") OR ShipmentHandler = \"SH1\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_service_code_1_and_service_owner_A_Or_ShipmentHandler_SH9_should_not_match()
        {
            var shipment = new Shipment()
            {
                ServiceCode = "1",
                ServiceOwner = "C",
                ShipmentHandler = "SH1"
            };
            var rule = "(ServiceCode = \"1\" AND ServiceOwner = \"A\") OR ShipmentHandler = \"SH9\"";
            var result = RuleEngine.MatchRules(shipment, rule);
            Assert.IsFalse(result);
        }

    }

}
