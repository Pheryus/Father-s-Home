using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDigitButton : MonoBehaviour {

    public Text[] digits_text;

    int[] digits_values;

    public int[] password;

    public int max_value = 9;

    public bool coordenate = false;

    bool opened = false;

    public Animator animator;

    public Vector3 new_camera_position;

    public DoorEnterRoom door;


    private void Start() {
        digits_values = new int[digits_text.Length];
    }

    public string getCoordenateFromValue(int id) {
        if (id == 0)
            return "N";
        else if (id == 1)
            return "S";
        else if (id == 2)
            return "L";
        else return "O";
    }

    public void clickButton (int id) {

        if (opened || !PlayerAction.can_act)
            return;

        SoundControl.instance.clickButton();
        digits_values[id]++;
        if (digits_values[id] > max_value)
            digits_values[id] = 0;

        if (coordenate) {
            digits_text[id].text = getCoordenateFromValue(digits_values[id]);
        }
        else {
            digits_text[id].text = digits_values[id].ToString();
        }

        bool right_code = true;

        for (int i = 0; i < password.Length; i++){
            if (password[i] != digits_values[i]) { 
                right_code = false;
            }
        }

        if (right_code) {
            completePuzzle();
        }
    }

    void completePuzzle() {
        opened = true;
        if (!coordenate) {
            openBox();
        }
        else {
            openKitchenDoor();
        }
    }

    public void openBox() {
        animator.Play("Open");
        PlayerAction.can_act = false;
        SoundControl.instance.openSomething();
        CameraMovement.instance.moveCameraTo(transform, new_camera_position);
        GetComponent<FocusObject>().target_camera_position = new_camera_position;
        Invoke("enableAction", 1);
    }

    void enableAction() {
        PlayerAction.can_act = true;
    }

    void openKitchenDoor() {
        door.open = true;
        SoundControl.instance.openDoor();
        DescriptionControl.instance.showMessage("Uma porta se abriu.");
        Debug.Log("completou puzzle");
    }
}
