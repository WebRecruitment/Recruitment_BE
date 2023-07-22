using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.IGenericRepository;

namespace WebRecruitment.Infrastructure.GenericRepository
{
    // can perform basic operations on the database without having 
    // to re-implement each method for different types of objects.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Protected inherited  child (IGenericRepository)
        public readonly TuyendungContext _context;

        // Privated use DB in class 
        private readonly DbSet<T> _entitiySet;

        public GenericRepository(TuyendungContext context)
        {
            _context = context;
            _entitiySet=_context.Set<T>();
        }

        public void Add(T entity)
            => _context.Add(entity);


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _context.AddAsync(entity, cancellationToken);


        public void AddRange(IEnumerable<T> entities)
            => _context.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _context.AddRangeAsync(entities, cancellationToken);


        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);


        public IEnumerable<T> GetAll()
            => _entitiySet.AsEnumerable();


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitiySet.Where(expression).AsEnumerable();


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitiySet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);


        public void Remove(T entity)
            => _context.Remove(entity);


        public void RemoveRange(IEnumerable<T> entities)
            => _context.RemoveRange(entities);



        public async Task<Pagination<T>> ToPagination(int pageNumber = 1, int pageSize = 10)
        {
            var itemCount = await _entitiySet.CountAsync();
            var items = await _entitiySet
                                    .Skip(pageNumber * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<T>()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };

            return result;

        }

        public void Update(T entity)
            => _context.Update(entity);


        public void UpdateRange(IEnumerable<T> entities)
            => _context.UpdateRange(entities);
    }
}
