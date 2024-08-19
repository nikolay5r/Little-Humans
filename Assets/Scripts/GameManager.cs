using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string gameState = "play";
    public GameObject losingScreen;
    public GameObject winningScreen;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "lose")
        {
            losingScreen.GetComponent<Animator>().SetTrigger("show");

        }

        if (gameState == "win")
        {
            winningScreen.GetComponent<Animator>().SetTrigger("show");
        }
    }

    void GameOverScenario()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
