using UnityEngine;
using System;

// Поворот камеры

public class CameraTurn : MonoBehaviour
{
    [SerializeField] float _cameraSensitivity = 2f;
    [SerializeField] Transform _cameraTargetTF;

    float _rotationY = 0;

    void Update()
    {
        /*
         * чтобы крутить камерой вверх и вних, 
         * поворачиваем цель камеры при движении мыши по оси Y
         */

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float _mouseY = Input.GetAxis("Mouse Y");
            _rotationY += _mouseY * -1 * _cameraSensitivity;

            Vector3 oldAngles = _cameraTargetTF.localEulerAngles;
            _rotationY = Math.Clamp(_rotationY, -70, 70);
            _cameraTargetTF.localEulerAngles = new Vector3(_rotationY, oldAngles.y, oldAngles.z);
        }
    }
}
