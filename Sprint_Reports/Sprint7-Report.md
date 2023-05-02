# Sprint 7 Report (4/02/2023 - 5/02/2023)

Demo Video Link: https://youtu.be/L9rcCdaCeHw

## What's New (User Facing)

The main focus of the sprint was the refinement of the UI and content for the challenge levels, review and modification based on the results of the play test with Pullman School District, and the addition of a cut-scene system. 

The challenge levels have the diagrams created for the sole phase and their content has been refined to be more clear for the user.

There were several modifications to the script of the first few levels based on player feedback that we observed during the play testing session. 

The team also added a cut-scene system, where there are three main cut-scenes: Introduction, Mini-Boss, Post-Boss. The introduction cut-scene introduces the player to who they are in the game, Icarus, what has happened and what they will need to do. The Mini-Boss cut-scene introduces the villain Daedalus, whom the player will need to remove from the system. The Post-Boss cut-scene provides an outro to the game post the defeat of Daedalus. 

## Work Summary (Developer Facing)

Similar to the previous sprints, the team split into two groups, one to tackle art creation and the other to work on content extension and modification. The idea is that since content extension must occur before art creation and art creation must occur before art implementation, the team would create a streamline process of content extension to art creation to art implementation. This philosophy extends to cut-scene creation and implementation.

## Unfinished Work

- There was no unfinished work for this sprint.

## Completed Issues/User Stories

Here are links to the issues that we completed in this sprint:

 * [#44 MVP Report Final Revisions](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/44)
 * [#52 Visuals for Challenge Levels](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/52)
 * [#58 Intro Cutscene](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/58)
 * [#59 Plot/Story Delivery Mechanics](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/59)

 ## Incomplete Issues/User Stories

- There was no unfinished work for this sprint.

## Code Files for Review

Please review the following code files, which were actively developed during this sprint, for quality:

- ListDisplayBehavior.cs: controls the behavior of displaying a list in a phase UI element
- CutsceneAppendText: A modular cutscene action that appends text to the main writer
- CutsceneChangeTextColor: A modular cutscene action that changes the color of the main writer
- CutsceneChangeTextSpeed: A modular cutscene action that changes the speed of the text writer
- CutsceneChangeWriteMode: A modular cutscene action that can alter the text writer from print-by-line mode to character print mode.
- CutsceneClearText: A modular cutscene action that clears the text in the main window
- CutsceneFadeElement: A modular cutscene action that can fade in an image element
- CutsceneController: The main file that controls and manages the playing and timing of cutscenes
- CutsceneData: A file that represents the series of actions and timings belonging to a single cutscene
- LevelPlayerController: Changed to trigger cutscenes at the end of phases that identify a cutscene to play
- StartButtonBehavior: Changed to trigger the intro cutscene when pressed
- PhaseDefinition: Changed to allow phases to record a cutscene to play when the phase ends.
- SequentialTyper: Changed to allow it to print by line, as well as to allow code to append text without replacing the text already in the typing window.
- UILayoutHandler: Changed to open and close the new cutscene UI

*Temporary scripts and behaviors made only for UI testing and demo purposes are omitted for brevity, and since they'll be deleted once they are no longer useful. Additionally, files that contain art assets have been omitted.* 

## Retrospective Summary

Here's what went well:

  * The team did a great job addressing concerns and issues raised during the play testing session and incorporating the results into the game to enhance the player experience. 
  * The team did a good job continuing to work on the sprint, prioritizing work on it despite additional work from other classes in preparation for finals in other classes and class presentation.
  * Additionally, the team did a good job meeting the expectations set by the stakeholders for each semester that the team has been working on the Icarus Protocol.

While the team believe there is always room for improvement, they have decided to omit the following sections due to this being the final sprint report.
