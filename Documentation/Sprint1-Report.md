# Sprint 1 Report (8/26/21 - 10/9/2021)

## What's New (User Facing)
 * Project features test UI allowing you to write and simulate basic Python code and view the state of the python variable "testVar" during simulation.
 * Simulation ends in success if testVar is forced below -20, and ends in failure if testVar is allowed to become higher than 20.
 * Documents folder contains Introductions, Project Overview, Requirements and Specifications, and a Solutions Approach Document.

## Work Summary (Developer Facing)
During this sprint, we spent most of our time to try to produce most of the project's documentation and planning, as well as setting up the github repo with most of the major issues for the entire project. We did however reserve time to complete the integration of IronPython into the game, since it is such an integral component of the project and is so central to future development. Setting up the Unity project required a few learning experiences. It was more difficult than anticipated to get the IronPython package integrated into Unity, and required a lot of research into how to directly import the IronPython package and its dependencies into the plugins folder. In addition, we ran into a serious issue with our gitignore, which wasn't ignoring the files it was supposed to and was leaving thousands of unintended files in the project. This was slowing down our git operations and causing the github UI to lag and we were forced to merge an emergency fix into one of our pull requests. Other than that, this sprint was mostly a challenge in organizing our time, and remaining up to date on all of the documentation that was required while also working on the foundation of some of our foundational project setup and code. 

## Unfinished Work
In this sprint, we managed to achieve all of the issues that we set out to close, delivering most of the project's documentation as well as completing the Core IronPython integration that we aimed to achieve. There was no unfinished work.

## Completed Issues/User Stories
Here are links to the issues that we completed in this sprint:

 * [#18: Fix Gitignore](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/18)
 * [#4: Core IronPython Integration](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/4)
 * [#1: Produce Solutions Approach Document](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/1)
 * [#2: Produce Sprint Report Document](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/2)
 * [#3: Update README to Meet Requirements](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/3)
 
 ## Incomplete Issues/User Stories
 Here are links to issues we worked on but did not complete in this sprint:

	N/A

## Code Files for Review
Please review the following code files, which were actively developed during this sprint, for quality:
 * [IronPythonContainer.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/IronPythonIntegration/IronPythonContainer.cs)
 * [LevelDefinition.cs](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Icarus%20Protocol/Assets/Levels/LevelDefinition.cs	)
 * [Solution_Approach_Document.pdf](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Documentation/Solution_Approach_Document.pdf)
 * [Requirements_and_Specifications.pdf](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Documentation/Requirements_and_Specifications.pdf)
 * [IcarusProtocol_Project_Report.pdf](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/main/Documentation/IcarusProtocol_Project_Report.pdf)
 * *Temporary scripts and behaviors made only for UI testing and demo purposes are ommitted for brevity, and since they'll be deleted once they are no longer useful*

## Retrospective Summary
Here's what went well:
  * We did a good job getting the work divided between us and completed successfully given a team of only two people to work on it.
  * We did a good job on communication, and developing between ourselves a very clear idea of what the finished project will look like and how it will function.
  * We are currently very happy with the state of our code documentation. This includes feeling good about the various design docs we've produced, as well as being satisfied with the thoroughness of the comments and explanations of the implemented code.
 
Here's what we'd like to improve:
   * We made a few mistakes throughout this sprint in our git management (the .gitignore being wrong initially for instance), as well as one teammate branching without remembering to pull, which could have caused problems, but luckily didn't this time. 
   * There were initially some misconceptions about what certain sections of documentation entailed, which led to the need to redo work, spending extra time in doing so.
   * We did not make ourselves aware early enough about the requirements of the sprint rubric (i.e. before/after videos) and were caught off guard by these requirements, leading to a stressful crunch week before the due date.
  
Here are changes we plan to implement in the next sprint:
   * We've reviewed git protocol between us, and will endeavor to be careful when branching, pulling, and pushing, to ensure the cleanliness and usefulness of git functionality.
   * When tackling future documentation, we intend to perform an overview before beginning work, ensuring that both of us are on the same page about exactly what each section entails.
   * We intend to evaluate the workload posed by each task well in advance of the week in which it is due, ensuring that there are no more unpleasant surprises about what work we need to accomplish.