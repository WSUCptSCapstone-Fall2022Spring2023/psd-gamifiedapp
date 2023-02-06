# Sprint 3 Report (11/09/2022 - 12/09/2022)

Demo Video Link: https://youtu.be/BPIj4paml5w

## What's New (User Facing)

 * Project features graphical, interactive, and content updates for the project
   * Button Interaction: All buttons were given specific hover, selected, and unselected styling based on the button class they were in. These cases include menu, selection, inline, and special.
   * Syntax Highlighting: Specific key words such as conditionals, given variables, and numbers will be displayed in another color
   * Layouts: There was a redesign of the level player layout for better clarity and readability of the given level information
   * Error Handling: If an error is caught from the users code, it will be displayed back to the user. For the most common errors, the team has added scripts that will explain the error and provide possible solutions.
   * Level 1 & 2 Content Extension: The first two levels now include new phases that repeat previously learned topics to help reinforce the material
   * Level 1 & 2 Graphics: The first two level, for each phase in the level, has a diagram of the "system" they are working on for the phase. These diagrams include motion and color convey to the user that they have succeeded or failed the level.



## Work Summary (Developer Facing)

For this sprint we split into two groups at the beginning of the sprint, one that would focus on button styling and layouts and one that would focus on syntax highlighting and error handling. The internal team deadlines for finishing these sections was a week before the conclusion of the sprint. After the work was merged, the team regrouped to focus on visuals for each phase of the first two levels, one team member created the diagrams and the individual internal components of the diagrams and the other member would intake and implement the diagrams with motion and color in the level phases. This sprint, the team faced a challenge when one member fell ill and couldn't help or complete more work for a few days. The team asked for an extension so that they could finish the sprint a few days late. 

## Unfinished Work

There was no unfinished work for this sprint.

## Completed Issues/User Stories

Here are links to the issues that we completed in this sprint:

 * [#45 Content Extension for Main Levels 1 &2](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/45)
 * [#53 Improved UI Feedback](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/53)
 * [#54 UI Layout Refinements](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/54)
 * [#41 MVP Doc Revisions Draft 1](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/41)
 * [#49 Visuals for Main Level 1 & 2](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/issues/49)

 ## Incomplete Issues/User Stories

 There were no incomplete issues or user stories.

## Code Files for Review

Please review the following code files, which were actively developed during this sprint, for quality:

- InitBarcode: Backing code for the "Barcode" widget
- WatchString: Backing code for the UI string display
- ProportionalMeterHandler: Backing code for the proportional meter UI element.
- MeterHandler: Backing code for the numeric meter element.
- WatchNumber: Backing code for the numeric display element.
- NumberLineHandler: Backing code for the number line UI element.
- WatchBoolean: Backing code for the boolean display element.
- DynamicRotate.cs: Rotates a UI element at a variable rate when enabled.
- DynamicProgression: When enabled, transitions through a progression of multiple images.
- DynamicFlickerTransition: When enabled, flicker from one image to another.
- DynamicColorFlicker: When enabled, flicker an element from it's current color to another color.

*Temporary scripts and behaviors made only for UI testing and demo purposes are ommitted for brevity, and since they'll be deleted once they are no longer useful*

## Retrospective Summary

Here's what went well:

  * Last sprint, we wanted to communicate more about over arching systems and will come to a rough implementation idea before work on it begins. This sprint, we had great luck with this goal. before the beginning of sections were the team would split into two groups we met and discussed the vision and requirements we wanted to achieve. 
  * Last sprint, we mentioned wanting to meet with Mr. Davis more often. However, after meeting with him and discussing this we can to the conclusion that instead, we should continue meeting every two weeks during sole development but have more frequent check-in with him during the play testing phase.
  * The team did a good job continuing to work on the sprint, even while one member was unable to help work for a few days due to an illness.

Here's what we'd like to improve:

   * We were too ambitious in our planning of what we can accomplish in a sprint. 
   * We also would like to improve our workflow of importing art designs for levels.

Here are changes we plan to implement in the next sprint:

   * In the future, the team will have contingency plans for work in the case of illness for one or more of the team.
   * In the future, the team will experiment with exporting the art assets not as a series of png files but potentially a photoshop or a zipped file.
