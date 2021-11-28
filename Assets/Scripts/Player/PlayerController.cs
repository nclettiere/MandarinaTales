using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Attack attackScript;
    Movement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        attackScript = GetComponent<Attack>();
        movementScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
