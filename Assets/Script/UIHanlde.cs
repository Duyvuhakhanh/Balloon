using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHanlde : MonoBehaviour
{
    [SerializeField] Text scoreText;

    void Update()
    {
        scoreText.text = $"Score: {GameManager.instance.score}";
    }
}
