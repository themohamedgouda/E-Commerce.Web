using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecedencesLayer
{
    static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery, ISpecification<TEntity,TKey> specification) where TEntity : BaseEntity<TKey>
        {
            var query = InputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            if (specification.IncludeExpression != null && specification.IncludeExpression.Count > 0)
            {
                //foreach (var includeExpression in specification.IncludeExpression)
                //{
                //    query = query.Include(includeExpression);
                //}
                // Using Aggregate to apply all includes
                query = specification.IncludeExpression.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specification.IsPaginated)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            return query;
        }
    }
}
