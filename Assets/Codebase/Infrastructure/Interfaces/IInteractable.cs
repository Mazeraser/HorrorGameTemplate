using System;

namespace Infrastructure.Interfaces
{
    public interface IInteractable<T>
    {
        event Action<T> Interacted;
        T Interact();
    }
}