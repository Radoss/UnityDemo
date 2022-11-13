using UnityEngine;

//движение игрока, основанное на компоненте Character Controller
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _runSpeed = 5f;
    [SerializeField] float _jumpSpeed = 0.3f; //насколько высоко прыгнет
    [SerializeField] float _gravity = 8f; //насколько быстро упадёт

    CharacterController _charController;
    Vector3 _moveDirection;
    Animator _animator;

    private void Awake()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // забираем значения с инпута
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // разбираемся с направлением, не учитывая прыжок (ось У)
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);
        
        //разбираемся, бежим мы или идём
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = _runSpeed;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            speed = _moveSpeed;
            _animator.SetBool("isRunning", false);
        }
        
        // в итоге получаем вектор движения, учитывая скорость и направление относительно Word Space
        Vector3 flatMovement = speed * Time.deltaTime * transformDirection;

        //разбираемся с прыжком
        _moveDirection = new Vector3(flatMovement.x, _moveDirection.y, flatMovement.z);

        if (isPlayerJumped)
        {
            _moveDirection.y = _jumpSpeed;
            _animator.SetTrigger("JumpTrigger");
        }
        else if (_charController.isGrounded)
        {
            _moveDirection.y = 0f;
        }
        else
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        _charController.Move(_moveDirection);

        /* animSpeed это скорость передвижение от 0 до 1.
         * но если мы двигаемся назад, мы хотим передать минусовую величину для аниматора. 
         * Поэтому делаем следующий трюк:
         */
        float animSpeed = (vertical > 0) ? inputDirection.magnitude : -inputDirection.magnitude;
        _animator.SetFloat("Speed", animSpeed);
    }

    private bool isPlayerJumped => _charController.isGrounded && Input.GetKey(KeyCode.Space);
    
}
