using System;
using System.Net;
using UnityEngine;
public class AnimationCurveController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float currentTime;
    public AnimationCurve curve;
    void Start()
    {
        startPoint = transform.position;
        endPoint = Vector3.Scale(startPoint, new Vector3(-1, 1, 1));
    }
    void Update()
    {
        currentTime += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(startPoint, endPoint, curve.Evaluate(currentTime));
    }
}
