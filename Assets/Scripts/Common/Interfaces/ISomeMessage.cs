using System.Threading.Tasks;

namespace EventBus.Common
{
    public interface ISomeMessage : IMessage
    {
        void Print(string message);
    }
}