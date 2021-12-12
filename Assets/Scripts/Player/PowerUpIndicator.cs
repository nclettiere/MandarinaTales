using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIndicator : MonoBehaviour
{
    public void OnIndicatorDone()
    {
        Destroy(gameObject);
    }
}
