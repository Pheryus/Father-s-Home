using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceControl : MonoBehaviour {

    public static InterfaceControl instance;

    public GameObject exit_arrow;

    private void Awake() {
        instance = this;
    }

    public void enableExitArrow() {
        PlayerAction.focus_on_object = true;
        exit_arrow.SetActive(true);
    }

    public void clickOnExitArrow() {

        if (!PlayerAction.can_act)
            return;

        exitFocusMode();
        CameraMovement.instance.moveCamera();
    }

    public void exitFocusMode() {
        GameControl.instance.target_object.GetComponent<FocusObject>().endInteraction();

        PlayerAction.focus_on_object = false;
        exit_arrow.SetActive(false);
    }

}
