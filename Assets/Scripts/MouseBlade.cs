using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBlade : MonoBehaviour
{
    GameInput playerInput;
    public Camera camera;
    public Transform mouse;
    public Transform trailDefault;
    public Transform trailControl;
    bool isCutting;
    bool hasTrail;
    // Start is called before the first frame update
    private void Awake()
    {
        hasTrail = false;
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
            StopTrail();
            isCutting = false;
            
        };
    }
    void StopTrail()
    {
        trailControl.gameObject.SetActive(false);
        Destroy(trailControl.gameObject, 2f);
        hasTrail = false;
    }
    void StartCutting()
    {
        
       
        Vector2 pos = playerInput.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mousePosition = new Vector3(pos.x, pos.y, Mathf.Abs(camera.transform.position.z));
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

       
        mousePosition.z = 0;
        trailControl.transform.position = mousePosition;
        //mouse.transform.position = mousePosition;
        Debug.Log(playerInput.Player.MousePosition.ReadValue<Vector2>());
        Debug.Log(mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        if (isCutting)
        {
            if (hasTrail == false)
            {   
                trailControl = Instantiate(trailDefault);
                //trailControl.SetParent(mouse);
                trailControl.gameObject.SetActive(true);
                hasTrail = true;
            }
            StartCutting();
        }
        //Debug.Log(playerInput.Player.MousePosition.ReadValue<Vector2>());
        
    }
}
