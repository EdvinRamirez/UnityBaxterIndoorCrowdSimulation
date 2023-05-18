# UnityBaxterIndoorCrowdSimulation

Motivation: Designing a simulation for evacuations at Baxter Arena. Providing an in-depth look 
at the infrastructure of Baxter when in a state of emergency. Looking at human-behavior when 
in a panic to leave Baxter. This can allow people to understand and develop proper plans for an 
emergency at Baxter Arena. 

Description: The project will be a simulation to showcase evacuation during both normal 
scenarios and during emergency situations at Baxter Arena. The simulation will allow users to 
see potential issues in the current design of Baxter in terms of exits and pathways or 
alternatively what areas of Baxter already work well in these scenarios.

Implementation Strategy: Currently the project is set to build using the Unity game engine 
using C# as the main programming language. We also plan on using Blender for the majority of 
assets while building a copy of Baxter Arena. 


The Project is using Unity version 2020.3.40f1 
The main Project is located in BaxterSimulation Folder for Unity

For a build of the Project 
File -> Build Settings 
The scene to add are in order
- JasonMainMenu
- AllLevelsCombinedSene
- FirstFloorEdited
- EdvinSecondLevelTesting
- HideThirdLevel
- FourthFloor 
- Make sure to select PC, Mac & Linux Standalone Platform
- Press Build and Run and select Folder of your choosing 
After which, Unity build the project and should launch when done


*CODE MILESTONE 3 RELASE NOTES*
- Game Manager script implemented
- Updated AI Control Script to improve Agent functionality. 
- 1rst & 2nd Floor Agent testing started 

*CODE MILESTONE 4 RELASE NOTES*
- First and Second Floor navmesh agents added 
- Main menu added 
- Next steps are to finish 3rd and 4th floor walls, optimize nav mesh agents, finish main menu functionality. 


