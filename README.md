

# Runtime Rope System (Unity3D)

This project implements a **3D Runtime Rope System** in Unity using physics-based joints.  
The rope dynamically connects two objects in the scene and responds to physics forces in real-time.

---

## Features
- **Physics-based rope simulation** using `LineRenderer` and `ConfigurableJoint`
- **Dynamic rope generation** at runtime
- **Adjustable rope segment count & length**
- **Supports attaching to moving objects**
- **Real-time collision and bending**

---

## How It Works
The system creates rope segments (small rigidbodies) between two endpoints using joints.  
A `LineRenderer` updates every frame to visually connect the rope segments, producing a realistic rope effect.

---

## Requirements
- Unity 2021 or newer
- Basic knowledge of Unity's physics system

---

## Setup Instructions

1. **Create a new Unity scene**
   - Add two GameObjects to serve as rope endpoints (e.g., `StartPoint` & `EndPoint`).

2. **Import the script**
   - Place `RopeGenerator.cs` into your Unity project’s `Scripts` folder.

3. **Create an empty GameObject**
   - Name it `RopeSystem`
   - Attach the `RopeGenerator` script to it.

4. **Assign References in Inspector**
   - **Start Point** → The object where the rope begins.
   - **End Point** → The object where the rope ends.
   - **Rope Segment Prefab** → A small cylinder or cube with `Rigidbody` and `Collider`.

5. **Adjust Parameters**
   - Rope segment count
   - Rope segment length
   - Physics properties (mass, drag, joint limits)

6. **Play the scene**
   - Press **Play** in Unity to see the rope form and simulate in real-time.

---

## Parameters in `RopeGenerator` Script
| Parameter | Description |
|-----------|-------------|
| `startPoint` | The starting transform for the rope |
| `endPoint` | The ending transform for the rope |
| `segmentCount` | Number of rope segments |
| `segmentLength` | Length of each rope segment |
| `ropeSegmentPrefab` | Prefab used for rope links |
| `lineRenderer` | Component that visually draws the rope |

---

## Demo
![Rope System Demo](Physics-Rope-System/RopeSystem.gif)

## Example Usage
```csharp
public Transform startPoint;
public Transform endPoint;
public int segmentCount = 10;
public float segmentLength = 0.5f;
public GameObject ropeSegmentPrefab;
public LineRenderer lineRenderer;
