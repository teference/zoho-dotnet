using System.Linq;

namespace Teference.Zoho.Api
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using System.Text;

    #endregion

    public sealed class QueryStringBuilder
    {
        #region Variable declaration

        private readonly IDictionary<string, string> parameters = new Dictionary<string, string>();

        private readonly string baseUri;

        #endregion
        
        #region Constructor
        
        public QueryStringBuilder(string baseUri)
        {
            this.baseUri = baseUri;
        }

        #endregion

        #region Properties

        public string[] Keys
        {
            get { return this.parameters.Keys.ToArray(); }
        }

        public string this[string paramName]
        {
            get
            {
                return this.parameters.ContainsKey(paramName) 
                     ? this.parameters[paramName] 
                     : null;
            }

            set
            {
                this.parameters[paramName] = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.AppendTo(this.baseUri);
        }

        protected string AppendTo(string uri)
        {
            var query = this.parameters.Select(p => string.Format("{0}={1}", p.Key, Uri.EscapeDataString(p.Value)));
            return uri + "?" + string.Join("&", query);
        }

        public bool Contains(string paramName)
        {
            return this.parameters.ContainsKey(paramName);
        }

        public void Add(string paramName, string value)
        {
            this.parameters[paramName] = value;
        }

        public void Remove(string paramName)
        {
            this.parameters.Remove(paramName);
        }

        #endregion
    }
}