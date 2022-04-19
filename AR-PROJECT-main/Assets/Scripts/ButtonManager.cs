using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] private RawImage buttonImage;

    public GameObject furniture;

    private int itemId;
    private Sprite buttonTexture;

    public int ItemId
    {
        set{
            itemId = value;
        }
    }

    public Sprite ButtonTexture
    {
        set{
            buttonTexture = value;
            buttonImage.texture = buttonTexture.texture;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    void Update() {
        if(UIManager.Instance.OnEntered(gameObject))
        {
            // transform.localScale = Vector3.one * 2;
            transform.DOScale(Vector3.one * 1.8f,0.2f);
        }   
        else
        {
            // transform.localScale = Vector3.one;
            transform.DOScale(Vector3.one,0.2f);
        }
    }

    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(itemId);
    }
}
