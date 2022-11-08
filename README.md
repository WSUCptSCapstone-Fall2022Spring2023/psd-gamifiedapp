WSU Computer Science Capstone Project
=====================================

PSD Lincoln Middle School Gamified App
---------------------------------------

### Project Description

Icarus Protocol is a fun and engaging science fiction game designed to introduce students at a middle school or early high school level with no prior coding experience to the world of Python programming. It does this through a series of interactive and visually distinct levels that test and challenge basic programming principles while weaving in aspects of game design to heighten knowledge retention and student interest.

### Additional Information

In 2021, the games industry reported estimated revenues of about 198.40 billion dollars, solidly positioning themselves as one of the world’s most immensely popular and valuable forms of entertainment. This growth is only projected to continue rising as well, with market research firms anticipating revenues as high as 339.95 billion by 2027 (Gaming market size, share: 2022 - 27: Industry growth 2021). The power of games to capture the minds and attentions of players across the world cannot be discounted, and given this power, there is also incredible potential for games to capture the attention of players and direct it towards learning and personal advancement as well as towards entertainment.

There is a powerful overlap between games and education, an overlap that innovators have only recently begun to truly explore. The feedback loops and reward models designed and honed to keep people engaged in modes of entertainment can be useful for intriguing students in classwork with a reputation for being uninteresting. Our team aims to explore the potential of games as a tool for education by producing a fully featured game designed to teach basic programming skills to students at a middle school or early high school level with no prior programming experience. While games of a similar nature exist, they often fall into one of two traps which our team sees as pitfalls. Some, while employing the surface level appearance of a game, fail to truly embody the game design principles that make games powerful for learning; Others use a proprietary scripting language that has lessened impact in teaching actionable programming skills. In the construction of this project (working title: “Icarus Protocol”) we aim to solve this problem by producing a game that is a genuinely fun and interesting experience, while also serving as an effective tool for teaching real Python programming.

## Installation

Given the nature of the Icarus Protocol project, there will be two installation guides, a developer oriented and a player oriented. The main differences is that for the player oriented option there will only be the executable for the game.

### Prerequisites

##### Developer:

A developer will need

- Unity 2022 v.1.18
  - When installing Unity, ensure that Windows(IL2cpp) package is included in installation so that the project will be able to build.
- Visual Studio 2022

##### Player:

No prerequisites needed

### Add-Ons

There are no add-ons for either the developer or player.

### Installation Steps

##### Developer:

1. Clone the project
2. Open the file MainScene.unity located in psd-gamifiedapp/Icarus Protocol/Assets/Scenes/

##### Player:

1. Navigate to the Releases page (a link is found on the code tab in github)
2. Download the newest Release (eg. IcarusProtocol_v0.0.5.zip)
3. Unzip the file
4. Run the executable

## Functionality

Currently the project contains three UI elements: a small text box section in the center of the screen, a display of the value of testVar in the upper right side of the screen, and a button entitled Simulate underneath the text box. 

The user can enter python code into the textbox then press the Simulate button and have their code run by IronPython. Additionally, the user can interact with the variable testVar through their python code. The user can also call the function double() which will double the value of an input number and return the result. Any user code written in the text box is run once per second until the simulation reaches an end state. Simulation ends in success if testVar is forced below -20, and ends in failure if testVar is allowed to become higher than 20.

## Known Problems

There are currently no known problems.


## Contributing

1. Run the command `git pull` on the main branch to make sure you are up to date
2. Branch off the main branch: `git branch Sprint{the current sprint number}/Name-Of-Issue-You're-Working-On`
3. Switch to the new branch: `git checkout Sprint{the current sprint number}/Name-Of-Issue-You're-Working-On`
4. Commit your changes: `git commit -m 'Added feature because we needed this feature'`
5. Push to the branch: `git push origin Sprint{the current sprint number}/Name-Of-Issue-You're-Working-On`
6. Submit a pull request 

## Additional Documentation

  * [Sprint 1 Report](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/Sprint1/Produce-Sprint-Report/Documentation/Sprint1-Report.md)
  * [Sprint 2 Report](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/Sprint_Reports/Sprint2-Report.md)

## License

- [MIT License](https://github.com/WSUCptSCapstone-Fall2022Spring2023/psd-gamifiedapp/blob/sprint1/Update-README-To-Meet-Requirements/MITLicense.txt)

