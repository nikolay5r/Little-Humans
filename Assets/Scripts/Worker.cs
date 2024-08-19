using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Worker : MonoBehaviour
{
    bool isSelected = false;

    public float collectDistance;
    public LayerMask resourceLayer;
    Resource currentResource = null;

    public int resourceAmountToCollect;
    public float timeBetweenCollection;
    float nextCollectionTime;

    GameObject bloodAltar;
    const float MIN_SACRIFICE_DISTANCE = 2f;

    public TextPopUp resourcePopUp;
    public AudioSource popSound;
    public AudioSource collectSound;
    public AudioSource sacrificeSound;

    private void Start()
    {
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    void Update()
    {
        if (GameManager.Instance.gameState != "play")
        {
            return;
        }
        if (isSelected)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
        } else
        {
            Sacrifice();
            CollectResource();
        }
    }

    private void OnMouseDown()
    {
        Instantiate(popSound);
        isSelected = true;
    }

    private void OnMouseUp()
    {
        Instantiate(popSound);
        isSelected = false;
    }

    private void CollectResource()
    {
        Collider2D collectionCircle = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
        if (collectionCircle && !currentResource)
        {
            currentResource = collectionCircle.GetComponent<Resource>();
        } else
        {
            currentResource = null;
        }

        if (currentResource && Time.time > nextCollectionTime)
        {
            int collectedResource = currentResource.getResourceAmount() - resourceAmountToCollect < 0 ? currentResource.getResourceAmount() : resourceAmountToCollect;
            currentResource.collectResource(resourceAmountToCollect);
            ResourceManager.Instance.AddResource(currentResource.type, collectedResource);
            nextCollectionTime = Time.time + timeBetweenCollection;
        
            resourcePopUp.resourceText.text = "+" + collectedResource;
            Instantiate(resourcePopUp, transform.position, Quaternion.identity);
            Instantiate(collectSound);
        }
    }

    private void Sacrifice()
    {
        if (Vector3.Distance(transform.position, bloodAltar.transform.position) < MIN_SACRIFICE_DISTANCE)
        {
            SacrificeManager.Instance.AddSacrificedWorkers();
            Instantiate(sacrificeSound);
            Destroy(gameObject);
        }
    }
}
