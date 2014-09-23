// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryStreamWriter.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Provides a stream writer that writes to a memory stream.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Provides a stream writer that writes to a memory stream.
    /// </summary>
    public class MemoryStreamWriter : StreamWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryStreamWriter" /> class using UTF8 encoding.
        /// </summary>
        public MemoryStreamWriter()
            : this(Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryStreamWriter"/> class with the specified encoding.
        /// </summary>
        /// <param name="encoding">
        /// The encoding.
        /// </param>
        public MemoryStreamWriter(Encoding encoding)
            : base(new MemoryStream(), encoding)
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the content of this stream.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this stream.
        /// </returns>
        public override string ToString()
        {
            this.Flush();
            var ms = (MemoryStream)this.BaseStream;
            ms.Position = 0;
            var r = new StreamReader(ms, this.Encoding);
            return r.ReadToEnd();
        }
    }
}