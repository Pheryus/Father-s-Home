using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InteragableObject {
   
    public enum SwitchType { light, color};

    public SwitchType type;

    public Light ambient_light, switch_light;

    bool first_time = true;

    public bool turned_on = false;

    public MeshRenderer mesh_renderer;

    public Material new_material, default_material;

    public GameObject binary_code;

    public override void interact() {
        if (!PlayerAction.can_act)
            return;

        SoundControl.instance.clickButton();
        if (type == SwitchType.light) {
            clickLight();
        }
        else if (type == SwitchType.color)
            clickColor();
    }

    public void clickColor() {

        if (first_time)
            DescriptionControl.instance.showMessage("Algo fez barulho na sala.");

        first_time = false;
        turned_on = !turned_on;
        mesh_renderer.material = turned_on ? new_material : default_material;
        GameControl.instance.color_switch_active = turned_on;
    }

    void clickLight() {
        turned_on = !turned_on;
        switch_light.enabled = !turned_on;
        binary_code.SetActive(!turned_on);

        if (turned_on) 
            ambient_light.range = 220.3f;
        else
            ambient_light.range = 1f;
    }

}
