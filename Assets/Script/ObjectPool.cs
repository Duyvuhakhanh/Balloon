using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;

    public int amountToPool;

    public static RectTransform backgroundRectTransform;

    public float startDelay = 1.5f;
    public float spawnInterval = 2.0f;

    void Awake()
    {
        SharedInstance = this;
        backgroundRectTransform = GameObject.Find("Background").GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of SpawnManager
        }


        InvokeRepeating("GetPooledObject", startDelay, spawnInterval);
    }

    public GameObject GetPooledObject()
    {
        float spawnPosX = Random.Range( 5 -backgroundRectTransform.sizeDelta.x / 2, backgroundRectTransform.sizeDelta.x / 2 - 5); // 5 is the offset
        float spawnPosY = -backgroundRectTransform.sizeDelta.y/2 ; 
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY);
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = spawnPos;
                pooledObjects[i].gameObject.SetActive(true);
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

}
