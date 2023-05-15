using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoldingItems : MonoBehaviour
{
    [SerializeField] Transform camera;

    [SerializeField] float maxDistance;

    public GameObject heldObj;

    public Rigidbody heldObjRB;

    [SerializeField] Transform holdArea;
    [SerializeField] float pickupForce = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heldObj != null)
        {
            MoveObject();
        }
    }
    public void OnHoldObject(InputAction.CallbackContext context)
    {
        if (heldObj == null)
        {
            RayCast();
        }
        else
        {
            DropObject();
        }
    }
    void RayCast()
    {
        camera = Camera.main.transform;

        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            PickupObject(hit.transform.gameObject);
        }
    }
    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObj = pickObj;
            heldObj.transform.parent = holdArea;
            heldObjRB.drag = 10;
            heldObjRB.useGravity = false;
            
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            
        }
    }
    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObj.transform.parent = null;
        heldObj = null;

    }
    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
}
