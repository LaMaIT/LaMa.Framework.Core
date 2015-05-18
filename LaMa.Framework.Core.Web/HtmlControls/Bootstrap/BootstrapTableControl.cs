using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using LaMa.Framework.Core.Web.Helpers;

namespace LaMa.Framework.Core.Web.HtmlControls.Bootstrap
{
    /// <summary>
    /// A simple one lined grid control. (standard bootstrap grid.)
    /// </summary>
    public class BootstrapTableControl:ContextControl
    {
        private readonly BootstrapTableControlSettings _settings;
        private readonly List<TableColumn> _tableColumns;
         
        public BootstrapTableControl(string name, string contextName) : this(name, contextName,new BootstrapTableControlSettings())
        {
        }
        public BootstrapTableControl(string name, string contextName, BootstrapTableControlSettings settings):base(name,contextName)
        {
            _tableColumns = new List<TableColumn>();
            _settings = settings;
        }
        public BootstrapTableControl AddColumn(string displayAndColumnName, bool isHidden = false)
        {
            AddColumn(displayAndColumnName, displayAndColumnName, isHidden);
            return this;
        }
        public BootstrapTableControl AddColumn<T, TProperty>(Expression<Func<T, TProperty>> displayAndColumnProperty, bool isHidden = false) where T : class
        {

            string propertyName = GetPropertyName(displayAndColumnProperty);
            AddColumn(propertyName, propertyName, isHidden);
            return this;
        }
        public BootstrapTableControl AddColumn<T, TProperty>(string displayName, Expression<Func<T, TProperty>> columnProperty, bool isHidden = false) where T : class
        {
            string propertyName = GetPropertyName(columnProperty);
            AddColumn(displayName, propertyName, isHidden);
            return this;
        }
        public BootstrapTableControl AddColumn(string displayName,string columnName,bool isHidden=false)
        {
            _tableColumns.Add(new TableColumn
                              {
                                  ColumnIndex = _tableColumns.Count,
                                  ColumnName = columnName,
                                  DisplayName = displayName,
                                  IsHidden = isHidden
                              });
            return this;
        } 
        private string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> columnProperty)
        {
            Type type = typeof(T);
            MemberExpression member = columnProperty.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException($"Expression '{columnProperty}' refers to a method, not a property.");

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"Expression '{columnProperty}' refers to a field, not a property.");

            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(
                    $"Expresion '{columnProperty}' refers to a property that is not from type {type}.");
            return propInfo.Name;
        }


        public MvcHtmlString Render(string routeUrl)
        {
            //todo find a way to not needing the render
            var tagBuilder = new TagBuilder("table");
            tagBuilder.Attributes.Add("id", this.Context);
            tagBuilder.Attributes.Add("name", this.Name);
            BuildTableCssClasses(tagBuilder);
            BuildTableHeader(tagBuilder);
            BuildTableBody(tagBuilder);

            var stringBuilder = new StringBuilder(tagBuilder.ToString());
            var javascriptBuilder = BuildJavascript(routeUrl);
            var renderedHtml = stringBuilder.Append(javascriptBuilder).ToString();
            return MvcHtmlString.Create(renderedHtml);
        }

        private JavascriptBuilder BuildJavascript(string routeUrl)
        {
            //Todo: change this to a sort of register js function.
            //brainstorm on it :-)
            var javascriptBuilder = new JavascriptBuilder();
            javascriptBuilder.Append("$(function() {")
                .Append("$.ajax({url:'")
                .Append(routeUrl).Append("'")
                .Append(",method:'GET',")
                .Append(" dataType:'JSON',")
                .AppendLine("error:  function (){alert('Something went wrong');},")
                .AppendLine("success:function(data){")
                .AppendLine("var length = data.length;var innerHtml = '';")
                .AppendLine("for (var i = 0; i < length; i++) {")
                .AppendLine("var rowIndexClass='row' +i;");

            javascriptBuilder.AppendLine("innerHtml += '<tr class=\"' + rowIndexClass +'\">';");
            foreach (TableColumn tableColumn in _tableColumns)
            {
                string extender = string.Empty;
                if (tableColumn.IsHidden)
                {
                    extender = " hidden";
                }
                string columnName = "col" + tableColumn.ColumnIndex + extender;
                javascriptBuilder.Append("innerHtml +='<td class=\"")
                    .Append(columnName)
                    .Append("\">'+ data[i].")
                    .Append(tableColumn.ColumnName)
                    .AppendLine("+ '</td>';");
            }
            javascriptBuilder.AppendLine("innerHtml += '</tr>';");

            javascriptBuilder.AppendLine("}")
                .Append("$('#inner_usersTblContext').html(innerHtml);}});});");
            return javascriptBuilder;
        }

        private void BuildTableBody(TagBuilder tagBuilder)
        {
            var tbodyBuilder = new TagBuilder("tbody");
            tbodyBuilder.Attributes.Add("id",this.InnerContext);
            tagBuilder.InnerHtml += tbodyBuilder.ToString(TagRenderMode.Normal);
        }

        private void BuildTableHeader(TagBuilder tagBuilder)
        {
            if (!_settings.DisplayHeader)
                return;
             
            var stringBuilder = new StringBuilder("<thead><tr>");
            
            foreach (var tableColumn in _tableColumns)
            {
                var thBuilder = new TagBuilder("th");
                if (tableColumn.IsHidden)
                {
                    thBuilder.AddCssClass("hidden");    
                }
                thBuilder.SetInnerText( tableColumn.DisplayName);
                stringBuilder.Append(thBuilder.ToString(TagRenderMode.Normal));
            }
            stringBuilder.Append("</tr></thead>");
            
            tagBuilder.InnerHtml = stringBuilder.ToString();
        }

        private void BuildTableCssClasses(TagBuilder tagBuilder)
        {
            tagBuilder.AddCssClass("table");
            tagBuilder.AddCssClass(_settings.CssClass);
            if (_settings.IsBordered)
                tagBuilder.AddCssClass("table-bordered");
            if (_settings.IsStriped)
                tagBuilder.AddCssClass("table-striped");
            if (_settings.IsHovered)
                tagBuilder.AddCssClass("table-hover");
            if (_settings.IsCondensed)
                tagBuilder.AddCssClass("table-condensed");
        }


        public class TableColumn
        {
            public int RowIndex { get; set; }
            public int ColumnIndex { get; set; }
            public string ColumnName { get; set; }
            public string DisplayName { get; set; }
            public bool IsHidden { get; set; }
        }
    }
}