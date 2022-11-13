using System.Collections.Generic;
using UnityEngine;

/* Здесь мы создаём столько ячеек в инвентаре, сколько установили в настройках "размер инвентаря" (между 1 и 9)
 * настроим цвет активных(где предмет взяли в руки) и неактивных ячеек,
 * а так же зададим делегат при изменении кол-ва предметов в инвентаре (для обновления UI)
 */
namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] Color32 _defaultSlotColor = new Color32(38, 38, 38, 55);
        [SerializeField] Color32 _activeSlotColor = new Color32(0, 90, 90, 130);
        [SerializeField] GameObject _inventorySlotPrefab;
        Inventory _inventory;
        List<InventorySlotUI> _inventorySlots;

        private void Start()
        {
            _inventory = Inventory.instance;
            _inventory.onItemsChangedCallback += UpdateUI;
            _inventorySlots = new List<InventorySlotUI>();
            CreateSlots();
        }

        private void CreateSlots()
        {
            for (int i = 0; i < _inventory.inventorySize; i++)
            {
                GameObject newSlotGO = Instantiate(_inventorySlotPrefab, transform);
                InventorySlotUI newSlot = newSlotGO.GetComponent<InventorySlotUI>();
                _inventorySlots.Add(newSlot);
                SetSlotColors(newSlot);
                newSlot.SetKeyNumber(i + 1);
            }
        }

        private void SetSlotColors(InventorySlotUI slot)
        {
            // устанавливаем цвета активных и неактивных ячеек (можно задать в инспекторе)
            slot.SetColors(_defaultSlotColor, _activeSlotColor);
            slot.SetActiveBackGround(false);
        }

        private void UpdateUI()
        {
            // Проходимся по нашим ячейкам и смотрим, не вышли ли за пределы счёта предметов в инвентаре. Если нет, добавляем в ячейку.
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                if (i < _inventory.items.Count)
                {
                    _inventorySlots[i].AddItem(_inventory.items[i]);
                    if (_inventory.selectedItem != null && _inventory.selectedItem == _inventory.items[i])
                    {
                        _inventorySlots[i].SetActiveBackGround(true);
                    }
                    else
                    {
                        _inventorySlots[i].SetActiveBackGround(false);
                    }
                }
                else
                {
                    _inventorySlots[i].Clear();
                }
            }
        }
    }
}