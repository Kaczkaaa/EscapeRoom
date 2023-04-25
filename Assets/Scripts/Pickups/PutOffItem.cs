using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PutOffItem : MonoBehaviour
{
    public PickUpItem itemsPickedUp;
    private int itemToPutOff;
    public GameObject putOffText;

    public GameObject putOffItem;

    public TextMeshProUGUI itemsPickedUpHUD;

    [SerializeField] private Transform camera;

    [SerializeField] private float maxDistance;

    private bool isInRayCast;
    // Start is called before the first frame update
    void Start()
    {
        putOffText.SetActive(false);
        isInRayCast = false;
    }

    // Update is called once per frame
    void Update()
    {
        camera = Camera.main.transform;
        RaycastHit hit;
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
            Debug.DrawLine(camera.position,camera.forward * maxDistance, Color.yellow);
            var selection = hit.transform;
            if (selection.tag == "PutOff")
            {
                isInRayCast = true;
                putOffText.SetActive(true);
                itemToPutOff = itemsPickedUp.itemsPickUpsInt;
            }
            else
            {
                isInRayCast = false;
                putOffText.SetActive(false);
            }
        }
    }
    
    public void OnPutOffItems(InputAction.CallbackContext context)
    {
        if (isInRayCast == true && itemToPutOff > 0 && context.started)
        {
            Debug.Log(4);
            PutOff();
        }
    }
    
    void PutOff()
    {
        itemToPutOff -= 1;
        putOffText.SetActive(false);
        putOffItem.GetComponent<BoxCollider>().enabled = false;
        putOffItem.GetComponent<MeshRenderer>().enabled = true;
        itemsPickedUpHUD.text = itemToPutOff.ToString();
    }
}