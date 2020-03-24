using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoom : MonoBehaviour {

    /// <summary>
    /// Posição inicial de cada camera
    /// </summary>
    public Transform[] camera_rooms;

    public Transform[] rooms;

    public static CameraRoom instance;

    int room = 0;

    private void Awake() {
        instance = this;
        enableRoom();
    }

    public void updateOutlines(bool active) {
        Transform t = rooms[room];
        iterateThroughAll(t, active);
    }

    public void iterateThroughAll(Transform root, bool active) {
        foreach (Transform t in root) {
            cakeslice.Outline outline = root.GetComponent<cakeslice.Outline>();
            if (outline != null)
                outline.eraseRenderer = !active;
            iterateThroughAll(t, active);
        }
    }

    void enableRoom() {
        for (int i = 0; i < rooms.Length; i++)
            rooms[i].gameObject.SetActive(false);

        rooms[room].gameObject.SetActive(true);
    }

    public void changeRoom(int id) {
        transform.position = camera_rooms[id].position;
        transform.rotation = camera_rooms[id].rotation;
        room = id;
        updateOutlines(true);

        enableRoom();
        
        InterfaceControl.instance.exitFocusMode();
    }

}
