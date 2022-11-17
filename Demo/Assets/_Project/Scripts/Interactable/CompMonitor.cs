using UnityEngine;

// Монитор компьютера открывает канвас

namespace InteractionSystem
{
    public class CompMonitor : MonoBehaviour, Iinteractable
    {
        [SerializeField] Computer _computer;
        [SerializeField] private float _radius = 5;
        public float radius { get { return _radius; } }
        public void Interact()
        {
            _computer.OpenComputerDesktop();
        }
    }
}
