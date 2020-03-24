using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSafe : MonoBehaviour {

    public Drawer[] drawers;

    public bool complete = false;

    public Switch light_switch, color_switch;

    public BoxCollider bc;

    public Animator animator;

    private void Update() {
            if (!complete && !light_switch.turned_on && drawers[0].drawer_open && drawers[1].drawer_open 
            && !drawers[2].drawer_open && !drawers[3].drawer_open && color_switch.turned_on) {
            completePuzzle();
        }
    }

    public void completePuzzle() {
        Debug.Log("COMPLETOU");
        complete = true;
        DescriptionControl.instance.showMessage("Escutei um barulho que veio da cozinha.");
        SoundControl.instance.openDoor();
    }

}
