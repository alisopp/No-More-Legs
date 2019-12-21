using UnityEngine;

namespace Interfaces
{
    public interface IHookListener
    {
        void OnHookReachedPosition(Vector3 targetPosition);
        void OnFailedReachedPosition();

        Transform GetTransform();
    }
}