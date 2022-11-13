using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Ячейка инвентаря

namespace InventorySystem
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] Image _iconIMG;
        [SerializeField] Image _backgroundIMG;
        [SerializeField] TextMeshProUGUI _keyNumberTMP;

        Color32 _defaultColor = new Color32();
        Color32 _activeColor = new Color32();
        Item _item;

        public void AddItem(Item newItem)
        {
            // в _iconIMG отображаем и активируем иконку предмета, который положими в инвентарь
            _item = newItem;
            _iconIMG.sprite = _item.icon;
            _iconIMG.gameObject.SetActive(true);
        }

        public void Clear()
        {
            // очищаем ячейку, прячем _iconIMG
            _item = null;
            _iconIMG.sprite = null;
            _iconIMG.gameObject.SetActive(false);
            SetActiveBackGround(false);
        }

        public void SetActiveBackGround(bool isActive)
        {
            _backgroundIMG.color = isActive ? _activeColor : _defaultColor;
        }

        public void SetColors(Color32 defaultColor, Color32 activeColor)
        {
            // устанавливаются цвета неактивной и активной ячейки. Должно выполнится один раз при старте.
            _defaultColor = defaultColor;
            _activeColor = activeColor;
        }

        public void SetKeyNumber(int number)
        {
            _keyNumberTMP.text = number.ToString();
        }
    }
}