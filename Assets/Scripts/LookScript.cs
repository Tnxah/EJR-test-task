using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public float sensitivity = 10f;

    float mouseX, mouseY;
    float xRotation;
    Controller controls;

    Vector2 rotate;

    Transform PlayerBody;
    
    private void Awake()
    {
        controls = new Controller();

        controls.Movement.Rotate.performed += cts => rotate = cts.ReadValue<Vector2>();
        controls.Movement.Rotate.canceled += cts => rotate = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = rotate.x * sensitivity * Time.deltaTime;
        mouseY = rotate.y * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    #region ON_ENABLE/DISABLE
    private void OnEnable()
    {
        controls.Movement.Enable();
    }
    private void OnDisable()
    {
        controls.Movement.Disable();
    }
    #endregion
}
