using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : InteragableObject {

    public bool turned_on = false;

    public Material mat;

    public MeshRenderer mesh;

    public override void interact() {

        if (!PlayerAction.can_act || turned_on)
            return;

        if (ItemControl.instance.getItemSelected() == Items.tv_control) {
            turnOnTV();
        }

        if (!turned_on)
            base.interact();

    }

    public void turnOnTV() {
        mesh.material = mat;
        ItemControl.instance.loseItem();
        turned_on = true;
        SoundControl.instance.clickButton();
        Debug.Log("tv");
        InGameMessages.instance.endGame();
    }
}
