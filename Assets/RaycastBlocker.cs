using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastBlocker : MonoBehaviour {

    public bool mouse_over = false;

    public void OnPointerEnter() {
        mouse_over = true;
        Debug.Log("enter");
    }

    public void OnPointerExit() {
        mouse_over = false;
        Debug.Log("exit");
    }
}
