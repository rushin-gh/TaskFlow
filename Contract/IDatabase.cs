using Model;

namespace Contract
{
    public interface IDatabase
    {
        int GetUserId(User user);

        void GetUserTasks(User user);
    }
}
