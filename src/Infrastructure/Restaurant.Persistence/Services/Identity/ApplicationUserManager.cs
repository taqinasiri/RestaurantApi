using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Queries;
using Restaurant.Application.Models;

namespace Restaurant.Persistence.Services.Identity;

public class ApplicationUserManager(
    IUserStore<User> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<User> passwordHasher,
    IEnumerable<IUserValidator<User>> userValidators,
    IEnumerable<IPasswordValidator<User>> passwordValidators,
    ILookupNormalizer keyNormalizer,IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<User>> logger,
    ApplicationDbContext context,
    IMapper mapper)
    : UserManager<User>(store,optionsAccessor,passwordHasher,userValidators,passwordValidators,keyNormalizer,errors,services,logger),
    IApplicationUserManager
{
    private readonly DbSet<User> _users = context.Set<User>();
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<User> FindByPhoneNumber(string phoneNumber)
        => await _users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

    public async Task UpdateSendCodeLastTime(User user,DateTime dateTime,bool isSave)
    {
        user.SendCodeLastTime = dateTime;
        if(isSave)
            await _context.SaveChangesAsync();
    }

    public async ValueTask<bool> IsExists(long id)
        => await _users.AnyAsync(u => u.Id == id);

    public async ValueTask<GetUserDetailsResponse> GetDetailsById(long id)
        => (await _mapper.ProjectTo<GetUserDetailsResponse>(_users.Where(u => u.Id == id)).FirstOrDefaultAsync())!;

    public async ValueTask<int> GetEntitiesCountAsync() => await _users.CountAsync();

    public async ValueTask<GetByFilterResult<UserForFilterList>> GetByFilterAsync(UserFilters filter,PagingQuery paging,OrderingModel<UserOrdering> ordering)
    {
        var query = _users.AsQueryable();
        if(filter.UserName!.IsNotNull())
            query = query.Where(u => u.UserName!.Contains(filter.UserName!));
        if(filter.Email!.IsNotNull())
            query = query.Where(u => u.Email.Contains(filter.Email!));
        if(filter.PhoneNumber is not null)
            query = query.Where(u => u.PhoneNumber.Contains(filter.PhoneNumber));
        if(filter.IsActive is not null)
            query = query.Where(u => u.IsActive == filter.IsActive);

        if(filter.Role!.IsNotNull())
            query = query.Where(u => u.UserRoles.Any(r => r.Role.Name == filter.Role));

        switch(ordering.OrderBy)
        {
            case UserOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(c => c.Id);
                break;

            case UserOrdering.UserName:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.UserName) : query.OrderBy(c => c.UserName);
                break;

            case UserOrdering.Email:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email);
                break;

            case UserOrdering.PhoneNumber:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.PhoneNumber) : query.OrderBy(c => c.PhoneNumber);
                break;
        }

        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<UserForFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }
}