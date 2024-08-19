using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int durability = 3;

    // Update is called once per frame
    void Update()
    {
        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
