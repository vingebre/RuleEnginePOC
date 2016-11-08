using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RuleEnginePOC
{
    public class RuleEngine
    {

        public static bool MatchRules(Shipment shipment, string rules)
        {
            var lambda = System.Linq.Dynamic.DynamicExpression.ParseLambda(shipment.GetType(), typeof(bool), rules);
            var result = lambda.Compile().DynamicInvoke(shipment);
            return (bool) result;
        }

        public static bool IsValidSyntax(string rules)
        {
            try
            {
                System.Linq.Dynamic.DynamicExpression.ParseLambda(typeof(Shipment), typeof(bool), rules);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}
