using System;
using UnityEngine;

// Поворот игрока

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] float _turning_speed = 2f;

    Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //поворачиваемся мышью по оси Х, поворачивая трансформ игрока и передавая параметр для анимации

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X");

            transform.Rotate(mouseX * _turning_speed * Vector3.up, Space.World);
            _animator.SetFloat("TurningSpeed", Math.Abs(mouseX));
        }
    }
}
