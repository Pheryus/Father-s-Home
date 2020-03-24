using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSuport : InteragableObject {

    public bool complete = false;

    public Drawer drawer;

    public GameObject glass;
    

    public override void interact() {
        if (!PlayerAction.can_act)
            return;

        if (ItemControl.instance.getItemSelected() == Items.complete_glass) {
            completePuzzle();
        }
        else if (!complete)
            base.interact();
    }

    public void completePuzzle() {
        glass.SetActive(true);
        ItemControl.instance.loseItem();
        SoundControl.instance.openDoor();
        drawer.can_open_drawer = true;
        DescriptionControl.instance.showMessage("Algum mecanismo foi desbloqueado.");

    }

}
