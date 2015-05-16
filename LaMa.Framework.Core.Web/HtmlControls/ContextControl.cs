using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaMa.Framework.Core.Web.HtmlControls
{
    /// <summary>
    /// Basic control that can retreive content from the server.
    /// Communication via AJAX
    /// </summary>
    public abstract class ContextControl
    {
        private readonly string _name;
        private readonly string _context;
        private readonly string _prefix;
        private readonly string _innerContext;
        
        public string Name
        {
            get { return _name; }
        }

        public string Context
        {
            get { return _context; }
        }

        protected string Prefix
        {
            get { return _prefix; }
        }

        public string InnerContext
        {
            get { return _innerContext; }
        }

        protected ContextControl(string name, string context) : this(name, context, string.Empty)
        {
            
        }
        protected ContextControl(string name,string context,string prefix)
        {
            _name = name;
            if (!context.EndsWith("Context"))
            {
                context += "Context";
            }
            _prefix = prefix;
            if (!string.IsNullOrEmpty(_prefix))
            {
                _prefix += "_";
            }
            _context =prefix+ context;
            _innerContext = prefix + "inner_" + context; 
        } 
    }
}