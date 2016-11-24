using Smps.Core.BusinessObjects.Account;

namespace Smps.Core.Interfaces.Account.Repositories
{
    public interface IUserAccountRepository
    {
        UserProfile GetUserProfile(string userId);
        UserProfile ValidateUser(string userId, string password);
    }
}
