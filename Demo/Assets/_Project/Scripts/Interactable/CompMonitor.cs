using UnityEngine;

// Монитор компьютера открывает канвас

namespace InteractionSystem
{
    public class CompMonitor : Interactable
    {
        [SerializeField] Computer _computer;
        public override void Interact()
        {
            _computer.OpenComputerDesktop();
        }
    }
}
