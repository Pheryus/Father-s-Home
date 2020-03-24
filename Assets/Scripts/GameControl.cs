using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public static GameControl instance;

    public GameObject target_object;

    public InterfaceControl interface_control;

    public bool color_switch_active = false;

    private void Awake() {
        instance = this;    
    }


    public void interactWithObject (Transform t) {
        FocusObject interagable = t.GetComponent<FocusObject>();
        if (interagable != null) {
            target_object = t.gameObject;
            interface_control.enableExitArrow();
           
            interagable.focus(interagable.rotate_when_focus);
        }
    }
}
