﻿using System.Collections.Generic;

namespace ToPage
{
    /// <summary>
    /// A page with generic page items.
    /// </summary>
    /// <typeparam name="T">Type of the items on the page.</typeparam>
    public class Page<T> : IPage<T>
    {
        /// <inheritdoc/>
        public IEnumerable<T> Items { get; }

        /// <inheritdoc/>
        public int PageNumber { get; }

        /// <summary>
        /// Initializes a <see cref="Page{T}"/> with items and a page number.
        /// </summary>
        /// <param name="items">The items on the page.</param>
        /// <param name="pageNumber">The 1-based page number.</param>
        public Page(IEnumerable<T> items, int pageNumber)
        {
            Items = items;
            PageNumber = pageNumber;
        }
    }
}
