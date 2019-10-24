using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HotbarSpaceComponent : MonoBehaviour
{
    private Image imageCase { get; set; }

    [SerializeField]
    public int ID { get; private set; }
    private void Awake()
    {
        imageCase = GetComponent<Image>();
    }

    public void RefreshCase(IItem item)
    {
        Debug.Assert(item.displayImage != null);
        imageCase.sprite = item.displayImage;
    }
    
    public void HideImage()
    {
        imageCase.sprite = null;
    }
}
