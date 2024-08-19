using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string type;
    public int resourceAmountMin;
    public int resourceAmountMax;
    int resourceAmount;

    private void Start()
    {
        resourceAmount = Random.Range(resourceAmountMin, resourceAmountMax);
    }

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getResourceAmount()
    {
        return resourceAmount;
    }

    public void collectResource(int amount)
    {
        resourceAmount -= amount;
    }
}