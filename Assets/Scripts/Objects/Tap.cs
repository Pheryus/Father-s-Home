using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : InteragableObject {

    public bool has_tap = false;

    public GameObject tap_go;

    public TapRegister tap_register;

    public BoxCollider bc;

    public override void interact() {
        if (!PlayerAction.can_act)
            return;


        if (ItemControl.instance.getItemSelected() == Items.tap) {
            putTap();
            return;
        }
        else if (tap_register.turned_on) {
            if (ItemControl.instance.getItemSelected() == Items.glass) {
                putGlass();
            }
            else
                message = "A torneira está aberta";
        }
        else if (has_tap)
            message = "Uma torneira com registro.";

        base.interact();
        
    }

    void putGlass() {
        SoundControl.instance.fillWater();
        ItemControl.instance.loseItem();
        ItemControl.instance.createItem((int)Items.water_glass);
        DescriptionControl.instance.showMessage("Você encheu o copo de água");
    }

    public void putTap() {
        //bc.enabled = false;
        tap_go.SetActive(true);
        ItemControl.instance.loseItem();
        SoundControl.instance.openSomething();
        message = "Uma torneira com registro.";

    }
}
