using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteragableObject : MonoBehaviour {
    public string message;

    public virtual void interact() {
        DescriptionControl.instance.showMessage(message);
    }
}
