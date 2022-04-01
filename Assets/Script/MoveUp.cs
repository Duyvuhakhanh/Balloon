using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] float speed = 20;

    // Update is called once per frame
    void Update()
    {
        Up();
    }

    private void Up()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
        if (transform.position.y > ObjectPool.backgroundRectTransform.sizeDelta.y / 2)
        {
            gameObject.SetActive(false);
        }
    }

}
