using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour {

    public int selected_item = -1;

    public static ItemControl instance;

    public GameObject item_prefab, empty_item_prefab;

    public Transform item_menu;

    public ItemInfo[] items;

    public Color selected_color, deselected_color;

    private void Awake() {
        instance = this;
    }

    public Items getItemSelected() {
        if (selected_item >= 0)
            return item_menu.GetChild(selected_item).GetComponent<Item>().item_info.id;
        return Items.empty;
    }

    public void createItem (int id) {
        GameObject go = Instantiate(item_prefab, item_menu);
        updateItem(go, id);
        
    }

    public void loseItem() {
        Destroy(item_menu.GetChild(selected_item).gameObject);
        selected_item = -1;
    }

    void updateItem(GameObject go, int id) {
        //Debug.Log("updateItem");
        go.transform.GetChild(1).GetComponent<Image>().sprite = items[id].sprite;
        go.GetComponent<Button>().onClick.AddListener(delegate { clickItem(go.transform); });
        go.GetComponent<Image>().color = deselected_color;
        go.GetComponent<Item>().item_info = items[id];
    }

    public void combineItems (GameObject go, GameObject go2, int new_item_id) {
        Debug.Log("combine");
        Destroy(go2);
        Destroy(go);
        ItemControl.instance.createItem(new_item_id);
        SoundControl.instance.combineItems();
        selected_item = -1;
    }


    public void selectItem(int id) {

        if (!PlayerAction.can_act)
            return;

        Debug.Log("id: " + id);

        disableItemColors();

        if (id >= 0) {
            Image img = item_menu.GetChild(id).GetComponent<Image>();
            img.color = (selected_item == id ? deselected_color : selected_color);
        }
        Debug.Log("selected item: " + selected_item);
        if (selected_item != id) {
            Debug.Log("aqui");
            selected_item = id;
        }
        else {
            Debug.Log("aqui2");
            selected_item = -1;
        }
    }

    public void enableButtons (bool active) {
        for (int i = 0; i < item_menu.childCount; i++) {
            Button b = item_menu.GetChild(i).GetComponent<Button>();
            if (b != null)
                b.enabled = active;
        }
    }

    public void disableItemColors() {
        for (int i = 0; i < item_menu.childCount; i++) {
            item_menu.GetChild(i).GetComponent<Image>().color = deselected_color;
        }
    }

    public void clickItem (Transform t) {
        Debug.Log("click Item");
        selectItem (t.GetSiblingIndex());
    }

    public void spentItem() {
        selectItem(-1);
    }



}
