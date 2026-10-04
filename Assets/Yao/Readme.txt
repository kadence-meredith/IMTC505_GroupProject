fire alarm

Open Assets/Scenes/Scene - Yao.unity and press Play.
Click the red button in Game view to start the alarm.
Click again to stop it. In VR, aim either controller ray and press the trigger.
The button moves down briefly and then returns to its original position.
The alarm starts silent and stops when the button is disabled or Play mode ends.

Setup
- The red cube has a Box Collider, XR Simple Interactable and FireAlarm script.
- Select Entered calls FireAlarm.Press().
- An AudioSource loops a simple generated two-tone alarm clip.
- Play On Awake is off, volume is 0.45 and the sound is spatial.
- A short coroutine moves the button down and back over 0.25 seconds.
- CourtyardMousePreview lets the same button work with a mouse for testing.

The latest main was merged into yao-dev. The team's XR settings and Android
build profile are kept, with XR Interaction Toolkit added for the button.
For group integration, drag Assets/Yao/Prefabs/fire alarm.prefab into the shared
scene and use one XR Origin / Interaction Manager and one Main Camera.
The shared build scene list is unchanged. Select Scene - Yao or the combined
team scene when preparing a device build.

Editor preview and simulated controller tests cover alarm start/stop,
looping, held trigger, repeat presses and button reset.
A real headset/device build still needs testing before submission.
