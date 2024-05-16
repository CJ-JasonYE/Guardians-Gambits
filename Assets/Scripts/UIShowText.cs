using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverText; // ��Inspector��ͼ�й���Ҫ��ʾ�����ֵ�Text���
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.SetActive(false);
    }
}
