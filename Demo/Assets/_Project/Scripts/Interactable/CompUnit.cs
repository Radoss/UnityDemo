using UnityEngine;
using InventorySystem;

// Системный блок. Туда можно засунуть флешку.

namespace InteractionSystem
{
    public class CompUnit : MonoBehaviour, Iinteractable
    {
        [SerializeField] Computer _computer;
        [SerializeField] private float _radius = 5;
        public float radius { get { return _radius; } }
        Item _selectedItem;

        public void Interact()
        {
            _selectedItem = Inventory.instance.selectedItem;
            if (_selectedItem && _selectedItem.name == _computer.expectedItemName)
            {
                UseFlashDrive();
            }
            else
            {
                _computer.OpenComputerDesktop();
            }
        }

        private void UseFlashDrive()
        {
            Inventory.instance.Remove(Inventory.instance.selectedItem);
            //_computer.UseFlashDrive();
            GameEvents.instance.FlashDriveUsed();
        }

    }
}
