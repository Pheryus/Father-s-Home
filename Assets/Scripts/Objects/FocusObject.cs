using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FocusObject : MonoBehaviour {

    public Vector3 target_camera_position, target_camera_rotation;

    bool on_focus = false;

    CameraMovement camera_movement;

    public bool hack = false;

    HackMessages hack_messages;

    public hack_messages hack_message;

    public bool rotate_when_focus = true;

    public Transform target;

    public bool normal = true;

    public bool disable_bc = false;

    public BoxCollider bc;

    private void Start() {
        camera_movement = CameraMovement.instance;
        hack_messages = HackMessages.instance;
        if (normal)
            target = transform;
    }
    
    public virtual void focus(bool rotate) {
        if (disable_bc)
            bc.enabled = false;

        on_focus = true;
        camera_movement.saveCamera();
        camera_movement.moveCameraTo(target, target_camera_position, rotate);
    }

    public virtual void endInteraction() {
        if (disable_bc)
            bc.enabled = true;

        hack = false;
        hack_messages.closeHackWindow();
        GameControl.instance.target_object = null;
        on_focus = false;
    }

    public void hackObject() {
        hack = !hack;
        if (hack)
            hack_messages.setMessage(hack_message);
        else
            hack_messages.closeHackWindow();
    }

    public void endHack() {
        hack = false;
        hack_messages.closeHackWindow();
    }

}
