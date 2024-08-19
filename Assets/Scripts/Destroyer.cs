using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyAfter;

    private void Start()
    {
        destroyAfter += Time.time;
    }

    void Update()
    {
        if (Time.time >= destroyAfter)
        {
            Destroy(gameObject);
        }
    }
}
