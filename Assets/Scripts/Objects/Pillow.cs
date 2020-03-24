using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : InteragableObject {

    bool opened = false;

    public Animator animator;

    public override void interact() {
        if (!PlayerAction.can_act || opened)
            return;

        if (ItemControl.instance.getItemSelected() == Items.knife) {
            ripPillow();
        }
        else {
            DescriptionControl.instance.showMessage("Um travesseiro...");
        }
    }

    void ripPillow() {
        ItemControl.instance.loseItem();
        PlayerAction.can_act = false;
        opened = true;
        SoundControl.instance.ripPillow();
        DescriptionControl.instance.showMessage("Você encontrou um registro de torneira.");
        ItemControl.instance.createItem((int)Items.tap);
        animator.Play("RipPillow");
    }

    public void completeAnimation() {
        PlayerAction.can_act = true;
    }
}
