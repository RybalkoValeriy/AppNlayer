namespace App.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IServices BuildServices(string conn);
    }
}
