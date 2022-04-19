using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster _raycaster;
    PointerEventData pData;
    EventSystem eventSystem;
    
    public Transform selectionPoint;


    // Start is called before the first frame update
    void Start()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);
        pData.position = selectionPoint.position;
    }

    public static UIManager instance;  
    public static UIManager Instance 
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _raycaster.Raycast(pData,results);

        foreach (RaycastResult result in results)
        {
            if(result.gameObject==button)
            {
                return true;
            }
        }
        return false;
    }
}
