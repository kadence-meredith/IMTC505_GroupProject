Yao - UBC confetti button

Open Assets/Scenes/Scene - Yao.unity and press Play.
Click the blue button in Game view to try it without a headset.
In VR, point either controller ray at the blue button and press the trigger.
The button moves down briefly and plays blue and white confetti.
Wait two seconds, then release and press again to replay it.

Setup
- The blue cube has a Box Collider and XR Simple Interactable.
- Select Entered calls CourtyardButton.Press().
- Two Particle Systems make the blue and white confetti.
- The coroutine moves the button down, returns it, and waits before the next press.
- CourtyardMousePreview raycasts from the camera for the desktop preview.
- The scene has a basic XR Origin with tracked camera and two ray controllers.
- XR Interaction Toolkit 3.5.1 and OpenXR 1.18.0 are included.
- OpenXR is configured for Standalone/Android with the Oculus Touch profile.

For group integration, drag Assets/Yao/Prefabs/UBC Confetti Button.prefab
into the shared scene and use the team's XR Origin / Interaction Manager.
Keep just one XR Origin and Main Camera in the combined scene.
This scene has no teleport or movement controls; the button is in front of you.
The shared Build Settings scene list was left as it was. For a device build,
select Scene - Yao in your build scene list, or use the team's combined scene.

Checked in the Unity Editor using mouse clicks and simulated XR controller
input, including holding, releasing, reset and repeat presses.
A real headset/device build still needs testing before submission.
