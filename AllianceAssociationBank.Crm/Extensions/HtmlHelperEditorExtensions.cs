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
            if (html.IsUserInEditRole())
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

        public static MvcHtmlString AdminOnlyEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                       Expression<Func<TModel, TValue>> expression,
                                                                       string cssClass)
        {
            bool addDisabledAttribute = true;

            if (html.IsUserInAdminRole())
            {
                addDisabledAttribute = false;
            }
            else if (IsModelValueNullOrEmpty(expression, html))
            {
                addDisabledAttribute = false;
            }

            return html.EditorFor(expression, additionalViewData: new
            {
                htmlAttributes = Helper.CreateHtmlAttributes(cssClass, addDisabledAttribute)
            });
        }

        public static MvcHtmlString RoleBasedCheckBoxFor<TModel>(this HtmlHelper<TModel> html, 
                                                                 Expression<Func<TModel, bool>> expression)
        {
            if (html.IsUserInEditRole())
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
            if (html.IsUserInEditRole())
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
            if (html.IsUserInEditRole())
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
            if (html.IsUserInEditRole())
            {
                return html.RadioButtonFor(expression, value, Helper.CreateHtmlAttributes(cssClass));
            }

            return html.RadioButtonFor(expression, value, Helper.CreateHtmlAttributes(cssClass, true));
        }

        private static bool IsModelValueNullOrEmpty<TModel, TValue>(Expression<Func<TModel, TValue>> expression,
                                                                         HtmlHelper<TModel> html)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var type = metadata.ModelType;
            var value = metadata.Model;

            if (type == typeof(string))
            {
                return string.IsNullOrEmpty((string)value);
            }
            else
            {
                return value == null;
            }
        }
    }
}