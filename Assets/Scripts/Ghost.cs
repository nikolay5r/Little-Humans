using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject objectToSpawn;
    public ParticleSystem buildParticles;
    public AudioSource placeSound;

    Animator cameraAnimator;

    private void Start()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            cameraAnimator.SetTrigger("shake");
            Instantiate(placeSound);
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Instantiate(buildParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
