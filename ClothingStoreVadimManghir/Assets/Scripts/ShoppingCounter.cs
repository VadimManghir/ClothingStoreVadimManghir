using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInShop
{
    public Sprite sprite;
    public int price;
    public Stand.KindOfItem kindOfItem;
}


public class ShoppingCounter : MonoBehaviour
{
    public ItemInShop[] itemsInTheShop;
    bool ActiveStatus;


    private void Start()
    {
        UiManeger.OpenAction += ShowPurchasedItems;
    }

    private void OnDestroy()
    {
        UiManeger.OpenAction -= ShowPurchasedItems;
    }

    public void ShowPurchasedItems()
    {
        if (!ActiveStatus)
        { return; }

        //method that shows the purchased (CountPurchasedItems()) items in the UI    

    }
    public ItemInShop[] CountPurchasedItems()
    {
        CustomAnimator customAnimator = FindObjectOfType<CustomAnimator>();

        ItemInShop[] purchasedItems = new ItemInShop[0];

        foreach (ItemInShop nextItem in itemsInTheShop) 
        { 
            switch(nextItem.kindOfItem)
            {
                case Stand.KindOfItem.Armor:
                    
                   foreach(var nextSprite in customAnimator.Armor)
                   {
                         if( nextSprite.sprite == nextItem.sprite)
                         {
                            Array.Resize(ref purchasedItems, purchasedItems.Length + 1);
                            purchasedItems[purchasedItems.Length - 1] = nextItem;
                         }
                       
                   }
                break;

                case Stand.KindOfItem.Hat:

                    foreach (var nextSprite in customAnimator.Hat)
                    {
                        if (nextSprite.sprite == nextItem.sprite)
                        {
                            Array.Resize(ref purchasedItems, purchasedItems.Length + 1);
                            purchasedItems[purchasedItems.Length - 1] = nextItem;
                        }

                    }
                break;
            }
        }

        return purchasedItems;

    }
}
