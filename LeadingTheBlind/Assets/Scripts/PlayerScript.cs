using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    public float speed = 16.0f;
    public float jumpForce = 2.0f;
    public float gravity = -9.8f;
    public float distanceToGround = 0.4f;
    public float sens = 100f;
    public Animator animator;
    public Transform ground;
    public Transform cameraObj;
    public LayerMask groundMask;
    public Transform player;
    public GameObject TimerObject, ManagerObject;
    private TimerScript timerScript;
    private CustomNetworkManager customNetworkManager;
    private Transform start;
    private float fallspeed = -2f;
    private float xRotation = 0f;
    private bool grounded = true;
    private Vector3 velocity;
    private Vector2 move;
    private Vector2 look;
    private CharacterController controller;
    private PlayerControls controls;
    // Start is called before the first frame update
    void Start()
    {
        ManagerObject = GameObject.FindWithTag("Manager");
        customNetworkManager = ManagerObject.GetComponent<CustomNetworkManager>();
        TimerObject = GameObject.FindWithTag("Timer");
        timerScript = TimerObject.GetComponent<TimerScript>();
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        start = new GameObject().transform;
        start.position = player.position;
        start.rotation = player.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        { return; }
        PlayerMovement();
        Gravity();
        
        if(timerScript.timeNo <= 0)
        {
            controller.enabled = false;
        }
        
    }

    public void onMove(InputAction.CallbackContext context)
    {
         move = context.ReadValue<Vector2>();
    }

    private void PlayerMovement()
    {
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * speed * Time.deltaTime);
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if(context.started && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * fallspeed * gravity);
        }
    }

    // public void Look()
    // {
    //     look.y = Input.GetAxis("Mouse Y");
    //     look.x = Input.GetAxis("Mouse X");

    //     xRotation -= look.y;
    //     xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //     cameraObj.localRotation = Quaternion.Euler(xRotation, 0, 0);
    //     player.Rotate(Vector3.up * look.x);

    // }

    private void Gravity()
    {
        grounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -6;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("KILL"))
        {
            print("touched the killbox");
            controller.enabled = false;
            player.position = start.position;
            player.rotation = start.rotation;
            controller.enabled = true;
        }
    }
}
