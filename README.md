# App Matematik

A Unity maths-learning prototype with Malay instructional prompts, guided question steps, quiz scoring, three game scenes, and trophy feedback. It combines structured problem-solving with interactive activities and local player profiles.

## Learning and game features

- Guided question stages: identify given information, choose an operation, solve, check, and answer.
- Difficulty/completion flags for Mudah, Sederhana, Sukar, and Cabaran.
- Learning, quiz, games, and trophy scenes connected through the project UI.
- Game scripts include a controllable 2D rocket with question bubbles, sequential answer activities, and draggable UI items.
- Score and trophy state stored with PlayerPrefs; local player-name/profile flows are included.

These features are described from source inspection. Question content and UI wiring are serialized in scenes; this review did not verify curriculum completeness, mathematical correctness, gameplay, or device compatibility.

## Open the project

1. Clone the repository and install **Unity 2022.3.60f1**, matching [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt).
2. Add the repository root in Unity Hub and allow asset import/package resolution to finish.
3. Open [Start](Assets/Scenes/Start.unity). Before entering Play mode, review the backend path below and use synthetic profiles in a development setup.
4. Exercise the menu, learning/quiz flows, and each game scene.

The [manifest](Packages/manifest.json) includes URP 14.0.12, TextMesh Pro 3.0.7, Unity UI 1.0.0, and Unity's 2D feature package. [Build settings](ProjectSettings/EditorBuildSettings.asset) enable ten scenes: Start, MainMenu, Quiz, TrophyScene, Belajar, belajar1, Games, and game1–3. The repository also contains an existing WebGL output directory; its freshness and browser behavior were not checked.

## Code guide

| Area | Source |
| --- | --- |
| Serialized question/answer structure | [QuestionList](Assets/QuestionList.cs) |
| Guided steps, answer buttons, and feedback | [QuestionController](Assets/QuestionController.cs) |
| Rocket control | [PlayerControl](Assets/PlayerControl.cs) |
| Sequential game answers | [Games2Controller](Assets/Games2Controller.cs) |
| Level/attempt handling | [Games3Controller](Assets/Games3Controller.cs) |
| UI dragging | [DragController](Assets/DragController.cs) |
| Profile setup and reporting | [GameStartupController](Assets/GameStartupController.cs) |

## Saved data and networking

Profiles use local PlayerPrefs. Some quiz, difficulty, and trophy keys are shared rather than scoped to the selected player, so do not assume completely separate progress for each profile.

GameStartupController contains score-reporting code that posts player name, player ID, star totals, and round totals to `app-hanana.com/appmatematik/insertmark.php`. Server source is not included; availability, authorization, and synchronization were not tested. No backend requests were made during this review. Inspect the networking flow before using real learner data.

## Status and reuse

See [validation notes](docs/VALIDATION.md) for source observations and manual checks. This documentation change preserves scripts, scenes, assets, existing outputs, and saved data. No new license is assigned; review included asset/audio permissions before redistribution.
