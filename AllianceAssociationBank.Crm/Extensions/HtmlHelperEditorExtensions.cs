using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AllianceAssociationBank.Crm.Extensions
{
    using Helper = HtmlExtensionsHelper;

    public static class HtmlHelperEditorExtensions
    {
        public static MvcHtmlString RoleBasedEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, 
                                                                       Expression<Func<TModel, TValue>> expression, 
                                                                       string cssClass)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.EditorFor(expression, additionalViewData: new
                {
                    htmlAttributes = Helper.CreateHtmlAttributes(cssClass)
                });
            }

            return html.EditorFor(expression, additionalViewData: new
            {
                htmlAttributes = Helper.CreateHtmlAttributes(cssClass, true)
            });
        }

        public static MvcHtmlString RoleBasedCheckBoxFor<TModel>(this HtmlHelper<TModel> html, 
                                                                 Expression<Func<TModel, bool>> expression)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.CheckBoxFor(expression);
            }

            return html.DisplayFor(expression);
        }

        public static MvcHtmlString RoleBasedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                            Expression<Func<TModel, TProperty>> expression, 
                                                                            int rows, 
                                                                            int columns, 
                                                                            string cssClass)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.TextAreaFor(expression,rows, columns, Helper.CreateHtmlAttributes(cssClass));
            }

            return html.TextAreaFor(expression, rows, columns, Helper.CreateHtmlAttributes(cssClass, true));
        }

        public static MvcHtmlString RoleBasedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                                Expression<Func<TModel, TProperty>> expression, 
                                                                                IEnumerable<SelectListItem> selectList, 
                                                                                string optionLabel, 
                                                                                string cssClass)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.DropDownListFor(expression, selectList, optionLabel, Helper.CreateHtmlAttributes(cssClass));
            }

            return html.DropDownListFor(expression, selectList, optionLabel, Helper.CreateHtmlAttributes(cssClass, true));
        }

        public static MvcHtmlString RoleBasedRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                               Expression<Func<TModel, TProperty>> expression, 
                                                                               object value, 
                                                                               string cssClass)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.RadioButtonFor(expression, value, Helper.CreateHtmlAttributes(cssClass));
            }

            return html.RadioButtonFor(expression, value, Helper.CreateHtmlAttributes(cssClass, true));
        }
    }
}