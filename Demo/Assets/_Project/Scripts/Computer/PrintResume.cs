using UnityEngine;
using InventorySystem;

// скрипт для кнопки "распечатать резюме"

public class PrintResume : MonoBehaviour
{
    [SerializeField] Item _resumeItem;
    [SerializeField] GameObject _messagePanelGO;
    [SerializeField] GameObject _messagePanelGO2;

    public void OnPrintClick() //на большом канвасе
    {
        Inventory.instance.AddItem(_resumeItem);
        _messagePanelGO.SetActive(true);
        if (QuestManager.instance.goalReachedMap.ContainsKey("ResumeObtained"))
        {
            QuestManager.instance.goalReachedMap["ResumeObtained"] = true;
        }
    }

    public void OnPrintClick2() //на мониторе
    {
        Inventory.instance.AddItem(_resumeItem);
        _messagePanelGO2.SetActive(true);
        if (QuestManager.instance.goalReachedMap.ContainsKey("ResumeObtained"))
        {
            QuestManager.instance.goalReachedMap["ResumeObtained"] = true;
        }
    }


}
