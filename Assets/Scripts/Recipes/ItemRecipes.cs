using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemRecipes {
  
    public static int getResultItem (int item1, int item2) {
        if (item1 == (int)Items.tv_control_no_battery && item2 == (int)Items.battery)
            return (int)Items.tv_control;
        if (item1 == (int)Items.water_glass && item2 == (int)Items.ice)
            return (int)Items.ice_water_glass;
        if (item1 == (int)Items.ice_water_glass && item2 == (int)Items.straw)
            return (int)Items.complete_glass;

        return -1;
    }
}
