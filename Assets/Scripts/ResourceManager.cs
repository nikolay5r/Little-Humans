using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int woodAmount;
    public int crystalAmount;
    public int bloodAmount;
    public TMP_Text woodDisplay;
    public TMP_Text crystalDisplay;
    public TMP_Text bloodDisplay;


    public static ResourceManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        woodDisplay.text = woodAmount.ToString();
        crystalDisplay.text = crystalAmount.ToString();
        bloodDisplay.text = bloodAmount.ToString();
    }

    public void AddResource(string resourceType, int amount)
    {
        switch (resourceType)
        {
            case "wood":
                woodAmount += amount;
                woodDisplay.text = woodAmount.ToString();
                break;
            case "crystal":
                crystalAmount += amount;
                crystalDisplay.text = crystalAmount.ToString();
                break;
            case "blood":
                bloodAmount += amount;
                bloodDisplay.text = bloodAmount.ToString();
                break;
        }
    }
}
