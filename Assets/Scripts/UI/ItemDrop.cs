using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler {

    public Item item;


    public void OnDrop(PointerEventData event_data) {
        if (!PlayerAction.can_act)
            return;

        Debug.Log("OnDrop");

        GameObject go = event_data.pointerDrag;
        Debug.Log(go.GetComponent<Item>().item_info.id);
        Debug.Log(item.item_info.id);
        int item1 = (int)item.item_info.id;
        int item2 = (int)go.GetComponent<Item>().item_info.id;

        int result_item = Mathf.Max(ItemRecipes.getResultItem(item1, item2), ItemRecipes.getResultItem(item2, item1));

        if (result_item >= 0) {
            ItemDrag drag = event_data.pointerDrag.gameObject.GetComponent<ItemDrag>();
            drag.combine = true;
            PlayerAction.dragging_item = false;
            Destroy(drag.copy);
            
            ItemControl.instance.combineItems(gameObject, go, result_item);
            ItemControl.instance.enableButtons(true);
        }


    }

}
