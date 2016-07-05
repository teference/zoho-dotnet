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

        private readonly IDictionary<string, string> paramValueCollection = new Dictionary<string, string>();

        #endregion

        #region Constructor

        public QueryStringBuilder()
        {
            this.StartsWith = '?';
            this.SeperatesWith = '&';
            this.ParamValueJoinsWith = '=';
        }

        public QueryStringBuilder(string param, string value) : this()
        {
            this[param] = value;
        }

        #endregion

        #region Properties

        public char? StartsWith { get; set; }

        public char SeperatesWith { get; set; }

        public char ParamValueJoinsWith { get; set; }

        public string[] Keys
        {
            get
            {
                var keyArray = new string[this.paramValueCollection.Keys.Count];
                this.paramValueCollection.Keys.CopyTo(keyArray, 0);
                return keyArray;
            }
        }

        public string this[string param]
        {
            get
            {
                return this.paramValueCollection.ContainsKey(param) ? this.paramValueCollection[param] : null;
            }

            set
            {
                this.paramValueCollection[param] = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            var tempQueryStringBuilder = new StringBuilder();
            foreach (var paramValueItem in this.paramValueCollection)
            {
                //// Add start with character.
                if ((tempQueryStringBuilder.Length == 0) && (null != this.StartsWith))
                {
                    tempQueryStringBuilder.Append(this.StartsWith);
                }

                //// Add query string parameter / value seperator.
                if ((tempQueryStringBuilder.Length > 0) && (tempQueryStringBuilder[tempQueryStringBuilder.Length - 1] != this.StartsWith))
                {
                    tempQueryStringBuilder.Append(this.SeperatesWith);
                }

                //// Normal drill.
                tempQueryStringBuilder.Append(paramValueItem.Key);
                tempQueryStringBuilder.Append(this.ParamValueJoinsWith);
                tempQueryStringBuilder.Append(Uri.EscapeDataString(paramValueItem.Value));
            }

            return tempQueryStringBuilder.ToString();
        }

        public bool ContainsParam(string paramName)
        {
            return this.paramValueCollection.ContainsKey(paramName);
        }

        public void Add(string param, string value)
        {
            this.paramValueCollection[param] = value;
        }

        public void Remove(string paramName)
        {
            this.paramValueCollection.Remove(paramName);
        }

        #endregion
    }
}