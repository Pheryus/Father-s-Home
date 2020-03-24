using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : InteragableObject {
    public Items id;

    public override void interact() {
        Debug.Log("interact");
        ItemControl.instance.createItem((int)id);
        Destroy(gameObject);

        if (id == Items.knob)
            DescriptionControl.instance.showMessage("Você achou uma maçaneta.");
        else if (id == Items.red_key)
            DescriptionControl.instance.showMessage("Você achou uma chave.");
        else if (id == Items.knife)
            DescriptionControl.instance.showMessage("Você achou uma faca.");
        else if (id == Items.ice)
            DescriptionControl.instance.showMessage("Você achou gelo.");
        else if (id == Items.straw)
            DescriptionControl.instance.showMessage("Você achou um canudo.");
        else if (id == Items.glass)
            DescriptionControl.instance.showMessage("Você achou um copo.");
        SoundControl.instance.findItem();
    }

}
