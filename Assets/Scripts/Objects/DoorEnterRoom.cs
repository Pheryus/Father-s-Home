using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterRoom : InteragableObject {

    public enum Rooms {living_room, kitchen, bedroom };

    public Rooms room_to_enter;

    public bool open = false;

    public override void interact() {
        if (open) {
            CameraMovement.instance.is_moving = false;
            CameraRoom.instance.updateOutlines(false);
            CameraRoom.instance.changeRoom((int)room_to_enter);
        }
        else {
            DescriptionControl.instance.showMessage(message);
        }
    }

}
