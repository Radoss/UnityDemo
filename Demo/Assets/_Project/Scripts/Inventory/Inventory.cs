using System.Collections.Generic;
using UnityEngine;

// Синглтон инвентаря

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            Destroy(gameObject);
        }

        #endregion

        // будем делегировать коллбэк
        public delegate void OnItemNumberChanged();
        public OnItemNumberChanged onItemsChangedCallback;

        private int _clampedInventorySize; // приведенное к промежутку между 1 и 9 значение, введённое в инспекторе (9 - максимальный размер инвентаря, 1 - минимальный)
        [HideInInspector]
        public int inventorySize
        {
            get
            {
                return _clampedInventorySize;
            }
            private set
            {
                _clampedInventorySize = Mathf.Clamp(value, 1, 9);
            }
        }

        public Item selectedItem { get; private set; } // что мы "держим в руках" и, в теории, готовы применить
        public List<Item> items { get; private set; }

        [SerializeField] int _inventorySize = 5; // значение, введённое в инспекторе

        private void Start()
        {
            items = new List<Item>();

            inventorySize = _inventorySize;
        }

        public bool AddItem(Item newItem)
        {
            if (items.Count < inventorySize && !items.Contains(newItem))
            {
                items.Add(newItem);
                if (onItemsChangedCallback != null)
                {
                    onItemsChangedCallback.Invoke();
                }
                return true;
            }
            return false;
        }

        public void Remove(Item item)
        {
            if (items.Contains(item))
            {
                if (selectedItem == item)
                {
                    selectedItem = null;
                }
                items.Remove(item);
                if (onItemsChangedCallback != null)
                {
                    onItemsChangedCallback.Invoke();
                }
            }
        }

        private void SelectItem(int i) // "берём в руки" предмет из инвентаря
        {
            if (i < items.Count)
            {
                selectedItem = selectedItem != items[i] ? items[i] : null;
                onItemsChangedCallback.Invoke();
            }
        }

        private void Update()
        {
            /* Принажатии кнопок от 1 до 5ти мы выбираем, 
             * из какой ячейки инвентаря взять предмет
             */
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectItem(0);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectItem(1);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectItem(2);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectItem(3);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectItem(4);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectItem(5);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectItem(6);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SelectItem(7);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                SelectItem(8);
                return;
            }
        }
    }
}
