using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CraftPreviewComponent : MonoBehaviour
{
    private Image imageCase { get; set; }

    private void Awake()
    {
        imageCase = GetComponent<Image>();
    }

    public void ShowImage(Sprite image)
    {
        imageCase.sprite = image;
    }

    public void HideImage()
    {
        imageCase.sprite = null;
    }
}
