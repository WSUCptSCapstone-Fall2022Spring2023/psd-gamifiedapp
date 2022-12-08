# Sprint 3 Report (11/09/2022 - 12/09/2022)

## What's New (User Facing)

 * Project features three new UI pages for the user to interact with: Starting page, Pause page, and Manual pages.
   * The Starting pages give the user the option of starting a new game, continuing a previous game or quitting the game.
   * The Pause page gives the user two options: save game or return to starting page. However, if the user is in a level there will be a third option provided: return to level select.
   * The Manual is an overlay that allows the user to see descriptions and examples of python documentation for certain topics. These topics can be locked behind the completion of a level.

 * Project features completed levels: Main, Challenge, and Boss. Each level has three to nine phases for the user to complete in order for the whole level to be counted as finished.
   * Main levels are an introduction to a coding idea (Statements, Loops, Arrays) themed around fixing a Spaceship functionality (Life Support, Navigation). 
   * Challenge Levels will provide the user an opportunity to solve a coding challenge that incorporates multiples skills learned from Main levels. These level are also themed around fixing the ship, but for more auxiliary systems.
   * Boss Levels prompt the user to learning debugging skills through the systems being sabotaged by the game's antagonist, Daedalus.    


## Work Summary (Developer Facing)

For this sprint, the team was split into two groups that tackled varied tasks. One team member worked on the creation, testing, and implementation of main, challenge, and boss levels for the player, while the other focused on the creation, testing, and integration of new UI layout pages for the player to interact with. The levels required the script for the player AI to say, the starter code for the player, and backend unit tests for the player code in order to give the player feedback based on the outcome of their code, success or failure. The addition of new page layouts required the UI layouts and components to be created, behavior defined, and integrated into pre-existing layout transition handler. There wasn't much difficulty for the team to implement these tasks as the framework and skills required were established in the last sprint. However, a difficulty the team faced this semester was merge conflicts. Using a divide and conquer technique required team members to be working a branch concurrently with other team members. This lead to merge conflicts that had to be handled during the PR phase for addressing an Issue.

## Unfinished Work

If applicable, explain the work you did not finish in this sprint. For issues/user stories in the current sprint that have not been closed, (a) any progress toward completion of the issues has been clearly tracked (by checking the checkboxes of  acceptance criteria), (b) a comment has been added to the issue to explain why the issue could not be completed (e.g., "we ran out of time" or "we did not anticipate it would be so much work"), and (c) the issue is added to a subsequent sprint, so that it can be addressed later.

There were two issues that the team didn't complete this sprint: [#17 Cloud Save and Load](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/17) and [#10 IDE Syntax Highlighting](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/10).

- Cloud Save and Load
  - The team and client have discussed and determined to postpone this issue until more information about it's addition has been established. Some concerns expressed were the additional dependency on an external cloud hosting service, the complexity on the player-side for both having a google account and authenticating before being able to play, and the dependence the player has for a stable internet connection. Given the concerns and that this issues is a low-priority stretch goal, the team has decided to postpone work on it, until the decision to keep or discard the issue has been made.
- IDE Syntax Highlighting
  - After an internal discussion with the team and the client, it was decided that this issue is most similar to the work intended for the second semester of this class (CPTS 422). One of the team's goals for semester two is to add graphical polish such UI transitions and animations, which the team feels this issue falls under. The team intends to complete this issues at a later date.

## Completed Issues/User Stories

Here are links to the issues that we completed in this sprint:

 * [#32 Menus](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/32)
 * [#15 Challenge Levels](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/15)
 * [#14 Boss Levels](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/14)
 * [#13 Main Levels](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/13)
 * [#12 Accessible In-Game Python Documentation](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/12)
 * [#8 Produce Sprint Report Document](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/8)
 * [#7 Compile Prototype Project Report](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/7)

 ## Incomplete Issues/User Stories

 Here are links to issues we worked on but did not complete in this sprint:

 * [#10 IDE Syntax Highlighting](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/10) <It was decided that this issue aligned more with the goals of this project during semester two.>
 * [#17 Cloud Save and Load](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/17) <It was decided that this issue added too many dependencies and complexities for the user to justify adding this feature.>

## Code Files for Review

Please review the following code files, which were actively developed during this sprint, for quality:

 * [Prototype Project Report.pdf](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Documentation/Prototype%20Project%20Report.pdf)

Manual

 * [ManualButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/Manual/ManualButtonBehavior.cs)
 * [ManualDescription.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/Manual/ManualDescription.cs)
 * [ManualDescriptionBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/Manual/ManualDescriptionBehavior.cs)
 * [ManualListController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/Manual/ManualListController.cs)
 * [OverlayManualButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/OverlayMenus/OverlayManualButtonBehavior.cs)

Starting Page

- [LoadButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/StartMenu/LoadButtonBehavior.cs)
- [QuitButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/StartMenu/QuitButtonBehavior.cs)
- [SaveButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/StartMenu/StartButtonBehavior.cs)

Pause Page

- [PauseMenuController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/PauseMenu/PauseMenuController.cs)
- [QuitToStartMenuButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/PauseMenu/QuitToStartMenuButtonBehavior.cs)
- [ReturnButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/PauseMenu/ReturnButtonBehavior.cs)
- [SaveButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/PauseMenu/SaveButtonBehavior.cs)

EscapeListener

- [EscapeListener.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/EscapeMenu/EscapeListener.cs)

UI Layout Handler

- [UILayoutHandler.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/UILayoutHandler.cs)

Level Player

- [LevelPlayerController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/LevelPlayerController.cs)
- [OutputController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/OutputController.cs)

*Temporary scripts and behaviors made only for UI testing and demo purposes are ommitted for brevity, and since they'll be deleted once they are no longer useful*

## Retrospective Summary

Here's what went well:

  * Last sprint, we wanted to be more active and cognizant of the state of issues in the Kanban board. The team was able to reach this goal during this sprint, making sure to move all issues to the Current Sprint category, moving them to In Progress when the team was working on them, and making sure that the issue was under the Under Review during the PR stage.
  * The team did a good job estimating the time each task would take and allocating a team member to finish that issue in the estimated time.
  * The team also did a good job managing merge conflicts and preserving progress made in the Unity main scene upon merge. 

Here's what we'd like to improve:

   * The team noticed there was some internal component functionality misunderstanding regarding overlay settings and the pause menu. While the team was able to sort the misunderstanding out, there was code that needed to be reworked and time that was lost.

Here are changes we plan to implement in the next sprint:

   * In the future, the team will communicate more about over arching systems and will come to a rough implementation idea before work on it begins.
   * For the next semester, since we will be working more closely with Mr. Davis, our client, in regards to play testing with Lincoln Middle School students, we plan on meeting weekly to discuss the project and student testing.