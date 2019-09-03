using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

public class PlatformTiltService : MonoBehaviour
{
    public StoriesHelper _storiesHelper;

    [SerializeField]
    private float TiltAngleMax = 15f;

    private Vector2 _joystickLeft = Vector2.zero;

    void Start()
    {
        _storiesHelper.Setup(gameObject, OnStoryChange);
    }

    private void OnStoryChange(Story story)
    {
        /* _dataTransformer.BoardMovementReactive.Subscribe(_ => {
                Vector3 projectedForward = Vector3.ProjectOnPlane(_.CameraForward, Vector3.up);
                Vector3 projectedRight = Vector3.ProjectOnPlane(_.CameraRight, Vector3.up);

                transform.rotation = Quaternion.AngleAxis(Joystick2RotationAngle(_.Joystick.x), -1f * projectedForward)
                    * Quaternion.AngleAxis(Joystick2RotationAngle(_.Joystick.y), projectedRight);
            }); */
        
        _joystickLeft = story.Get<XBox360ControllerStory>().JoystickLeft;

        Vector3 projectedForward = Vector3.ProjectOnPlane(Vector3.forward, Vector3.up); // Fake for now
        Vector3 projectedRight = Vector3.ProjectOnPlane(Vector3.right, Vector3.up); // Fake for now

        transform.rotation = Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.x), -1f * projectedForward)
            * Quaternion.AngleAxis(Joystick2RotationAngle(_joystickLeft.y), projectedRight); 
    }

    private float Joystick2RotationAngle(float joystickAxisValue)
    {
        float normal = Mathf.InverseLerp(-1f, 1f, joystickAxisValue);
        float lerped = Mathf.Lerp(-1f * TiltAngleMax, TiltAngleMax, normal);

        return lerped;
    }
}
