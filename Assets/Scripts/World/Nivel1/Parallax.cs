using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;

    private Vector2 startPosition;
    private Vector2 travelDistance => (Vector2) cam.transform.position - startPosition;
    private float distanceFromPlayer => transform.position.z - GameManager.GM.playerManager.GetPlayerTransform().position.z;

    private float clippingPane =>
        (cam.transform.position.z + (distanceFromPlayer > 0 ? cam.farClipPlane : cam.nearClipPlane));

    private float parallaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPane;
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        var newPos = startPosition + travelDistance * parallaxFactor;
        float lastZ = transform.position.z;
        transform.position = new Vector3(newPos.x, newPos.y, lastZ);
    }
}
