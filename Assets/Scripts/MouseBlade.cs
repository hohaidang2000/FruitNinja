using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class MouseBlade : MonoBehaviour
{
    GameInput playerInput;
    public Camera camera;
    public Rigidbody2D mouse;
    public Transform trailDefault;
    public Transform trailControl;
    public Transform cutPlane;
    public GameObject ball;
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
            Cut();
        };

        playerInput.Player.Slice.canceled += contex =>
        {
            StopTrail();
            isCutting = false;
        };
    }


    void Cut()
    {
        SlicedHull hull = SliceObject(ball, ball.GetComponent<Material>());
        GameObject bottom = hull.CreateLowerHull(ball, ball.GetComponent<Material>());
        GameObject top = hull.CreateUpperHull(ball, ball.GetComponent<Material>());
        AddHullComponents(bottom);
        AddHullComponents(top);
        Destroy(ball);
    }
    public void AddHullComponents(GameObject go)
    {
        go.layer = 9;
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        MeshCollider collider = go.AddComponent<MeshCollider>();
        collider.convex = true;

        rb.AddExplosionForce(100, go.transform.position, 20);
    }
    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        if (obj.GetComponent<MeshFilter>() == null)
            return null;

        return obj.Slice(cutPlane.position, cutPlane.up, crossSectionMaterial);
    }
    void StopTrail()
    {
        trailControl.gameObject.SetActive(false);
        Destroy(trailControl.gameObject
            , 2f);
        hasTrail = false;
    }
    void StartCutting()
    {
        
       
        Vector2 pos = playerInput.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mousePosition = new Vector3(pos.x, pos.y, Mathf.Abs(camera.transform.position.z));
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

       
        mousePosition.z = 0;
        trailControl.transform.position = mousePosition;
        mouse.position = mousePosition;
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
