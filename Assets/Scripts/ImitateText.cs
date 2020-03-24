using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImitateText : MonoBehaviour
{
    public Text target, self;

    private void Update() {
        self.text = target.text;
        self.enabled = target.enabled;
    }
}
