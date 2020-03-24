using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items { knob = 0, red_key, tv_control_no_battery, battery, tv_control, knife, straw, ice,
    glass, water_glass, ice_water_glass, complete_glass, tap, dvd, empty=-1, none = -2};


public class Item : MonoBehaviour {

    public ItemInfo item_info;

    private void Start() {
        
    }

}
