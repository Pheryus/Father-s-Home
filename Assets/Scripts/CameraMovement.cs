using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour{
    public static CameraMovement instance;

    #region CameraAnimation

    Vector3 target_position, start_position;
    Vector3 start_rotation;

    Transform target;

    public bool is_moving = false;

    public float smooth_speed;

    public float rotation_speed;
    bool rotates = true;

    Vector3 previous_rotation;

    #endregion


    #region PlayerControl
    public float mouse_speed;
    private float X;
    private float Y;
    public bool player_is_moving_camera = false;
    public LayerMask ui_layer;

    #endregion


    float max_x_rotation = 15, min_x_rotation = -15;

    private void Awake() {
        instance = this;
    }

    #region CameraAnimation

    public void saveCamera() {
        start_position = transform.position;
        start_rotation = transform.eulerAngles;
    }

    /// <summary>
    /// Ordena para camera mover para posição original
    /// </summary>
    public void moveCamera() {
        //PlayerInput.instance.can_act = false;
        target_position = start_position;
        is_moving = true;
    }

    public void moveCameraTo (Transform _target, Vector3 _target_position, bool _rotate = true) {
        //PlayerInput.instance.can_act = false;
        target = _target;
        rotates = _rotate;
        target_position = _target_position;
        previous_rotation = transform.eulerAngles;
        is_moving = true;
    }

    private void LateUpdate() {
        if (is_moving) {
            transform.position = Vector3.Lerp(transform.position, target_position, smooth_speed * Time.deltaTime);
            if (rotates)
                transform.LookAt(target);
            else {
                //transform.rotation = Quaternion.identity;
            }

            if (Vector3.Distance(transform.position, target_position) < 0.1f && stopRotate()) {
                is_moving = false;
            }
            else
                previous_rotation = transform.eulerAngles;

        }
    }

    bool stopRotate() {
        return Vector3.Distance(previous_rotation, transform.eulerAngles) < 10;
    }

    #endregion

    #region PlayerControl

    void Update() {
        if (Input.GetMouseButton(1) && !PlayerAction.focus_on_object && PlayerAction.can_act && !PlayerAction.dragging_item) {
            
            if (!EventSystem.current.IsPointerOverGameObject()) {
                
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * mouse_speed, -Input.GetAxis("Mouse X") * mouse_speed, 0));
                X = transform.rotation.eulerAngles.x;
                Y = transform.rotation.eulerAngles.y;

                X = ClampAngle(X, -15, 15);
                transform.rotation = Quaternion.Euler(X, Y, 0);
                player_is_moving_camera = true;
                return;
            }
        }
        
        player_is_moving_camera = false;
    }

    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;

        if (angle > 180)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }


    #endregion
}
