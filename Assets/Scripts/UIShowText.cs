using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverText; // 在Inspector视图中关联要显示的文字的Text组件
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.SetActive(false);
    }
}
