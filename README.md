# VR Exhibition App

## Group Members
- **Sandra HATEM**
- **Alix MOUGEL**

---

## Overview

This project is a VR exhibition app where users can interact with various exhibits and characters. The app includes sound, animations, and interactive elements that respond to the user's controller inputs. The objective is to immerse the user in a virtual environment and let them interact with different objects.

---

## Experiments and Features

### Movement
- To move within the app, **hover** over the circular button of the controller in the direction you want to go.
- **Lift your finger** to stop moving.

### Ambient Sound
- Music and the sound of a crowd play upon launching the application to immerse the user.

### Scene Decorations
- **2 canvases** in the scene have a sprite image attached that represent science posters for decoration.

### Talking Characters
- Some exhibits have a character next to them. 
- **Click the trigger button** on the controller to interact with these characters and hear them explain the exhibits.
- Each character has:
  - Idle animation (breathing)
  - Talking animation (triggered when interacting)
- Animations and characters are imported from **Mixamo**.
  
### Lamp Interaction
- **Point** at the lamp and **press the trigger** to change its light color.
- **Implementation**: This interaction is controlled by a script called `ToggleLight` and the lamp has an `XR Simple Interactable`.

### Donut Interaction
- **Press the trigger** while pointing at a donut to "eat" it:
  - Eating the **pink donut** changes how you view the world.
  - Eating the **red donut** returns your view to normal.
  - You can **click the reset button** in the bottom right corner of the table to make the donuts reappear.
- **Implementation**: 
  - The interaction is managed by the `eatDonut` script and `XR Simple Interactable` on the donuts.
  - The pink donut triggers a transparent pink image on the user's camera, coloring the world pink.
  - The red donut removes this effect.
  - To make donuts disappear, we call the method `SetActive(false)`. A sound plays when the player eats the donuts.

### Lightbulbs Logic Puzzle
- There are **3 lightbulbs** (2 on the left, 1 on the right).
- **Choose a logical connector** (OR, AND, NAND, XOR) using the controller's trigger.
- **Turn the lights** on/off using the trigger to see how different combinations affect the light on the right.
- **Implementation**: 
  - The interaction is managed by the `GateSelector` script.
  - Planes with `XR Simple Interactor` and text attached to canvases act as buttons.
  - The left bulbs have `XR Simple Interactor` to toggle the point light on/off.

### Blocks and Water Experiment
- **Try placing blocks** in the water and see how they react.
- **Use the reset button** in the bottom right corner to reset the blocks to the table.
- **Implementation**: 
  - Managed by the `FloatingObject` script.
  - Cubes have a physical material and `XR Grab Interactable` for grabbing and throwing around the scene.

### Fire Extinguisher
- There is a fire extinguisher in the room that the player can grab and throw around by pressing the trigger button.

### Quit the App
- To exit the app, **point at the door** and press the trigger on the controller.

---

## GitHub Collaboration

As merging Unity projects on GitHub can be challenging, we decided that only one group member would handle pushing the project to GitHub.
