using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
   private PlayerControls controls;
   public float sens = 100f;
   private Vector2 look;
   private float xRotation = 0f;
   public Transform playerBody;

    void Awake()
    {
        controls = new PlayerControls();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
    }

    public void onLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void Look()
    {
        float lookX = look.x * sens * Time.deltaTime;
        float lookY = look.y * sens * Time.deltaTime;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * lookX);
    }

    private void OnEnable()
   {
        controls.Enable();
   }

   private void onDisable()
   {
        controls.Disable();
   }
}
