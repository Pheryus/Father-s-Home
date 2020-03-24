using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapRegister : InteragableObject {

    public GameObject water;

    public bool turned_on = false;

    public override void interact() {
        if (!PlayerAction.can_act)
            return; 

        turned_on = !turned_on;
        water.SetActive(turned_on);
    }

}
