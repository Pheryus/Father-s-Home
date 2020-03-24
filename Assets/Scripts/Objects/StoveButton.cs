using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveButton : InteragableObject {

    public Stove stove;

    public int button_id;

    public override void interact() {
        if (!PlayerAction.can_act)
            return;

        stove.updateButton(button_id);
    }



}
