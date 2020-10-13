﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ToPage.EF6
{
    /// <summary>
    /// Provides extension methods for <see cref="IOrderedQueryable{T}"/> objects relating to Entity Framework 6.
    /// </summary>
    public static class EF6QueryableExtensions
    {
        /// <summary>
        /// Creates a <see cref="Page{T}"/> from the query.
        /// </summary>
        /// <typeparam name="T">The query's item type.</typeparam>
        /// <param name="query">Query to build the page from.</param>
        /// <param name="pageNumber">The 1-based page number to get.</param>
        /// <param name="itemsPerPage">The number of items on the page.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="query"/> or  is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="pageNumber"/> or <paramref name="itemsPerPage"/> is less than 1.
        /// </exception>
        /// <returns>The specified page from the query.</returns>
        public static async Task<Page<T>> ToPageAsync<T>(this IOrderedQueryable<T> query,
            int pageNumber, int itemsPerPage)
            => await QueryableExtensions
                .ToPageAsync(query, pageNumber, itemsPerPage, async items => await items.ToListAsync());

        /// <summary>
        /// Creates a <see cref="PageWithCounts{T}"/> from the query.
        /// </summary>
        /// <typeparam name="T">The query's item type.</typeparam>
        /// <param name="query">Query to build the page from.</param>
        /// <param name="pageNumber">The 1-based page number to get.</param>
        /// <param name="itemsPerPage">The number of items on the page.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="query"/> or  is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="pageNumber"/> or <paramref name="itemsPerPage"/> is less than 1.
        /// </exception>
        /// <returns>The specified page from the query.</returns>
        public static async Task<PageWithCounts<T>> ToPageWithCountsAsync<T>(this IOrderedQueryable<T> query,
            int pageNumber, int itemsPerPage)
            => await QueryableExtensions
                .ToPageWithCountsAsync(query, pageNumber, itemsPerPage,
                    async items => await items.ToListAsync(),
                    async items => await items.CountAsync());
    }
}
