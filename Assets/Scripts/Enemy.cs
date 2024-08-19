using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;
    public GameObject blood;
    public GameObject bloodParticles;
    public int health = 2;

    Vector3 currentTarget;
    const float MIN_TARGET_DISTANCE = 0.5f;
    Animator cameraAnimator;

    public AudioSource deathSound;

    void Start()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
        currentTarget = GetRandomPosition();    
    }

    void Update()
    {
        if (GameManager.Instance.gameState == "play")
        {
            if (health <= 0)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (Vector3.Distance(currentTarget, transform.position) <= MIN_TARGET_DISTANCE)
            {
                currentTarget = GetRandomPosition();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altar")
        {
            GameManager.Instance.gameState = "lose";
        }

        if (collision.tag == "Trap")
        {
            cameraAnimator.SetTrigger("shake");
            collision.GetComponent<Trap>().durability--;
            Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(bloodParticles, transform.position, Quaternion.identity);
            Instantiate(deathSound);
            Destroy(gameObject);
        }

        if (collision.tag == "Human")
        {
            cameraAnimator.SetTrigger("shake");
            Instantiate(deathSound);
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Instantiate(bloodParticles, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            health--;
        }
    }
}
