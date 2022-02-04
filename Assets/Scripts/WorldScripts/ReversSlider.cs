using UnityEngine;

public class ReversSlider : MonoBehaviour
{
    private Rigidbody2D platform;
    private SliderJoint2D slider;
    private Vector2 lastPos;

    void Start()
    {
        platform = GetComponent<Rigidbody2D>();
        slider = GetComponent<SliderJoint2D>();
    }

    void Update()
    {
        if(platform.velocity == Vector2.zero && Vector2.Distance(platform.position, lastPos) > 1)
        {
            JointMotor2D motor = slider.motor;
            motor.motorSpeed *= -1;
            slider.motor = motor;
            lastPos = platform.position;
        }
    }
}