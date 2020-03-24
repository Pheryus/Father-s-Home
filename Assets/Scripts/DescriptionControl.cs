using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionControl : MonoBehaviour {
    public Text description_text;

    bool message_enabled = false;

    float timer = 0;

    float message_duration = 2;

    public static DescriptionControl instance;

    public GameObject message_panel;

    private void Awake() {
        instance = this;
    }

    public void showMessage(string message) {
        message_panel.SetActive(true);
        description_text.text = message;
        description_text.enabled = true;
        message_enabled = true;
        timer = 0;
    }

    public void disableMessage() {
        message_panel.SetActive(false);
        message_enabled = false;
        description_text.text = string.Empty;
        description_text.enabled = false;
        timer = 0;
    }

    void Update() {
        if (message_enabled) {
            timer += Time.deltaTime;
            if (timer >= message_duration) {
                disableMessage();
            }
        }
    }

}
