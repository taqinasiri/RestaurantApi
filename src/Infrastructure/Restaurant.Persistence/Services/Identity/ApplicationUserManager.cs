using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Persistence.Contexts;

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
    ApplicationDbContext context)
    : UserManager<User>(store,optionsAccessor,passwordHasher,userValidators,passwordValidators,keyNormalizer,errors,services,logger),
    IApplicationUserManager
{
    private readonly DbSet<User> _users = context.Set<User>();
    private readonly ApplicationDbContext _context = context;

    public async Task<User> FindByPhoneNumber(string phoneNumber)
        => await _users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

    public async Task UpdateSendCodeLastTime(User user,DateTime dateTime,bool isSave)
    {
        user.SendCodeLastTime = dateTime;
        if(isSave)
            await _context.SaveChangesAsync();
    }
}