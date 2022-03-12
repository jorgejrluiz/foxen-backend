using Flunt.Notifications;

namespace TCC.Backend.Domain.Core.ValueObjects
{
    public abstract class ValueObject : Notifiable
    {
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
