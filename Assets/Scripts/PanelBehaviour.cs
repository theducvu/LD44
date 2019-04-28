using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviour : MonoBehaviour
{
    Image img;
    Color defaultColor;
    Color hoverColor;

    private void Start()
    {
        img = GetComponent<Image>();
        defaultColor = new Color(img.color.r, img.color.g, img.color.b, .5f);
        hoverColor = new Color(img.color.r, img.color.g, img.color.b, .8f);
    }

    public void Hover()
    {
        img.color = hoverColor;
    }

    public void Dehover()
    {
        img.color = defaultColor;
    }
}
