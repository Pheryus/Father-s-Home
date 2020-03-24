using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : InteragableObject {
    public int id;

    public override void interact() {
        NotepadText.instance.showMessage(id);
    }
}
