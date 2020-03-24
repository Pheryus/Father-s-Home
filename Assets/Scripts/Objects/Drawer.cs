using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : InteragableObject {
    public Animator animator;

    public bool drawer_open;

    public bool can_open_drawer;

    bool animating = false;

    public bool without_knob;

    public GameObject knob;

    public enum drawer_type { Cabinet, Stand};

    public drawer_type type;

    public Items need;

    public bool change_color = false;

    bool normal_color = true;

    public Material new_material;

    public Material default_material;

    public MeshRenderer mesh_renderer;

    public BoxCollider extra_collider;

    public override void interact() {
        if (!PlayerAction.can_act)
            return;

        if (can_open_drawer && !animating)
            drawer_open = !drawer_open;
        else {
            if (ItemControl.instance.getItemSelected() == need) {
                openClosedDrawer();
                return;
            }
            else {
                if (need == Items.knob)
                    DescriptionControl.instance.showMessage("Está faltando uma maçaneta.");
                else 
                    DescriptionControl.instance.showMessage("Trancado.");
                SoundControl.instance.locked();
                return;
            }
        }
        open();
    }

    void openClosedDrawer() {
        animating = true;
        PlayerAction.can_act = false;
        ItemControl.instance.loseItem();
        SoundControl.instance.openSomething();
        can_open_drawer = true;
        if (knob != null)
            knob.SetActive(true);

        if (need == Items.red_key)
            DescriptionControl.instance.showMessage("Abriu.");

        Invoke("endAnimation", 0.3f);
    }

    void open() {
        animating = true;
        PlayerAction.can_act = false;

        if (drawer_open) { 
            animator.Play("OpenDrawer");
            if (extra_collider != null)
                extra_collider.enabled = false;
        }
        else { 
            animator.Play("CloseDrawer");
            if (extra_collider != null)
                extra_collider.enabled = true;
        }

        if (drawer_type.Stand == type) {
            Invoke("endAnimation", 1);
        }
    }

    private void Update() {
        if (!change_color)
            return;

        if (GameControl.instance.color_switch_active && normal_color) {
            mesh_renderer.material = new_material;
            normal_color = false;
        }
        else if (!GameControl.instance.color_switch_active && !normal_color) {
            mesh_renderer.material = default_material;
            normal_color = true;
        }
    }

    public void endAnimation() {
        PlayerAction.can_act = true;
        animating = false;
    }
}
