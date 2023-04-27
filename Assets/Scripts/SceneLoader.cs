using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int actualScene;

    private int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        actualScene = SceneManager.sceneCount;
        nextScene = actualScene + 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
