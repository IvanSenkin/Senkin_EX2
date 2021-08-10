using System;
using UnityEngine;
public class PlayerMove : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform cameraLook;
    [SerializeField] private Transform headLook;
    [SerializeField] private int _maxHP;
    [SerializeField] private float sensitivity;
    [SerializeField] private float sensitivityX;

    [SerializeField] private bool _isActive;

    [SerializeField] private Transform _lookObject;
    [SerializeField] private Transform _pointHandObject;
    [SerializeField] private float _valueWeight;

    private Animator _animator;
    public static Action<int> changeHP;
    private int _hp;
    private float mouseLookX;
    private float xRotation;
    private Vector3 dir;
    private float _speedFast;
    private int _blendAnimationHash = Animator.StringToHash("Blend");
 
    private void Awake()
    {
        _speedFast = 2 * _speed;
        _animator = GetComponent<Animator>();
        _hp = _maxHP;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        PlayerLook();
        KeyDown();
        HeadTrackingIsActive();

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
    }

    private void HeadTrackingIsActive()
    {
        _isActive = Vector3.Distance(transform.position, _lookObject.position) < 2;      
    }

    private void KeyDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetFloat(_blendAnimationHash, 1f);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            _animator.SetFloat(_blendAnimationHash, 2f);
            _speed = _speedFast;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Fire");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            //  Time.timeScale = 0;
            cameraLook.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.anyKey == false)
        {
            _animator.SetFloat(_blendAnimationHash, 0f);
            _speed = _speedFast / 2;
        }
    }

    private void PlayerLook()
    {             
            mouseLookX = Input.GetAxis("Mouse X");
        var mouseLookY = Input.GetAxis("Mouse Y") * sensitivityX * Time.deltaTime;
        transform.Rotate(0f, mouseLookX * sensitivityX * Time.deltaTime, 0f);

        xRotation -= mouseLookY;
        xRotation = Mathf.Clamp(xRotation, -30f, 10f);
        headLook.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        cameraLook.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {            
            var speed = dir * _speed * Time.fixedDeltaTime;
            transform.Translate(speed);
            dir = Vector3.zero;  
        }
    }
    public void TakeDamage(int damage)
    {
        changeHP?.Invoke(_hp);
        Debug.Log("Aaa");
        _hp -= damage;
        if (_hp <= 0)
        {
            _animator.SetTrigger("Death");
            Invoke("LoseCanvas", 3f);
        }
    }

    private void LoseCanvas()
    {
        CanvasController.Instance.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnAnimatorIK(int layerIndex)
    {      
            if (_isActive)
            {
                if (_lookObject != null)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_lookObject.position);
                }

                if (_pointHandObject != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _valueWeight);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _valueWeight);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointHandObject.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointHandObject.rotation);
                }
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetLookAtWeight(0);
            }
        
    }
}


