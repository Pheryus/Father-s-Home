using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput instance;

    public InterfaceControl interface_control;

    public LayerMask message_layer;
    Vector3 last_mouse_position;

    bool mouse_is_moving = false;

    FocusObject object_hacked;

    public CameraMovement camera_movement;


    public Ray mouse_ray;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        last_mouse_position = Input.mousePosition;
    }

    void clickToFocus () {
        RaycastHit hit;
        if (Physics.Raycast(mouse_ray, out hit)) {
            if (hit.transform.tag == "ClickableObject" && !PlayerAction.focus_on_object) {
                GameControl.instance.interactWithObject(hit.transform);
            }
        }
    }

    void clickMessage() {
        InGameMessages.instance.changeMessage();
    }

    void hackClick() {
        RaycastHit hit;
        
        if (Physics.Raycast(mouse_ray, out hit)) {
            FocusObject obj = hit.collider.GetComponent<FocusObject>();
            if (obj != null) { 
                obj.hackObject();
                object_hacked = obj;
            }
        }
    }

    /// <summary>
    /// Identifica se o usuário clicou em um objeto que se pode interagir.
    /// </summary>
    void clickToInteract() {
        RaycastHit hit;
        if (Physics.Raycast(mouse_ray, out hit)) {
            if (hit.transform.tag == "InteragableObject") {
                hit.transform.GetComponent<InteragableObject>().interact();
            }
            else if (hit.transform.tag == "ClickableObject") {
                InteragableObject obj = hit.transform.GetComponent<InteragableObject>();
                if (obj != null)
                    obj.interact();
            }
        }
    }

    bool clickOnNote() {
        RaycastHit hit;
        
        if (Physics.Raycast(mouse_ray, out hit)) {
            if (hit.collider.tag == "Note") {
                hit.collider.GetComponent<Note>().interact();
                return true;
            }
        }
        return false;
    }

    void checkEndHack() {
        if (mouse_is_moving && camera_movement.player_is_moving_camera && object_hacked != null) {
            object_hacked.endHack();
        }
    }

    bool isPointerOverUIObject() {
        PointerEventData event_data = new PointerEventData(EventSystem.current);
        event_data.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(event_data, results);
        return results.Count > 0;
    }

    void Update(){
    
        mouse_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!PlayerAction.can_act && PlayerAction.reading_note && Input.GetMouseButtonDown(0)) {
            NotepadText.instance.closeText();
            return;
        }
        else if (PlayerAction.reading_note)
            return;

        if (PlayerAction.on_talk && Input.GetMouseButtonDown(0)) {
            clickMessage();
        }

        if (!PlayerAction.can_act)
            return;


        if (Input.GetMouseButtonDown(1))
            mouse_is_moving = false;

        if (Vector3.Distance(Input.mousePosition, last_mouse_position) > 0.3f)
            mouse_is_moving = true;

        if (Input.GetMouseButtonDown(0) && clickOnNote()) {
            return;            
        }

        checkEndHack();

        if (Input.GetMouseButtonDown(0) && !isPointerOverUIObject()) { 
            if (!PlayerAction.focus_on_object)
                clickToFocus();
            else
                clickToInteract();
        }

        if (Input.GetMouseButtonUp(1) && !mouse_is_moving)
            hackClick();

        last_mouse_position = Input.mousePosition;

    }
}
