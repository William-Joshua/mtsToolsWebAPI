using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Common
{
    /// <summary>
    /// 动态表达式帮助类
    /// </summary>
    public class EFExpressionHelper
    {
        public static Expression<Func<T, bool>> GenerateQueryExpression<T>(T queryCondition) where T : class, new()
        {
            List<MethodCallExpression>methodCallExpressions = new List<MethodCallExpression>();
            Type type = queryCondition.GetType();
            ParameterExpression parameterExpression = Expression.Parameter(type, "x");
            var properties = type.GetProperties();
            foreach (var propertie in properties)
            {
                var queryConditionValue = propertie.GetValue(queryCondition, null);
                if (queryConditionValue != null )
                {
                    Expression proerty = Expression.Property(parameterExpression, propertie);
                    ConstantExpression constantExpression = Expression.Constant(queryConditionValue, propertie.PropertyType);
                    if (propertie.PropertyType.Name != "Int32")
                        methodCallExpressions.Add(Expression.Call(proerty, typeof(string).GetMethod("Contains"), new Expression[] { constantExpression }));
                }
            }

            if (methodCallExpressions.Count == 0)
                return Expression.Lambda<Func<T, bool>>(Expression.Constant(true, typeof(bool)), new ParameterExpression[] { parameterExpression });
            else
                return Expression.Lambda<Func<T, bool>>(MethodCall(methodCallExpressions), new ParameterExpression[] { parameterExpression });
        }

        public static Expression MethodCall<T>(List<T> methodCallExpressions) where T : MethodCallExpression
        {
            if (methodCallExpressions.Count == 1) return methodCallExpressions[0];
            BinaryExpression binaryExpression = null;
            for (int icount = 0; icount < methodCallExpressions.Count; icount += 2)
            {
                if (icount < methodCallExpressions.Count - 1)
                {
                    BinaryExpression binary = Expression.OrElse(methodCallExpressions[icount], methodCallExpressions[icount + 1]);
                    if (binaryExpression != null)
                        binaryExpression = Expression.OrElse(binaryExpression, binary);
                    else
                        binaryExpression = binary;
                }
            }
            if (methodCallExpressions.Count % 2 != 0)
                return Expression.OrElse(binaryExpression, methodCallExpressions[methodCallExpressions.Count - 1]);
            else
                return binaryExpression;
        }
    }
}
