using App.BLL.Interfaces;
using App.DAL.Base;
namespace App.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IServices BuildServices(string conn)
        {
            return new Services(new UnitOfWork(conn))
                .BuildSetEmailServiceIdentity(new EmailServiceIdentity());
        }
    }
}
