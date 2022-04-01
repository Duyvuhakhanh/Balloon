using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public ParticleSystem fragment;
    private Animator ballAnim;

    private void Start()
    {   
        ballAnim = gameObject.GetComponentInChildren<Animator>();
    }
    private void OnMouseDown()
    {
        
        if (!ballAnim.GetBool("hasClicked"))
        {
            GameManager.instance.AddScore(1);
        }
        ballAnim.SetBool("hasClicked", true);
        fragment.Play();

        StartCoroutine("Wait");
        
   
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.85f);

        gameObject.SetActive(false);
        ballAnim.SetBool("hasClicked", false);
    }
}
