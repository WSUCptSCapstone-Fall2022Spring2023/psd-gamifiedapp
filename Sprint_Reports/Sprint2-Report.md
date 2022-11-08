# Sprint 2 Report (10/9/2022 - 11/9/2022)

## What's New (User Facing)
 * Project features two main UI pages: the level select pages, which allows the user to view and select available levels, and a level page, which displays and allows the user to play the current phase. 
 * The level select page provides a description of the user selected level as well as the current phase progress for the level.
 * The user can choose to replay a phase within a level.
 * Within the level, the user can complete a phase then see a success or failure notification
 * On a successful phase completion, if there is another available phase, the user will be directed to the next level phase.
 * Documents folder contains Introductions, Project Overview, Requirements and Specifications, Solutions Approach Document, and a Testing and User Acceptance Document.
 * All progress through phases is autosaved to a file that is loaded on launch.

## Work Summary (Developer Facing)
During this sprint we spent the main bulk of our time creating the UI components and scripts for the main gameplay loop. The team created UI layouts for the level select page and level phases based on the initial designs illustrated in the Solutions Approach Document. There were three main areas of challenge for the team for this sprint: Unity skills, UI integration, Unity-Json serialization, and Unity component initialization order. One team member had to be given a quick introductory course from another member in how to use the strengths of the Unity Engine. Additionally, by the nature of using Git version control with the Unity Engine, the team had to shift the nature of how game objects would be saved, given conflicting objects in the main scene will be overridden in the case of a merge. Another challenge that required learning experiences, was finding a method of conversion of Unity objects to a json objects. Finally, the team was challenged by default order of component initialization order of the Unity Engine. The team used a combination of techniques including moving initialization logic into a separate user defined script and using event handlers to initialize dependency chains. For this sprint, time management was a priority that the team addressed early, which has lead to a consistent and low pressured sprint work period. 

## Unfinished Work
In this sprint, we managed to achieve all of the issues that we set out to close, delivering most of the project's documentation as well as completing the core UI layouts and functionality that we aimed to achieve. There was no unfinished work.

## Completed Issues/User Stories
Here are links to the issues that we completed in this sprint:

 * [#9: Functional Python IDE](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/9)
 * [#11: Level Select ](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/11)
 * [#16: Saving and Loading](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/16)
 * [#23: Produce Testing and Acceptance Plan Document](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/23)
 * [#24: Create Level Player UI](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/24)
 * [#27: Integrate Sprint 2 UI ](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/27)

 ## Incomplete Issues/User Stories
 Here are links to issues we worked on but did not complete in this sprint:

	N/A

## Code Files for Review
Please review the following code files, which were actively developed during this sprint, for quality:
 * [ContinueButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelSelect/ContinueButtonBehavior.cs)
 * [DescriptionBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelSelect/DescriptionBehavior.cs)
 * [LevelButtonBehavior.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelSelect/LevelButtonBehavior.cs)
 * [LevelDescription.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/Levels/LevelDescription.cs)
 * [LevelListController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelSelect/LevelListController.cs)
 * [IDEController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/IDEController.cs)
 * [LevelPlayerController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/LevelPlayerController.cs)
 * [IronPythonContainer.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/IronPythonIntegration/IronPythonContainer.cs)
 * [OutputController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/OutputController.cs)
 * [PhaseUIController.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/PhaseUIController.cs)
 * [SimulateButtonScript.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelPlayer/SimulateButtonScript.cs)
 * [SelfDisable.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/UICommon/SelfDisable.cs)
 * [SequentialTyper.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/UICommon/SequentialTyper.cs)
 * [PhaseDefinition.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/Levels/PhaseDefinition.cs)
 * [CRTShader.shader](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/PostProcessing/CRTShader.shader)
 * [Progress Record](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/Levels/ProgressRecord.cs)
 * [SaveAndLoad.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/SaveAndLoad/SaveAndLoad.cs)
 * [EscapeListener.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/EscapeMenu/EscapeListener.cs)
 * [CheckboxBuilder.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/UI/LevelSelect/CheckboxBuilder.cs)

 * [Project_Testing_and_Acceptance_Plan.pdf](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Documentation/Project_Testing_and_Acceptance_Plan.pdf)

   *Temporary scripts and behaviors made only for UI testing and demo purposes are ommitted for brevity, and since they'll be deleted once they are no longer useful*

## Retrospective Summary
Here's what went well:

  *  Last sprint, we wanted to evaluate the workload posed by each task well in advance, and we were able to implement this change successfully, doing a good job prioritizing and implementing better time management for the team during this sprint
  *  Last sprint, we wanted to create an internal git protocol system for the team. We were able to discuss and agree to a git protocol that covers branch, pull request, and issue naming conventions as well as pull request (and subsequently merging) requirements.
  * We did a good job of following agreed upon code conventions, structure, and documentation throughout the codebase.

Here's what we'd like to improve:

   *  We found that we would often forget to move issues on the Kanban board to the In Progress Category while we were actively working on them.
   *  We air more on the conservative side for time allocated for each issues in this sprint, leading to potential time we could have had for taking on more issues that were initially dedicated to the next sprint. 

Here are changes we plan to implement in the next sprint:
   *  When beginning work on a new issue, we will create a new branch and move the issue into the In Progress section of the Kanban Board.
   *  For future sprints, we plan to evaluate the workload in regards to each issue and allocate issues to a sprint according to the time in the sprint and the estimated time for the issue.
