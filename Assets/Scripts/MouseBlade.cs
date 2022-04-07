using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBlade : MonoBehaviour
{
    GameInput playerInput;
    public Camera camera;
    public Transform ball;
    bool isCutting;
    
    // Start is called before the first frame update
    private void Awake()
    {
        isCutting = false;
        //Cursor.lockState = CursorLockMode.Locked;
        playerInput = new GameInput();
        playerInput.Player.Enable();
        playerInput.Player.Slice.started += contex =>
        {
            isCutting = true;
        };
        playerInput.Player.Slice.canceled += contex =>
        {
            isCutting = false;
        };
    }

    void StartCutting()
    {
        Vector2 pos = playerInput.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mousePosition = new Vector3(pos.x, pos.y, 10f);
        mousePosition = camera.ScreenToWorldPoint(mousePosition);
       
       
        mousePosition.z = 0;
        ball.transform.position = mousePosition;
        Debug.Log(playerInput.Player.MousePosition.ReadValue<Vector2>());
        Debug.Log(mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerInput.Player.MousePosition.ReadValue<Vector2>());
        if (isCutting)
        {
            StartCutting();
        }
    }
}
