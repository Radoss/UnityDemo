using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using InventorySystem;

namespace InteractionSystem
{
    public class CompInEnvironment : MonoBehaviour, Iinteractable
    {   
        [SerializeField] float zoomForCamera = 30;
        [SerializeField] GameObject _openResumeBtnGO; // кнопка для распечатывания резюме на рабочем столе (на мониторе)
        [SerializeField] GameObject _resumeGO; // само резюме(на мониторе)
        [SerializeField] GameObject _messageGO; // сообщение о том, что резюме напечатано (и попало в инвентарь)(на мониторе)
        [SerializeField] Item _resumeItem;
        [SerializeField] private float _radius = 5;
        public float radius { get { return _radius; } }
        float _initCameraLensFOV;
        bool _isZoomedIn = false;
        CinemachineVirtualCamera _vCamera;

        private void Awake()
        {
            _vCamera = Player.instance.vCameraGO.GetComponent<CinemachineVirtualCamera>();
            _initCameraLensFOV = _vCamera.m_Lens.FieldOfView;
        }

        private void Start()
        {
            GameEvents.instance.onFlashDriveUsed += onFlashDriveUsed;
        }

        public void Interact()
        {
            _isZoomedIn = !_isZoomedIn;
            if (_isZoomedIn)
            {
                EnterZoomedMode();
            }
            else
            {
                QuitZoomedMode();
            }
        }

        public void EnterZoomedMode()
        {
            _vCamera.LookAt = transform;
            _vCamera.m_Lens.FieldOfView = zoomForCamera;
            Cursor.lockState = CursorLockMode.Confined;
            GameEvents.instance.HideInventoryRequested();
        }

        public void QuitZoomedMode()
        {
            _vCamera.LookAt = Player.instance.cameraTargetTF;
            _vCamera.m_Lens.FieldOfView = _initCameraLensFOV;
            Cursor.lockState = CursorLockMode.Locked;
            GameEvents.instance.ShowInventoryRequested();
            _resumeGO.SetActive(false);
            _messageGO.SetActive(false);
        }

        private void onFlashDriveUsed()
        {
            _openResumeBtnGO.SetActive(true);
        }

        public void onOpenResumeBtnClick()
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
    }
}
