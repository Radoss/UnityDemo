using InventorySystem;

// Предмет, который можно забрать в инвентарь

namespace InteractionSystem
{
    public class ItemToPick : Interactable
    {
        public Item _item;
        public override void Interact()
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
