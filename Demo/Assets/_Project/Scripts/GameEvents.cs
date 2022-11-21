using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public event Action onHideInventoryRequested;
    public event Action onShowInventoryRequested;
    public event Action onHideAimRequested;
    public event Action onShowAimRequested;
    public event Action onFlashDriveUsed;
    public void HideInventoryRequested()
    {
        if (onHideInventoryRequested != null)
        {
            onHideInventoryRequested();
        }
    }
    public void ShowInventoryRequested()
    {
        if (onShowInventoryRequested != null)
        {
            onShowInventoryRequested();
        }
    }
    public void HideAimRequested()
    {
        if (onHideAimRequested != null)
        {
            onHideAimRequested();
        }
    }
    public void ShowAimRequested()
    {
        if (onShowAimRequested != null)
        {
            onShowAimRequested();
        }
    }
    public void FlashDriveUsed()
    {
        if (onFlashDriveUsed != null)
        {
            onFlashDriveUsed();
        }
    }
}
