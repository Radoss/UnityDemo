using UnityEngine;

// Скрипт для компьютера, что на столе

public class Computer : MonoBehaviour
{
    [SerializeField] GameObject _computerDesktopGO; // рабочий стол компа на канвасе
    [SerializeField] GameObject _flashDriveGO; // флешка, воткнутая в комп (изначально деактивирована)
    [SerializeField] GameObject _openResumeBtnGO; // кнопка для распечатывания резюме на рабочем столе
    [SerializeField] GameObject _resumeGO; // само резюме
    [SerializeField] GameObject _messageGO; // сообщение о том, что резюме напечатано (и попало в инвентарь)

    public string expectedItemName;

    public void UseFlashDrive()
    {
        _flashDriveGO.SetActive(true);
        _openResumeBtnGO.SetActive(true);
    }

    public void OpenComputerDesktop()
    {
        _computerDesktopGO.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void CloseComputerDesktop()
    {
        _computerDesktopGO.SetActive(false) ;
        _resumeGO.SetActive(false);
        _messageGO.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnOpenResumeBtnClick()
    {
        _resumeGO.SetActive(true);
    }

}
