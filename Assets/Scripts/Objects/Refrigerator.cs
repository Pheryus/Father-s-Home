using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour {

    public Text text;

    public int[] binary;

    public int[] answer;

    int numbers_input = 0;

    bool complete = false;

    public Animator animator;

    public BoxCollider bc;

    public FocusObject focus;

    public Transform new_target;


    void resetNumbers() {
        for (int i = 0; i < 5; i++)
            binary[i] = 0;
    }

    public void clickButton(int b) {

        if (!PlayerAction.can_act || complete)
            return;

        if (numbers_input >= 5) {
            resetNumbers();
            text.text = string.Empty;
            numbers_input = 0;
        }

        binary[numbers_input] = b;

        string number = string.Empty;
        numbers_input++;

        for (int i = 0; i < numbers_input; i++)
            number += binary[i].ToString();

        text.text = number;

        if (numbers_input == 5) {
            for (int i = 0; i < 5; i++) {
                if (answer[i] != binary[i])
                    return;
            }
            resolvePuzzle();
        }
    }

    void resolvePuzzle() {
        focus.target = new_target;
        CameraMovement.instance.moveCameraTo(new_target, focus.target_camera_position);
        complete = true;
        animator.Play("OpenDoor");
        bc.enabled = false;
        SoundControl.instance.openDoor();
    }
}
