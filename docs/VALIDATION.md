# Documentation review and manual checks

Baseline: `a89913bd20af07e50c9d5c299d943c15f6212a6a`.

## Scope and evidence

README and these notes only. No gameplay, scripts, scenes, settings, packages, assets, build outputs, or saved data changed.

Reviewed serialized question structure, guided steps, quiz storage, game scoring, rocket movement, sequential/drag activities, level/attempt handling, profile indexing, trophies, and reporting code. Checked local documentation links, ten enabled scene paths, and whitespace.

Unity compilation, gameplay, WebGL hosting, device builds, and live services were not tested. This is not a full-history security or asset-rights audit.

## Source observations

- QuestionController indexes nested question/step/answer lists and locates difficulty objects by name. Validate all serialized banks, correct-answer indices, button capacity, and empty/missing content.
- Its completion branch includes a strict `countQuestion > questionlist.Count` check. Test the exact final-question boundary and the win-panel path.
- QuestionController1 reads/removes the first bubble and question entries; several game paths rely on paired hierarchy counts. Check empty lists, repeated contacts, and uneven question/answer children.
- Games3Controller displays attempts out of three but shows failure only when attempts exceed three. Verify the intended limit, final-level handling, and subsequent child accesses.
- DragController expects a configured Canvas and CanvasGroup; it toggles BoxCollider2D during dragging and does not restore the item's position on release. Verify dropped-item behavior, canvas scaling, and interrupted gestures.
- DetailPlayer parses the final character of a profile key as its index. Check ten or more profiles and deletion/selection behavior.
- QuizScore, difficulty-completion flags, and Trophy keys are shared. Inspect profile-switching behavior; reporting totals and quiz/game scores are separate mechanisms, not proven server synchronization.
- Named objects, fixed child indices, audio sources, and singleton startup order are assumed throughout the reviewed paths. Validate scene references and restart transitions.
- Existing WebGL output is retained; do not assume it reflects the current source or works without suitable hosting.

## Manual checklist

1. Import with Unity 2022.3.60f1, inspect compilation/references, and navigate all ten enabled scenes from Start.
2. Review networking in a development setup and use synthetic profiles. Test creation, switching, restart, and deletion with multi-digit profile indices.
3. Have a subject reviewer check serialized maths content. Exercise all difficulty banks, every guided step, wrong/correct responses, score storage, trophies, and exact completion boundaries.
4. Test rocket movement/release, sequential answers, dragging at different canvas scales, attempts, final levels, repeated triggers, and interrupted feedback.
5. Test the intended platform and current WebGL build separately. Review browser persistence, host configuration, asset/audio rights, and network error behavior before distribution.

Source observations above remain unfixed in this documentation-only change.
