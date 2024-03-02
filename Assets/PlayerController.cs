using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public int id;
    public float moveSpeed;
    public CharacterController characterController;
    public Player photonPlayer;
    public Transform camTransform;
    public bool isRunning = false;
    public Animator animatorController;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Move();
    }
    void Look()
    {
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        float newRotationX = camTransform.localEulerAngles.x - mouseInputY;

        if (newRotationX > 180f)
        {
            newRotationX -= 360f;
        }
        newRotationX = Mathf.Clamp(newRotationX, -80f, 80f);

        transform.eulerAngles += Vector3.up * mouseInputX;
        camTransform.localEulerAngles = new Vector3(newRotationX, 0f, 0f);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animatorController.SetBool("isWalking", false);
            animatorController.SetBool("isIdle", false);
            animatorController.SetBool("isLeftStrafeWalking", true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            animatorController.SetBool("isWalking", false);
            animatorController.SetBool("isIdle", false);
            animatorController.SetBool("isRightStrafeWalking", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animatorController.SetBool("isWalking", true);
            animatorController.SetBool("isIdle", false);
            animatorController.SetBool("isLeftStrafeWalking", false);
            animatorController.SetBool("isRightStrafeWalking", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animatorController.SetBool("isWalkingBackwards", true);
            animatorController.SetBool("isIdle", false);
        }
        else
        {
            animatorController.SetBool("isWalking", false);
            animatorController.SetBool("isIdle", true);
            animatorController.SetBool("isLeftStrafeWalking", false);
            animatorController.SetBool("isRightStrafeWalking", false);
            animatorController.SetBool("isWalkingBackwards", false);
            animatorController.SetBool("isRunning", false);

        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            moveSpeed = 3f;
        }
        else
        {
            isRunning = false;
            moveSpeed = 2f;
        }
        dir *= moveSpeed * Time.deltaTime;

        characterController.Move(dir);
    }
}
