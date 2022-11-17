using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace InteractionSystem
{
    public abstract class Monitor : MonoBehaviour, Iinteractable
    {
        [SerializeField] protected float _radius = 5;
        [SerializeField] protected GameObject _computerDesktopGO; // рабочий стол компа на канвасе
        [SerializeField] protected GameObject _openResumeBtnGO; // кнопка для распечатывания резюме на рабочем столе (на мониторе)
        [SerializeField] protected GameObject _resumeGO; // само резюме(на мониторе)
        [SerializeField] protected GameObject _messageGO; // сообщение о том, что резюме напечатано (и попало в инвентарь)(на мониторе)
        [SerializeField] protected Item _resumeItem;
        public float radius { get { return _radius; } }

        public virtual void Interact()
        {
            //для переопределения
        }

        public virtual void DesktopActivatedMode()
        {
            //для переопределения
        }

        public virtual void DesktopDeactivatedMode()
        {
            //для переопределения
        }

        private void Start()
        {
            GameEvents.instance.onFlashDriveUsed += OnFlashDriveUsed;
        }

        protected void OnFlashDriveUsed()
        {
            _openResumeBtnGO.SetActive(true);
        }

        public void OnOpenResumeBtnClick()
        {
            _resumeGO.SetActive(true);
        }

        public void OnPrintClick()
        {
            Inventory.instance.AddItem(_resumeItem);
            _messageGO.SetActive(true);
            if (QuestManager.instance.goalReachedMap.ContainsKey("ResumeObtained"))
            {
                QuestManager.instance.goalReachedMap["ResumeObtained"] = true;
            }
        }

        public void OnOkBtnClick()
        {
            Cursor.lockState = CursorLockMode.Locked;
            DesktopDeactivatedMode();
        }
    }
}
