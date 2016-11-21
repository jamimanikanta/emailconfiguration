

namespace Smps.Core.Interfaces.Account
{
    using Smps.Core.BusinessObjects.Account;

    public interface IUserAccount
    {
        UserProfile GetUserProfile(string userId);
        bool IsValidUser(string userId, string password);
    }
}
