using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEnginePOC;

namespace RuleEnginePOC.Test
{
    [TestClass]
    public class RuleSyntaxTests
    {

        [TestMethod]
        public void Rule_empty_rule_should_not_be_valid()
        {
            string rule = "";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_null_rule_should_not_be_valid()
        {
            string rule = null;
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_true_rule_should_be_valid()
        {
            string rule = "true";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_Ja_rule_should_not_be_valid()
        {
            string rule = "Ja";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_false_rule_should_be_valid()
        {
            string rule = "false";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_Syntax_ServiceCode_is_1_should_be_valid()
        {
            string rule = "ServiceCode = \"1\"";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rule_Syntax_ServiceCode_prs_1_should_not_be_valid()
        {
            string rule = "ServiceCode % \"1\"";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rule_Syntax_ServiceCode_should_not_be_valid()
        {
            string rule = "ServiceCode";
            bool result = RuleEngine.IsValidSyntax(rule);
            Assert.IsFalse(result);
        }




    }
}
