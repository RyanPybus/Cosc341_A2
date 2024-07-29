using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    public CSVWriter CSVWriter;
    public Master Master;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void onClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayhit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;

        Master.nextTarget(rayhit.collider.gameObject);
        CSVWriter.WriteCSV();
    }
}
