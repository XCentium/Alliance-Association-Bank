using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests
{
    public class AssertHelper
    {
        /// <summary>
        /// Helper test assert method to reduce code duplicaiton. This will check action result type,
        /// model type and view name.
        /// </summary>
        /// <typeparam name="TResult">Expected type for action result.</typeparam>
        /// <typeparam name="TModel">Expected type for model.</typeparam>
        /// <param name="result">Action result object.</param>
        /// <param name="viewName">Expected view name.</param>
        public static void AssertActionResult<TResult, TModel>(ActionResult result, string viewName)
        {
            AssertActionResult<TResult, TModel>(result, viewName, null);
        }

        /// <summary>
        /// Helper test assert method to reduce code duplicaiton. This will check action result type,
        /// model type, view name and model items count.
        /// </summary>
        /// <typeparam name="TResult">Expected type for action result.</typeparam>
        /// <typeparam name="TModel">Expected type for model.</typeparam>
        /// <param name="actionResult">Action result object.</param>
        /// <param name="viewName">Expected view name.</param>
        /// <param name="modelCount">Expected model items count.</param>
        public static void AssertActionResult<TResult, TModel>(ActionResult actionResult, string viewName, int? modelCount)
        {
            dynamic result = Assert.IsType<TResult>(actionResult);
            Assert.NotNull(result);

            dynamic model = Assert.IsType<TModel>(result.Model);
            Assert.NotNull(model);

            if (modelCount != null)
            {
                Assert.Equal(modelCount, model.Count);
            }

            Assert.Equal(viewName, result.ViewName);
        }
    }
}
