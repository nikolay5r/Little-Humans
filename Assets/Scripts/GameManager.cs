using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string gameState = "play";
    public Animator losingScreenAnim;
    public Animator winningScreenAnim;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "lose")
        {
            losingScreenAnim.SetTrigger("show");
            GameOverScenario();

        }

        if (gameState == "win")
        {
            winningScreenAnim.SetTrigger("show");
            GameOverScenario();
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
