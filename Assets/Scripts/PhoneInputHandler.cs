using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PhoneInputHandler : InputHandler {
    private bool pressUp = false;

    public Animator anim;

    public void Start () {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.0167f;
    }

    public void PressStart () {
        inputStart ();
    }

    public void PressUse () {
        inputUse ();
    }

    public void PressUp () {
        pressUp = true;
    }

    public void ReleaseUp () {
        pressUp = false;
    }

    public void Update () {
        if (pressUp == true) {
            inputUp ();
        }

        float yaw = Mathf.Asin(-2f * (Input.gyro.attitude.x * Input.gyro.attitude.z - Input.gyro.attitude.w * Input.gyro.attitude.y));

        if (yaw < -0.1f) {
            inputLeft ();
            anim.SetFloat ("Speed", 1f);
        } else if (yaw > 0.1f) {
            inputRight ();
            anim.SetFloat ("Speed", 1f);
        } else {
            anim.SetFloat ("Speed", 0f);
        }
    }
}
