﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Queries;

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
}