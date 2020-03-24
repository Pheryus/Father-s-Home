using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Vector3 start_position;

    Transform save_parent;

    public GameObject copy;

    public Item item;

    public bool combine = false;

    public void OnBeginDrag (PointerEventData event_data) {

        if (!PlayerAction.can_act)
            return;

        PlayerAction.dragging_item = true;

        ItemControl.instance.enableButtons(false);

        start_position = transform.position;
        save_parent = transform.parent;
        copy = Instantiate(ItemControl.instance.empty_item_prefab, transform.parent);

        int siblind_index = transform.GetSiblingIndex();
        transform.SetParent(transform.parent.parent);
        copy.transform.SetSiblingIndex(siblind_index);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData event_data) {
        if (!PlayerAction.can_act)
            return;

        transform.position = new Vector2(transform.position.x, Input.mousePosition.y);
    }
    
    public void OnEndDrag (PointerEventData event_data) {
        if (!PlayerAction.can_act || combine)
            return;

        Debug.Log("OnEndDrag");
        PlayerAction.dragging_item = false;

        transform.position = start_position;
        transform.SetParent(save_parent);
        int index = copy.transform.GetSiblingIndex();
        Destroy(copy);
        transform.SetSiblingIndex(index);
        ItemControl.instance.enableButtons(true);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
