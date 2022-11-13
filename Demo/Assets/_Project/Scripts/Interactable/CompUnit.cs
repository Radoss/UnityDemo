using UnityEngine;
using InventorySystem;

// Системный блок. Туда можно засунуть флешку.

namespace InteractionSystem
{
    public class CompUnit : Interactable
    {
        [SerializeField] Computer _computer;
        Item _selectedItem;

        public override void Interact()
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
            _computer.UseFlashDrive();
        }

    }
}
