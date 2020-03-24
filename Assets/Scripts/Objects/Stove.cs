using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : InteragableObject {

    public int[] dials;

    public GameObject[] buttons;

    public int[] answer;

    public bool complete = false;

    public Animator animator;
    public FocusObject focus_object;

    public BoxCollider bc;

    public override void interact() {
        
    }

    public void updateButton(int id) {

        if (complete)
            return;

        dials[id]++;
        if (dials[id] > 6)
            dials[id] = 0;

        buttons[id].transform.eulerAngles = new Vector3(0, 0, -90 + dials[id] * 30);

        bool found = true;

        for (int i = 0; i < answer.Length; i++)
            if (answer[i] != dials[i])
                found = false;

        if (found) {
            completePuzzle();
        }
    }


    void completePuzzle() {
        bc.enabled = false;
        PlayerAction.can_act = false;
        complete = true;
        SoundControl.instance.openSomething();
        animator.Play("Open");
        focus_object.target = transform.parent;
        CameraMovement.instance.moveCameraTo(transform.parent, focus_object.target_camera_position);
        Invoke("enableAction", 0.5f);
    }

    void enableAction() {
        PlayerAction.can_act = true;
    }
}
