

namespace Smps.Core.Interfaces.Account
{
    using Smps.Core.BusinessObjects.Account;

    public interface IUserAccount
    {
        UserProfile GetUserProfile(string userId);
        UserProfile ValidateUser(string userId, string password);
    }
}
