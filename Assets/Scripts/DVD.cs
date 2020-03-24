using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVD : InteragableObject {

    public bool has_dvd = false;

    public override void interact() {
        if (!PlayerAction.can_act)
            return;
        if (Items.dvd == ItemControl.instance.getItemSelected() && !has_dvd) {
            putDvd();
        }
        else
            base.interact();
    }

    void putDvd() {
        ItemControl.instance.loseItem();
        has_dvd = true;
        SoundControl.instance.clickButton();
        message = "Um DVD em funcionamento.";
    }
}
