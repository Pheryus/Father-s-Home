using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : FocusObject {

    public GameObject[] drawers;

    public BoxCollider[] cabinet_box_collider;

    public BoxCollider drawer_collider;

    public override void focus(bool rotate) {
        base.focus(rotate);

        enableCabinetColliders(false);
        enableDrawerColliders(true);
    }

    public void enableCabinetColliders(bool enable) {
        foreach (BoxCollider b in cabinet_box_collider)
            b.enabled = enable;
    }

    public void enableDrawerColliders(bool enable) {
        foreach (GameObject go in drawers) {
            BoxCollider bc = go.GetComponent<BoxCollider>();
            if (bc != null)
                bc.enabled = enable;
            else {
                go.GetComponent<MeshCollider>().enabled = enable;
            }

        }
    }
    

    public override void endInteraction() {
        base.endInteraction();
        enableCabinetColliders(true);
        enableDrawerColliders(false);
    }


}
