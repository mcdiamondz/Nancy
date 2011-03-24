﻿namespace Nancy.Testing
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public class BrowserContext : IBrowserContextValues
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserContext"/> class.
        /// </summary>
        public BrowserContext()
        {
            this.Values.Headers = new Dictionary<string, IEnumerable<string>>();
            this.Values.Protocol = "http";
        }

        /// <summary>
        /// Gets or sets the that should be sent with the HTTP request.
        /// </summary>
        /// <value>A <see cref="Stream"/> that contains the body that should be sent with the HTTP request.</value>
        Stream IBrowserContextValues.Body { get; set; }

        /// <summary>
        /// Gets or sets the protocol that should be sent with the HTTP request.
        /// </summary>
        /// <value>A <see cref="string"/> contains the the protocol that should be sent with the HTTP request..</value>
        string IBrowserContextValues.Protocol { get; set; }

        /// <summary>
        /// Gets or sets the headers that should be sent with the HTTP request.
        /// </summary>
        /// <value>An <see cref="IDictionary{TKey,TValue}"/> instance that contains the headers that should be sent with the HTTP request.</value>
        IDictionary<string, IEnumerable<string>> IBrowserContextValues.Headers { get; set; }

        /// <summary>
        /// Adds a body to the HTTP request.
        /// </summary>
        /// <param name="body">A <see cref="Stream"/> that should be used as the HTTP request body.</param>
        public void Body(Stream body)
        {
            this.Values.Body = body;
        }

        /// <summary>
        /// Adds a header to the HTTP request.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Header(string name, string value)
        {
            if (!this.Values.Headers.ContainsKey(name))
            {
                this.Values.Headers.Add(name, new List<string>());
            }

            var values = (List<string>)this.Values.Headers[name];
            values.Add(value);

            this.Values.Headers[name] = values;
        }

        /// <summary>
        /// Configures the request to be sent over HTTP.
        /// </summary>
        public void HttpRequest()
        {
            this.Values.Protocol = "http";
        }

        /// <summary>
        /// Configures the request to be sent over HTTPS.
        /// </summary>
        public void HttpsRequest()
        {
            this.Values.Protocol = "https";
        }

        private IBrowserContextValues Values
        {
            get { return this; }
        }


    }
}