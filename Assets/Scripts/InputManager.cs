using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
   // [SerializeField] private GameObject arObj;
    
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject crosshair;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();
        touch = Input.GetTouch(0);
        if(Input.touchCount<0 || touch.phase!=TouchPhase.Began) 
        {
            return;
        }
        if(IsPointerOverUI(touch)) return;
        

        // Ray ray = arCam.ScreenPointToRay(touch.position);
        // if(_raycastManager.Raycast(ray,_hits))
        // {
        //     Pose pose = _hits[0].pose;
        //     Instantiate(DataHandler.Instance.furniture,pose.position, pose.rotation);
        // }
        Instantiate(DataHandler.Instance.GetFurniture(),pose.position, pose.rotation);

    }

    bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData,results);
        return results.Count>0;
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f,0.5f,0));
        Ray ray = arCam.ScreenPointToRay(origin);
        if(_raycastManager.Raycast(ray,_hits))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90,0,0);
        }
    }

    public void HomeSceneloader()
    {
        SceneManager.LoadScene(0);
    }

    public void Scene1loader()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene2loader()
    {
        SceneManager.LoadScene(2);
    }
    public void Close_Instructions()
    {
        GameObject.Find("Instruction_Panel").SetActive(false);

    }
}
