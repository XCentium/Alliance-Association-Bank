using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AllianceAssociationBank.Crm.Extensions
{
    using Helper = HtmlExtensionsHelper;

    /// <summary>
    /// HtmlHelper extensions for HTML input/editor elements.
    /// </summary>
    public static class HtmlHelperEditorExtensions
    {
        /// <summary>
        /// Returns an HTML input element based on the Linq expression and the role of the current logged in user.
        /// For users with read-only role HTML element will be in the disabled state.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="cssClass">A CSS class that should be used to style the element.</param>
        /// <returns>An HTML input element that is represented by the Linq expression.</returns>
        public static MvcHtmlString RoleBasedEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, 
                                                                       Expression<Func<TModel, TValue>> expression, 
                                                                       string cssClass)
        {
            bool addDisabledAttribute = true;

            if (html.IsUserInEditRole())
            {
                addDisabledAttribute = false;
            }

            return html.EditorFor(expression, additionalViewData: new
            {
                htmlAttributes = Helper.CreateHtmlAttributes(cssClass, addDisabledAttribute)
            });
        }

        /// <summary>
        /// Returns an HTML input element based on the Linq expression and the role of the current logged in user.
        /// Once a value been set only users with admin role can make changes, otherwise HTML element will be in the disabled/read-only state. 
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="cssClass">A CSS class that should be used to style the element.</param>
        /// <returns>An HTML input element that is represented by the Linq expression.</returns>
        public static MvcHtmlString AdminOnlyEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                       Expression<Func<TModel, TValue>> expression,
                                                                       string cssClass)
        {
            object htmlAttributes = null;

            if (html.IsUserInAdminRole())
            {
                htmlAttributes = Helper.CreateHtmlAttributes(cssClass);
            }
            else if (html.IsUserInEditRole())
            {
                if (IsModelValueNullOrEmpty(expression, html))
                {
                    htmlAttributes = Helper.CreateHtmlAttributes(cssClass);
                }
                else
                {
                    // if user with edit role and value is not null/empty then add read only css class
                    htmlAttributes = Helper.CreateHtmlAttributesForReadOnly(cssClass);
                }
            }
            else
            {
                // if user with read only role and value add disabled attribute
                htmlAttributes = Helper.CreateHtmlAttributes(cssClass, true);
            }

            return html.EditorFor(expression, additionalViewData: new { htmlAttributes });
        }

        /// <summary>
        /// Returns an HTML checkbox element based on the Linq expression and the role of the current logged in user.
        /// For users with read-only role HTML element will be in the display-only state.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <returns>An HTML checkbox element that is represented by the Linq expression.</returns>
        public static MvcHtmlString RoleBasedCheckBoxFor<TModel>(this HtmlHelper<TModel> html, 
                                                                 Expression<Func<TModel, bool>> expression)
        {
            if (html.IsUserInEditRole())
            {
                return html.CheckBoxFor(expression);
            }

            return html.DisplayFor(expression);
        }

        /// <summary>
        /// Returns an HTML textarea element based on the Linq expression and the role of the current logged in user.
        /// For users with read-only role HTML element will be in the disabled state.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="cssClass">A CSS class that should be used to style the element.</param>
        /// <returns>An HTML textarea element that is represented by the Linq expression.</returns>
        public static MvcHtmlString RoleBasedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                            Expression<Func<TModel, TProperty>> expression, 
                                                                            int rows, 
                                                                            int columns, 
                                                                            string cssClass)
        {
            bool addDisabledAttribute = true;

            if (html.IsUserInEditRole())
            {
                addDisabledAttribute = false;
            }

            return html.TextAreaFor(expression, rows, columns, Helper.CreateHtmlAttributes(cssClass, addDisabledAttribute));
        }

        /// <summary>
        /// Returns an HTML select element based on the Linq expression, list items, option label and the role of the current logged in user.
        /// For users with read-only role HTML element will be in the disabled state.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">A collection of SelectListItem objects that are used to populate the drop-down list.</param>
        /// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
        /// <param name="cssClass">A CSS class that should be used to style the element.</param>
        /// <returns>An HTML select element that is represented by the Linq expression.</returns>
        public static MvcHtmlString RoleBasedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                                Expression<Func<TModel, TProperty>> expression, 
                                                                                IEnumerable<SelectListItem> selectList, 
                                                                                string optionLabel, 
                                                                                string cssClass)
        {
            bool addDisabledAttribute = true;

            if (html.IsUserInEditRole())
            {
                addDisabledAttribute = false;
            }

            return html.DropDownListFor(expression, selectList, optionLabel, Helper.CreateHtmlAttributes(cssClass, addDisabledAttribute));
        }

        /// <summary>
        /// Returns an HTML radio button element based on the Linq expression and the role of the current logged in user.
        /// For users with read-only role HTML element will be in the disabled state.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="value">The value of the selected radio button.</param>
        /// <param name="cssClass">A CSS class that should be used to style the element.</param>
        /// <returns>An HTML radio button element that is represented by the Linq expression.</returns>
        public static MvcHtmlString RoleBasedRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                                                                               Expression<Func<TModel, TProperty>> expression, 
                                                                               object value, 
                                                                               string cssClass)
        {
            bool addDisabledAttribute = true;

            if (html.IsUserInEditRole())
            {
                addDisabledAttribute = false;
            }

            return html.RadioButtonFor(expression, value, Helper.CreateHtmlAttributes(cssClass, addDisabledAttribute));
        }

        /// <summary>
        /// Check if model property based on the Linq expression has value that been set.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The Linq expression that is supplied to the HTML helper.</param>
        /// <param name="html">The HTML helper object.</param>
        /// <returns>Return true if model value based on the expression is null or empty (string only).</returns>
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