using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] float maxWeight = 10;
    private float currentWeight;
    [SerializeField] int capacity = 5;
    Item[] currentItems;
    private Item subscribedItem;
    private GameObject subscribedObject;
    ItemGiver itemGiver;
    // Start is called before the first frame update
    void Start()
    {
        currentItems = new Item[capacity];
    }

    // Update is called once per frame
    void Update()
    {
        currentWeight = maxWeight;
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem(subscribedItem);

            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
       
        subscribedObject = other.gameObject;
        itemGiver = subscribedObject.GetComponent<ItemGiver>();
        Item item = subscribedObject.gameObject.GetComponent<ItemGiver>().item;
        if (item != null && itemGiver != null)
        {
            subscribedItem = item;
            Debug.Log($"Subscribed : {item.Name}");
        }
    }
    bool CanAddItem(Item item)
    {
        int freeSlots = 0;

        foreach (var items in currentItems)
        {
            if (items == null)
            {
                freeSlots++;
            }
            
        }
        if (freeSlots > 0 && item.Weight < currentWeight)
        {
            return true;
        }
        else
        return false;
    }
    void AddItem(Item item)
    {

        if (CanAddItem(item))
        {
          for(int i = 0; i< currentItems.Length; i++)
            {
                if(currentItems[i] == null)
                {
                    currentWeight -= item.Weight;
                    currentItems[i] = item;
                    Debug.Log($"Dodalo : {item.Name} current weight: {currentWeight}");
                    itemGiver.hideWidgetItem();
                    Destroy(subscribedObject);
                    
                    return;
                }
            }
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        subscribedItem = null;
        subscribedObject = null;
        Debug.Log("unsub");
    }
}
