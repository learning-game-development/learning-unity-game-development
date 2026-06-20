# :mortar_board: :video_game: Learn Unity with Jason Weimann

:link: [Jason Weimann](https://www.youtube.com/c/Unity3dCollege) YouTube channel

:heavy_check_mark: Completed  
:o: Incomplete

## :beginner: YouTube Videos

### Beginner Videos

1. :heavy_check_mark: [How to get started with Unity3D - For Beginners](https://www.youtube.com/watch?v=XDAYS-qYe6Y)
2. :heavy_check_mark: [The Best Tips for learning new game dev skills - for unity3d beginners and pros](https://www.youtube.com/watch?v=v7WY_w5B3mc&t=6s)

### Unity Tips Videos

1. :o: [10 Things You Should Know in Unity](https://www.youtube.com/watch?v=XN4tHXvB6D8)
5. :heavy_check_mark: [unity3d mistake YOU don't want to make](https://www.youtube.com/watch?v=rHRjsQOR11w)
6. :heavy_check_mark: [5 ways to make your unity3d code faster](https://www.youtube.com/watch?v=KErkmxbkBs8&t=3s)
7. :heavy_check_mark: [Do these 7 things for EVERY game!](https://www.youtube.com/watch?v=1f4mkY8jUdY)
8. :heavy_check_mark: [6 Useful Unity3D Things (one I just learned!)](https://www.youtube.com/watch?v=KRq0-0KY6bU&t=1s)

### Best Practises Videos

1. :heavy_check_mark: [The advice that MADE ME a BETTER unity3d / c# programmer](https://www.youtube.com/watch?v=Uix9D-J2vQQ)
2. :heavy_check_mark: [Code Smells - 'Switches' in Unity3d / C# Architecture](https://www.youtube.com/watch?v=nqAHJmpWLBg)

## Unity Development Tips

1. [Game Programming for Beginners - LIVE (c#/unity/gamedev)](https://www.youtube.com/watch?v=qtHzLbNxZ0E)

### Unity Editor

- `Ctrl + Shift` then drag object will snap to ground.
- `Shift + v` Vertex Snapping
- `Shift + Space` fullscreen

### Script Meta Data

You can add script meta tags to customize the Unity inspector:

- Insert `[Range(1.0f, 2.0f)]` to get a range slider.
- Use `[Header("Title")]` and `[Space]` to add a title and space between variables.
- `[HideInInspector]` will disable the field in the inspector.
- `[SerializeField]` on private variable will enable the field in the inspector.
- Add toolstips to variables with `[Tooltip("This on inspector")]`.

### Regions in Unity

```csharp
#region Variables
#endregion
```

### Debug Control in Unity

```csharp
#if UNITY_EDITOR // how to disable all logging on release builds
  Debug.unityLogger.logEnabled = true;
#else
  Debug.unityLogger.logEnabled = false;
#endif
```

### Game Programming Patterns

1. [Creating Objects in Unity3D using the Factory Pattern](https://www.youtube.com/watch?v=FGVkio4bnPQ)
   - [Factory Pattern](https://en.wikipedia.org/wiki/Factory_(object-oriented_programming))

## 2D camera shake:
1. Compute shake angle and offset:

```csharp
angle = maxAngle * shake * GetRandomFloatNegOneToOne();
offsetX = maxOffset * shake * GetRandomFloatNegOneToOne();
offsetY = maxOffset * shake * GetRandomFloatNegOneToOne();
```

2. Then add it to the camera for that frame (preserve the base camera)

```csharp
shakyCamera.angle = camera.angle + angle;
shakyCamera.center = camera.center + Vec2(offseX, offsetY);
```
