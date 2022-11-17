using UnityEngine;
using InventorySystem;

// Системный блок. Туда можно засунуть флешку.

namespace InteractionSystem
{
    public class CompUnit : MonoBehaviour, Iinteractable
    {
        //[SerializeField] Computer _computer;
        [SerializeField] private GameObject _flashDriveGO;
        [SerializeField] private float _radius = 5;
        [SerializeField] private string _expectedItemName = "FlashDrive";
        public float radius { get { return _radius; } }
        Item _selectedItem;

        public void Interact()
        {
            _selectedItem = Inventory.instance.selectedItem;
            if (_selectedItem && _selectedItem.name == _expectedItemName)
            {
                UseFlashDrive();
            }
        }

        private void UseFlashDrive()
        {
            Inventory.instance.Remove(Inventory.instance.selectedItem);
            _flashDriveGO.SetActive(true);
            GameEvents.instance.FlashDriveUsed();
        }

    }
}
