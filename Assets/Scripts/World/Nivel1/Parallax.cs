using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer sprite;
    public bool isHorizon;

    private Vector2 startPosition;
    private Vector2 travelDistance => (Vector2) cam.transform.position - startPosition;
    private float distanceFromPlayer => transform.position.z - GameManager.GM.playerManager.GetPlayerTransform().position.z;
    private float clippingPane =>
        (cam.transform.position.z + (distanceFromPlayer > 0 ? cam.farClipPlane : cam.nearClipPlane));
    private float parallaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPane;
    private float length;
    
    void Start()
    {
        startPosition = transform.position;
        length = sprite.bounds.size.x;
    }
    
    void Update()
    {
        float temp     = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;
 
        if(!isHorizon)
            transform.position = new Vector3(startPosition.x + distance, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(startPosition.x + distance, cam.transform.position.y, transform.position.z);
 
        if (temp > startPosition.x + (length / 2))    
            startPosition.x += length;
        else if (temp < startPosition.x - (length / 2)) 
            startPosition.x -= length;
    }
}
