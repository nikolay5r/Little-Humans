using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int bloodCost;
    public int woodCost;
    public int crystalCost;

    Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    void Update()
    {
        if (button)
        {
            if (ResourceManager.Instance.woodAmount < woodCost || ResourceManager.Instance.bloodAmount < bloodCost || ResourceManager.Instance.crystalAmount < crystalCost)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }

    public void RemoveResources()
    {
        ResourceManager.Instance.AddResource("blood", -bloodCost);
        ResourceManager.Instance.AddResource("wood", -woodCost);
        ResourceManager.Instance.AddResource("crystal", -crystalCost);
    }
}
