using System;
using System.Globalization;
using System.Web.Mvc;

namespace SamStock.Web._Util
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState { Value = valueResult };
            var incomingValue = valueResult.AttemptedValue.Replace('.', ','); // 1.50 => 1,50

            object actualValue = null;

            try
            {
                actualValue = (decimal)Convert.ToDouble(incomingValue, CultureInfo.CurrentCulture);
            }
            catch (FormatException ex)
            {
                modelState.Errors.Add(ex);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

            return actualValue;
        }
    }
}