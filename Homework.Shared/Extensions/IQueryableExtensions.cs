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
			IOrderedQueryable<T> ordered = sorted = SortBy<T>(source, sorts?.FirstOrDefault());

			// Skip the column header row.
			foreach (var sort in sorts?.Skip(1))
			{
				// Perform any ThenBy() sorts in the query.
				sorted = SortBy<T>(source, sort);
			}
			return sorted.ToList();
		}
		#endregion

		#region "Private methods"

		/// <summary
		/// Returns the expression needed as a parameter for the OrderBy() and ThenBy() methodss.
		/// <summary>
		private static Expression<Func<T, object>> BuildSortExpression<T>(string propertyName)
		{
			// Get the parameter expression.
			var paramExpression = Expression.Parameter(typeof(T));
			// Get the property expression.
			var propExpression = Expression.Property(paramExpression, propertyName);
			var lambdaExpression = Expression.Lambda(propExpression, paramExpression);

			// Use boxing to get a weakly-typed expression.
			Expression converted = Expression.Convert(lambdaExpression.Body, typeof(object));

			// Use Expression.Lambda to get a strongly-typed expression.
			return Expression.Lambda<Func<T, object>>(converted, lambdaExpression.Parameters);
		}

		/// <summary>
		/// Determines whether a queryable collection has already been ordered.
		/// <summary>
		private static bool IsOrdered<T>(this IQueryable<T> source)
		{
			return source.Expression.Type == typeof(IOrderedQueryable<T>);
		}

		/// <summary>
		/// Returns an ordered queryable collection for each directional sort.
		/// <summary>
		private static IOrderedQueryable<T> SortBy<T>(IQueryable<T> source, Sort sort)
		{
			var ordered = source as IOrderedQueryable<T>;

			return (source.IsOrdered())
			?
				// This is not the first sort.
				sort.SortDirection == ListSortDirection.Ascending
				? ordered.ThenBy(BuildSortExpression<T>(sort.PropertyName))
				: ordered.ThenByDescending(BuildSortExpression<T>(sort.PropertyName))
			:
				// This is the first sort.
				sort.SortDirection == ListSortDirection.Ascending
				? source.OrderBy(BuildSortExpression<T>(sort.PropertyName))
				: source.OrderByDescending(BuildSortExpression<T>(sort.PropertyName));
		}
		#endregion
	}
}