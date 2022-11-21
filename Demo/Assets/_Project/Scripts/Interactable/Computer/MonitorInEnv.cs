using UnityEngine;
using Cinemachine;

namespace InteractionSystem
{
    public class MonitorInEnv : Monitor
    {
        Animator _animator;

        private void Start()
        {
            GameEvents.instance.onFlashDriveUsed += OnFlashDriveUsed;
            _animator = Player.instance.GetComponent<Animator>();
        }

        public override void Interact()
        {
            DesktopActivatedMode();
        }

        public override void DesktopActivatedMode()
        {
            Cursor.lockState = CursorLockMode.Confined;
            GameEvents.instance.HideInventoryRequested();
            GameEvents.instance.HideAimRequested();
            _animator.SetBool("isLookingAtComputer", true);

        }

        public override void DesktopDeactivatedMode()
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameEvents.instance.ShowInventoryRequested();
            GameEvents.instance.ShowAimRequested();
            _resumeGO.SetActive(false);
            _messageGO.SetActive(false);
            _animator.SetBool("isLookingAtComputer", false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DesktopDeactivatedMode();
                return;
            }
        }
    }
}