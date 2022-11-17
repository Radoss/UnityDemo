using UnityEngine;
using Cinemachine;

namespace InteractionSystem
{
    public class MonitorInEnv : Monitor
    {
        [SerializeField] float zoomForCamera = 30;
        float _initCameraLensFOV;
        bool _isZoomedIn = false;
        CinemachineVirtualCamera _vCamera;

        private void Start()
        {
            GameEvents.instance.onFlashDriveUsed += OnFlashDriveUsed;
            _vCamera = Player.instance.vCameraGO.GetComponent<CinemachineVirtualCamera>();
            _initCameraLensFOV = _vCamera.m_Lens.FieldOfView;
        }

        public override void Interact()
        {
            _isZoomedIn = !_isZoomedIn;
            if (_isZoomedIn)
            {
                DesktopActivatedMode();
            }
            else
            {
                DesktopDeactivatedMode();
            }
        }

        public override void DesktopActivatedMode()
        {
            _vCamera.LookAt = transform;
            _vCamera.m_Lens.FieldOfView = zoomForCamera;
            Cursor.lockState = CursorLockMode.Confined;
            GameEvents.instance.HideInventoryRequested();

        }

        public override void DesktopDeactivatedMode()
        {
            _vCamera.LookAt = Player.instance.cameraTargetTF;
            _vCamera.m_Lens.FieldOfView = _initCameraLensFOV;
            Cursor.lockState = CursorLockMode.Locked;
            GameEvents.instance.ShowInventoryRequested();
            _resumeGO.SetActive(false);
            _messageGO.SetActive(false);
        }

    }
}