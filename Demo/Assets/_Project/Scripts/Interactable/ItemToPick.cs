using InventorySystem;
using UnityEngine;

// Предмет, который можно забрать в инвентарь

namespace InteractionSystem
{
    public class ItemToPick : MonoBehaviour, Iinteractable
    {
        public Item _item;
        [SerializeField] private float _radius = 5;
        public float radius { get { return _radius; } }
        public void Interact()
        {
            PickUp();
        }

        private void PickUp()
        {
            bool isPickedUp = Inventory.instance.AddItem(_item); //вернёт false, в случае если невозможно добавить в инвентарь.
            if (isPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
