using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class MonitorFullScreen : Monitor
    {
        public override void Interact()
        {
            DesktopActivatedMode();
        }

        public override void DesktopActivatedMode()
        {
            _computerDesktopGO.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

        }

        public override void DesktopDeactivatedMode()
        {
            _computerDesktopGO.SetActive(false);
            _resumeGO.SetActive(false);
            _messageGO.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnCloseBtnClick()
        {
            DesktopDeactivatedMode();
        }
    }
}