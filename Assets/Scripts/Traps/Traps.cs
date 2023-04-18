using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Traps : MonoBehaviour
{
    public GameObject checkpoint;

    private Vector3 _checkpoint;

    private int deathCounter = 0;

    [SerializeField] private TextMeshProUGUI deathCounterHud;

    public GroundCheck ground;
    
    // Start is called before the first frame update
    void Start()
    {

        _checkpoint = checkpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = _checkpoint;
            deathCounter++;
            deathCounterHud.text = deathCounter.ToString();

        }
    }
    
}
