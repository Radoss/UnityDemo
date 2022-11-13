using UnityEngine;
using InventorySystem;

// скрипт для кнопки "распечатать резюме"

public class PrintResume : MonoBehaviour
{
    [SerializeField] Item _resumeItem;
    [SerializeField] GameObject _messagePanelGO;

    public void OnPrintClick()
    {
        Inventory.instance.AddItem(_resumeItem);
        _messagePanelGO.SetActive(true);
        if (QuestManager.instance.goalReachedMap.ContainsKey("ResumeObtained"))
        {
            QuestManager.instance.goalReachedMap["ResumeObtained"] = true;
        }
    }


}
