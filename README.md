# VR Accident Investigation Scenario

## Overview

This project is a VR-based (PC simulated) accident investigation experience developed in Unity.
The user explores a garage environment, identifies safety hazards, and determines the primary cause of an accident.

The system focuses on interaction, environmental storytelling, and logical decision-making.

---

## Objective

Investigate the garage scene, collect evidence, and identify the correct cause of the accident based on observed clues.

---

## Controls

* **W / A / S / D** → Move
* **Mouse** → Look around
* **Shift** → Sprint
* **Space** → Jump
* **E** → Interact / Inspect evidence

---

## Gameplay Flow

1. Player enters the garage environment
2. Explores the scene using first-person controls
3. Interactable objects are highlighted on hover
4. “Press E to Inspect” appears when looking at evidence
5. On interaction:

   * Evidence is collected
   * A popup displays details about the object
6. Progress is tracked on screen
7. After collecting minimum required evidence:

   * Decision panel is unlocked
8. Player selects the cause of the accident
9. System provides feedback:

   * Correct → Investigation complete
   * Incorrect → Retry allowed

---

## Investigation Design

### Primary Cause

* **Oil Spill on Floor**

  * Creates slip hazard leading to the accident

### Supporting Hazards

* Poor lighting conditions
* Exposed electrical wire
* Improper tool organization
* Safety gear not used

### Additional Objects (Non-Critical Clues)

* Mini fridge
* Radio
* Car battery
* Engine block
* Trashcan
* Tires
* Gas can
* Jack stand

These elements contribute to environmental realism but are not the direct cause.

---

## Features Implemented

* First-person player movement (FPS controller)
* Raycast-based interaction system
* Dynamic object highlighting using emission
* Context-based UI (“Press E to Inspect”)
* Evidence collection and tracking system
* Evidence popup UI
* Decision-making system with retry logic
* Cursor switching between gameplay and UI
* Player movement lock during UI interaction

---

## Interaction System

* Objects use a custom `Interactable` script
* Highlighting supports multiple renderers
* Emission-based visual feedback for clarity
* Prevents duplicate interaction

---

## Progress System

* Displays number of collected evidence
* Prevents early completion
* Unlocks decision phase only after required evidence

---

## Decision System

The player must choose the correct cause of the accident.

* Correct answer completes the investigation
* Incorrect answers show:

  > “This hazard exists, but it was not the direct cause. Try again.”

---

## Tools & Technologies

* Unity (2022.3.x)
* C#
* TextMeshPro
* Built-in Render Pipeline / URP

---

## Demo Video

A 2–3 minute demo video is included showing:

* Scene exploration
* Object interaction
* Evidence collection
* UI system
* Final decision process

---

## Project Structure

* Scripts:

  * FPSController
  * PlayerInteract
  * Interactable
  * GameManager
  * DecisionManager
* UI:

  * Inspect Prompt
  * Evidence Popup
  * Progress Display
  * Decision Panel

---

## Conclusion

This project demonstrates a structured approach to building an interactive investigation system using Unity. It focuses on user interaction, logical reasoning, and clean system design while maintaining performance and usability.

---
