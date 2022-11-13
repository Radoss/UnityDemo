using UnityEngine;

namespace InteractionSystem
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 5f;

        public virtual void Interact()
        {
            //для переопределения
        }

    }
}
