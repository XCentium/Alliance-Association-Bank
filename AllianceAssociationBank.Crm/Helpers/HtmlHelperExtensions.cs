using AllianceAssociationBank.Crm.Constants;
using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AllianceAssociationBank.Crm.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RoleBasedEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            if (UserIsInRole(UserRoleName.ReadWriteUser))
            {
                return html.EditorFor(expression, additionalViewData);
            }

            return html.DisplayFor(expression);
        }

        public static MvcHtmlString RoleBasedCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            if (UserIsInRole(UserRoleName.ReadWriteUser))
            {
                return htmlHelper.CheckBoxFor(expression);
            }

            return htmlHelper.DisplayFor(expression);
        }

        public static MvcHtmlString RoleBasedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes)
        {
            if (UserIsInRole(UserRoleName.ReadWriteUser))
            {
                return htmlHelper.TextAreaFor(expression,rows, columns, htmlAttributes);
            }

            return htmlHelper.DisplayFor(expression);
        }

        // TODO: add extension for RadioButtonFor

        // TODO: add extension for DropDownListFor

        private static bool UserIsInRole(string role)
        {
            return HttpContext.Current?.User?.IsInRole(UserRoleName.ReadWriteUser) ?? false;
        }
    }
}