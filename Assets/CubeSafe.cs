using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSafe : MonoBehaviour
{
    public GameObject top;

    public bool resolve = false;

    public ColorSafe color_safe;

    private void Update() {
        if (!resolve && color_safe.complete) {
            Destroy(top);
            resolve = true;
        }
    }
}
