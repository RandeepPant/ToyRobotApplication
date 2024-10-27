# Robot Simulator

This repository contains a simple Robot Simulator implemented in C#. 
It allowsto  place a robot on a grid (5x5), some of the functions that can be applied to the robot includes, Place, Move, Left , Right and Report. 
Unit tests for the simulator are written using the xUnit testing framework to ensure that the robot behaves as expected.


## Introduction

The Robot Simulator allows users to interact with a robot on a defined grid. The functionality includes placing the robot, moving it in a specified direction, turning it, and reporting its current position. This repository also contains unit testing the core functionalities of the simulator.

## Assumptions

- The robot operates on a grid defined by a table of size `5 x 5`.
- The initial placement format is `X,Y,DIRECTION`, where:
  - `X` and `Y` are the robot's coordinates (-1,-1) intially to indicate it is outside the grid and has not been placed.
  - `DIRECTION` can be `"NORTH"`, `"EAST"`, `"SOUTH"`, or `"WEST"`.
- The robot can move in the direction it is facing but cannot move outside the table bounds.
- The robot can turn left or right, changing its direction accordingly.
- Key methods for the robot include:
  - `Place(string position, int tableSize)`
  - `Move(int steps)`
  - `TurnLeft()`
  - `TurnRight()`
  - `ReportPosition()`

## Requirements

- [.NET SDK] (version 6.0 or later)
- [xUnit]testing framework

## Installation

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/RandeepPant/ToyRobotApplication.git
   ```
## Running the Tests

To run the tests, execute the following command in the terminal:

```bash
dotnet test
```

This command compiles the tests and executes them, displaying the results in the console.

## Test Cases

The following test cases are included:

1. **Place_Valid_Position_Direction**: Verifies that the robot is correctly placed with the specified position and direction.
  
2. **Move_OneStep_to_Facing_Direction**: Confirms that the robot moves one step in its current direction when placed.

3. **Turn_Left_Rotate_AntiClockwise_90**: Checks that turning left changes the robot's direction accurately.

4. **Turn_Right_Rotate_Clockwise_90**: Checks that turning right changes the robot's direction accurately.


