using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SacrificeManager : MonoBehaviour
{
    public TMP_Text sacrificedDisplay;
    public int sacrificedGoal = 25;

    int numberOfSacrificedWorkers;
    
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
        numberOfSacrificedWorkers = 0;
        sacrificedDisplay.text = numberOfSacrificedWorkers + "/" + sacrificedGoal;
    }

    void Update()
    {
        if (numberOfSacrificedWorkers >= sacrificedGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddSacrificedWorkers(int amount = 1)
    {
        numberOfSacrificedWorkers += amount;
        sacrificedDisplay.text = numberOfSacrificedWorkers + "/" + sacrificedGoal;
    }
}
