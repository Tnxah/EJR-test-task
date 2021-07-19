using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInteraction : MonoBehaviour
{
    Mouse mouse;
    Controller controls;

    public float InteractionDistanse = 5f;

    private void Awake()
    {
        controls = new Controller();

        controls.Actions.Click.performed += cts => OnClick();

    }
    void Start()
    {
        mouse = Mouse.current;   
    }

    void OnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, InteractionDistanse))
        {
            Interactable obj = hit.collider.GetComponent<Interactable>();
            if (obj != null)
            {
                obj.Interaction();
            }
        }
    }

    #region ON_ENABLE/DISABLE
    private void OnEnable()
    {
        controls.Actions.Enable();
    }
    private void OnDisable()
    {
        controls.Actions.Disable();
    }

    #endregion
}
