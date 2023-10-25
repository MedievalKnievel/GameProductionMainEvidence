using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpForce = 2.0f;
    public float gravity = -9.8f;
    public float distanceToGround = 0.4f;
    public Animator animator;
    public Transform ground;
    public LayerMask groundMask;
    public GameObject scenes;
    private float fallspeed = -2f;
    private bool grounded = true;
    private Vector3 velocity;
    private Vector2 move;
    private CharacterController controller;
    private PlayerControls controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Gravity();
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

    public void onAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            animator.SetBool("attacking", true);
            print("pretend some attack animation has played");
            
        }
    }

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
        if(col.gameObject.CompareTag("WIN"))
        {
            SceneManager.LoadScene(1);
        }
        if(col.gameObject.CompareTag("KILL"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
