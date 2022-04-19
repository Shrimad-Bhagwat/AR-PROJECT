using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataHandler : MonoBehaviour
{
    private GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;    
    [SerializeField] private List<Item> items;    
    // [SerializeField] private String label;    
    

    
    private int currrent_id = 0;
    
    
    private static DataHandler instance;
    public static DataHandler Instance 
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    private void Start() {
        // items = new List<Item>();
        LoadItems();
        // await Get(label);
        CreateButtons();
    }

    void LoadItems()
    {
        var item_obj = Resources.LoadAll("Items",typeof(Item));
        foreach (var item in item_obj)
        {
            items.Add(item as Item);
        }
    }

    void CreateButtons()
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab,buttonContainer.transform);
            b.ItemId = currrent_id;
            b.ButtonTexture = i.itemImage;
            currrent_id++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    // public async Task Get(String label)
    // {
    //     var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
    //     foreach (var location in locations)
    //     {
    //         var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
    //         items.Add(obj);
    //     }
    // }

}
