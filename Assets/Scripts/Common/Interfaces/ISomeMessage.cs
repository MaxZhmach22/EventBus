using System.Threading.Tasks;

namespace EventBus
{
    public interface ISomeMessage : IMessage
    {
        Task Print(string message);
    }
}