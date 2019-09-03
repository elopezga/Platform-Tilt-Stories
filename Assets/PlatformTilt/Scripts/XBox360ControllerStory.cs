using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStories;

[CreateAssetMenu(menuName="Unity Stories/PlatformTilt/Xbox360Controller Story")]
public class XBox360ControllerStory : Story
{
    public Vector2 JoystickLeft = Vector2.zero;
    public Vector2 JoystickRight = Vector2.zero;

    public override void InitStory()
    {
        JoystickLeft = Vector2.zero;
        JoystickRight = Vector2.zero;
    }

    // Actions / Factories
    public class SetJoystickLeft : GenericAction<XBox360ControllerStory, Vector2>
    {
        public override void Action(XBox360ControllerStory story, Vector2 value)
        {
            // Avoids using new Vector3 to not produce garbage
            story.JoystickLeft.x = value.x;
            story.JoystickLeft.y = value.y;
        }
    }
    public static GenericFactory<SetJoystickLeft, XBox360ControllerStory, Vector2> SetJoystickLeftFactory = new GenericFactory<SetJoystickLeft, XBox360ControllerStory, Vector2>();

    public class SetJoystickRight : GenericAction<XBox360ControllerStory, Vector2>
    {
        public override void Action(XBox360ControllerStory story, Vector2 value)
        {
            // Avoids using new Vector3 to not produce garbage
            story.JoystickRight.x = value.x;
            story.JoystickRight.y = value.y;
        }
    }
}
