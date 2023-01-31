using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GooFadeOut : MonoBehaviour
{

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        fadeout();
    }

    public void fadeout()
    {
        gameObject.SetActive(true);
        Color color = image.color;


        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }

        image.color = color;
    }
}
