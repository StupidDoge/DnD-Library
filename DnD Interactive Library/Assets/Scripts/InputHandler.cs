using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public float MouseX { get; set; }
    public float MouseY { get; set; }
    public bool LeftMouseButton { get; set; }
    public bool RightMouseButton { get; set; }
    public bool Use { get; set; }
    public bool Flashlight { get; set; }
    public bool Exit { get; set; }

    void Update()
    {
        LeftMouseButton = Input.GetMouseButtonDown(0);
        RightMouseButton = Input.GetMouseButtonDown(1);
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        Use = Input.GetButtonDown("Use");
        Flashlight = Input.GetButtonDown("Flashlight");
        Exit = Input.GetButtonDown("Exit");
    }
}
