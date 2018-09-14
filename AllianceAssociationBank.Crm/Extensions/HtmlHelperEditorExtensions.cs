using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using AuthHandler = AllianceAssociationBank.Crm.Identity.HtmlControlAuthorizationHandler;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlHelperEditorExtensions
    {
        public static MvcHtmlString RoleBasedEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, 
                                                                       Expression<Func<TModel, TValue>> expression, 
                                                                       UserRoleEnum currentUserRole, 
                                                                       string cssClass)
        {
            if (AuthHandler.IsAuthorizedToEdit(currentUserRole))
            {
                return html.EditorFor(expression, additionalViewData: new { htmlAttributes = CreateHtmlAttributes(cssClass) });
            }
            //html.ViewContext.HttpContext.User;

            return html.EditorFor(expression, additionalViewData: new { htmlAttributes = CreateHtmlAttributes(cssClass, true) });
        }

        public static MvcHtmlString RoleBasedCheckBoxFor<TModel>(this HtmlHelper<TModel> html, 
                                                                 Expression<Func<TModel, bool>> expression, 
                                                                 UserRoleEnum currentUserRole)
        {
            if (AuthHandler.IsAuthorizedToEdit(currentUserRole))
            {
                return html.CheckBoxFor(expression);
            }

            return html.DisplayFor(expression);
        }

        public static MvcHtmlString RoleBasedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                            Expression<Func<TModel, TProperty>> expression, 
                                                                            UserRoleEnum currentUserRole, 
                                                                            int rows, 
                                                                            int columns, 
                                                                            string cssClass)
        {
            if (AuthHandler.IsAuthorizedToEdit(currentUserRole))
            {
                return html.TextAreaFor(expression,rows, columns, CreateHtmlAttributes(cssClass));
            }

            return html.TextAreaFor(expression, rows, columns, CreateHtmlAttributes(cssClass, true));
        }

        public static MvcHtmlString RoleBasedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                                Expression<Func<TModel, TProperty>> expression, 
                                                                                UserRoleEnum currentUserRole, 
                                                                                IEnumerable<SelectListItem> selectList, 
                                                                                string optionLabel, 
                                                                                string cssClass)
        {
            if (AuthHandler.IsAuthorizedToEdit(currentUserRole))
            {
                return html.DropDownListFor(expression, selectList, optionLabel, CreateHtmlAttributes(cssClass));
            }
            return html.DropDownListFor(expression, selectList, optionLabel, CreateHtmlAttributes(cssClass, true));
        }

        public static MvcHtmlString RoleBasedRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                               Expression<Func<TModel, TProperty>> expression, 
                                                                               UserRoleEnum currentUserRole, 
                                                                               object value, 
                                                                               string cssClass)
        {
            if (AuthHandler.IsAuthorizedToEdit(currentUserRole))
            {
                return html.RadioButtonFor(expression, value, CreateHtmlAttributes(cssClass));
            }

            return html.RadioButtonFor(expression, value, CreateHtmlAttributes(cssClass, true));
        }

        private static object CreateHtmlAttributes(string cssClass, bool disabled = false)
        {
            if (disabled)
            { 
                return new { @class = cssClass, disabled = "disabled" };
            }

            return new { @class = cssClass };
        }
    }
}