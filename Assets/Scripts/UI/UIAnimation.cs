using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
}
