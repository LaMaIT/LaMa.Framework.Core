using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace LaMa.Framework.Core.Web.HtmlControls.Bootstrap
{
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
        public BootstrapTableControl AddColumn(string columnName,bool isHidden=false)
        {
            _tableColumns.Add(new TableColumn
                              {
                                  ColumnName = columnName,
                                  IsHidden = isHidden
                              });
            return this;
        }

        public MvcHtmlString Render(string routeUrl)
        {
            var tagBuilder = new TagBuilder("table");
            tagBuilder.Attributes.Add("id",this.Context);
            tagBuilder.Attributes.Add("name",this.Name);
            BuildTableCssClasses(tagBuilder);
            BuildTableHeader(tagBuilder);
            BuildTableBody(tagBuilder);
            var stringBuilder = new StringBuilder(tagBuilder.ToString());
    
            //TODO make some kind of registrator, to prevent the cluster of javascript tags everywhere on the page.
            //will probably add 1 more html tag like: Html.RenderScripts
            stringBuilder.Append(@" <script type='text/javascript'>
console.log('hello');
                                        $(function() {
                                            $.ajax({url:'")
                .Append(routeUrl)
                .Append("',method:'GET', dataType:'JSON',error:  function (){alert('Something went wrong'),")
                .Append("success:function(data){")
                .AppendLine("var length = data.length;var innerHtml = '';")
                .AppendLine(@"for (var i = 0; i < length; i++) {
                    innerHtml += '<tr>';
                    innerHtml += '<td>' + data[i].Id + '</td>';
                    innerHtml += '<td>' + data[i].Firstname + '</td>';
                    innerHtml += '<td>' + data[i].Lastname + '</td>';
                    innerHtml += '<td>' + data[i].DateOfBirth + '</td>';
                    innerHtml +='<td>' + data[i].IsPremium + '</td>';
                    innerHtml += '</tr>';
                } 
                $('#inner_usersTblContext').html(innerHtml);");
             
            return MvcHtmlString.Create(stringBuilder.ToString());
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
                thBuilder.SetInnerText( tableColumn.ColumnName);
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
            public string ColumnName { get; set; }
            public bool IsHidden { get; set; }
        }
    }
}