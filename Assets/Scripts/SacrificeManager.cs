using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SacrificeManager : MonoBehaviour
{
    public TMP_Text sacrificedDisplay;
    public int sacrificedGoal = 25;

    int numberOfSacrificedWorkers = 0;
    
    public static SacrificeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        sacrificedDisplay.text = numberOfSacrificedWorkers + "/" + sacrificedGoal;
    }

    void Update()
    {
        if (numberOfSacrificedWorkers >= sacrificedGoal)
        {
            GameManager.Instance.gameState = "win";
        }
    }

    public void AddSacrificedWorkers(int amount = 1)
    {
        numberOfSacrificedWorkers += amount;
        sacrificedDisplay.text = numberOfSacrificedWorkers + "/" + sacrificedGoal;
    }
}
