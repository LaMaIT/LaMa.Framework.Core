using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LaMa.Framework.Core.Web.Assets
{
    public static class ClientFileResources
    {
        private const string ASSETS_NAMESPACE = "LaMa.Framework.Core.Web.Assets";
        private static readonly ReadOnlyDictionary<string, string> _resourceDictionary;
        private static readonly string[] _defaultScriptNames;
        private static readonly string[] _defaultStyleSheetNames;

        static  ClientFileResources()
        {
            const string scriptsNamespace = ASSETS_NAMESPACE + ".Scripts.";
            const string stylesNamespace = ASSETS_NAMESPACE + ".Styles.";

           var resourceDictionary = new Dictionary<string, string>
                                    {
                                        {"jquery.js",scriptsNamespace + "jquery-2.0.3.min.js"},
                                        {"modernizr.js",scriptsNamespace + "modernizr-2.6.2.min.js"},
                                        {"bootstrap.js",scriptsNamespace + "bootstrap.min.js"},
                                        {"bootstrap.css",stylesNamespace + "bootstrap.min.css"},
                                    };
           _resourceDictionary = new ReadOnlyDictionary<string, string>(resourceDictionary);
           _defaultScriptNames = resourceDictionary.Keys.Where(x => x.EndsWith(".js")).ToArray();
           _defaultStyleSheetNames = resourceDictionary.Keys.Where(x => x.EndsWith(".css")).ToArray();
        }
      
        public static string GetResource(string name)
        {
            if (_resourceDictionary.ContainsKey(name))
            {
                return _resourceDictionary[name];
            }
            return string.Empty;
        }

        public static string[] GetDefaultScriptNames()
        {
            return _defaultScriptNames;
        }

        public static string[] GetDefaultStyleSheetNames()
        {
            return _defaultStyleSheetNames;
        }
    }
}