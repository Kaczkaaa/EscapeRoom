using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIThrowable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAppearThrow;
    void Start()
    {
        textAppearThrow.enabled = false;
    }
    private void OnMouseEnter()
    {
        if (CompareTag("Throwable"))
            textAppearThrow.enabled = true;
    }

    private void OnMouseExit()
    {
        if (CompareTag("Throwable"))
            textAppearThrow.enabled = false;
    }
}