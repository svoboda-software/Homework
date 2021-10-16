using Homework.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Homework.Shared.Extensions
{
	public static class IQueryableExtensions
	{
		#region "Public methods"

		/// <summary>
		/// Returns a sorted list by handling the directional sorting of a queryable collection.
		/// <summary>
		public static List<T> SortBy<T>(this IQueryable<T> source, List<Sort> sorts)
		{
			IOrderedQueryable<T> sorted;
			// Perform the OrderBy() sort in the query.
			IOrderedQueryable<T> ordered = sorted = SortBy<T>(source);

			// Skip the column header row.
			foreach (var sort in sorts?.Skip(1))
			{
				// Perform any ThenBy() sorts in the query.
				sorted = SortBy<T>(source);
			}
			return sorted.ToList();
		}
		#endregion

		#region "Private methods"

		/// <summary>
		/// Returns an 'OrderBy' ordered collection for the first sort, then returns a 'ThenBy' ordered collection for all subsequent sorts.
		/// <summary>
		public static IOrderedQueryable<T> SortBy<T>(IQueryable<T> source)
		{
			// TODO: Return an ordered collection based on the sort.

			return source as IOrderedQueryable<T>;
		}
		#endregion
	}
}