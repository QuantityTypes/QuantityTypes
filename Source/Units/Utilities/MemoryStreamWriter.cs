// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryStreamWriter.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Provides a stream writer that writes to a memory stream.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units
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