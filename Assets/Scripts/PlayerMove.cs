using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform cameraLook;
    [SerializeField] private Transform headLook;
    [SerializeField] private int _maxHP;
    [SerializeField] private float sensitivity;
    [SerializeField] private float sensitivityX;
    [SerializeField] private Animator _animator;
    public static Action<int> changeHP;
    private int _hp;
    private float moeuseLookX;
    private float xRotation;
    private Vector3 dir;
    private float _speedFast;

    private void Start()
    {
  
    }
    private void Awake()
    {
        _speedFast = 2 * _speed;
        _animator = GetComponent<Animator>();
        _hp = _maxHP;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
       
    }
    private void Update()
    {
        PlayerLook();
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("FastRun", true);
            _speed = _speedFast;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {    
            _animator.SetTrigger("Fire");
            TakeDamage(10);   // атачим пока сами себя 
           // Fire();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
           // Time.timeScale = 0;
            cameraLook.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.anyKey == false)
        {
             _animator.SetBool("Run", false);
             _animator.SetBool("FastRun", false);
            _speed = _speedFast / 2 ;
        }
    }
    private void PlayerLook()
    {             
            moeuseLookX = Input.GetAxis("Mouse X");
        var moeuseLookY = Input.GetAxis("Mouse Y") * sensitivityX * Time.deltaTime;
        transform.Rotate(0f, moeuseLookX * sensitivityX * Time.deltaTime, 0f);

        xRotation -= moeuseLookY;
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
             
          else 
          {
           // _animator.SetBool("Run", false);
           // _animator.SetBool("FastRun", false);
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
        }
    }

}


