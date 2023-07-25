using System.Collections.Generic;
using Upkeep.Models;

namespace Upkeep.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetById(int id);
        void Update(UserProfile userProfile);
    }
}
