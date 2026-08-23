AsNoTracking +
Projection +
Avoid N+1 +
Pagination +
Proper Indexes +
Efficient SQL +
Caching +
Batch/Set-based operations +
Monitoring & Execution Plans

var orders = await \_context.Orders
.AsNoTracking()
.OrderBy(x => x.Id)
.Skip((page - 1) \* pageSize)
.Take(pageSize)
.ToListAsync();
