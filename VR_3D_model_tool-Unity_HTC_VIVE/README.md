# VR-3D-model-game-Unity-HTC-VIVE

## Action items:
1. create models
2. open model-editting menu
3. hide model-editting menu
4. move models
5. rotate models
6. change the color of the models
7. re-scale the models

1. Controller.cs负责事件分发（distributes events to），接受场景内的每一个组件的状态消息，状态储存并将这些消息传递出去。包括来自摄像机的gazeon和gazeout凝视事件，来自左右手柄的touch,click,trigger 等事件。
2.  摄像机上绑定了“Raycollider.cs”负责射线发射，并监测碰撞。
3.  调用基本物体的菜单上绑定了“menuitem.cs”负责监测视线，并在视线抵达菜单按键上的时候进行hover反馈，并触发事件，创建物体。
4.  物体上绑定了“modelcontroller.cs”监测视线和手柄点击事件，点击后会触发状态改变 "event on"和菜单改变。
5.  单个物体操作菜单上绑定了“Rulecontroller.cs”菜单,可以对物体进行移动，旋转，变色，放缩操作。
