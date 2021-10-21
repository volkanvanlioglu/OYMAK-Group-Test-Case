# Mars Rovers

Hello everybody. This is my console application which the Oymak Group sent me as a test case to implement. It's completely written in C# language. Now, let's get started to explain the content.

## What do Mars Rovers do?

In the scope of the story of our application, Mars Rovers are spacecrafts which NASA has sent to the Mars surface for research. And they are managed by miscellanous commands. Before talking about the commands, let's explain the classes briefly.

## Land

Land is the Mars surface where the spacecrafts which NASA sent. Land is an area which is defined by the user on initialization of the application. Minimum value for the width and length is 10 whereas the maximum is 100. So the user is warned if tries to enter a value apart from this range. The starting point is 0,0 but rovers can move to the negative coordinates as well as non-negative ones. After explaining the land, now let's move to the rover class.

## Rover

Rovers are the spacecrafts which we move by our commands through a console panel. But not finished yet. These rovers have some special functionalities. Now, let's explain them:

* Rotation (Left/Right): All the two rotations will be managed through different functions and the route is shown after each of the moves.
* Move (Any direction): After a command entered by us, rovers do some movements in the scope of the command.
* Waiting for command: Each rover has its own turn, that is, no more than one rovers can move in the same time.

Also, rovers have some distinguishing properties which we can track and separate them. For example, index is stand for separating the turn. So, here's a list of these properties:

* Location (int, int): This is the position of the rover on the Mars surface. It can vary after command.
* Route (int): This is where our rover is faced to. For example: if our rover is looking at north, then its route is called N (in property, it's called by number 0). The available routes are the following: 0: N, 90: E, 180: S, 270: W.
* Index (int): This is the number of the rover in the rovers list.
* Turn (bool): This is for determining the rover which is able to get commands to movement.
* Move Completion Control (bool): This is for determining if the turn is able to advanced to the next rover, or not.

After explaining what rovers do are and their functionalities, let's move the program class.

## Program

Program is the interface where we manage the land and the rovers by commands. When we start the application, program will ask us to enter the width and height. As we explained in the *land* section, it must be in a certain range (10 to 100). After doing it, now we will be asked for the rover count. In fact, it had been asked us for infinite number of rovers should be able to create but we have bound that count to a certain number which can vary according to the land's size.

After all these steps completed, it will initialize a land with the given measurements and the given rover count and the rovers will be waiting for us to commands. There are three available commands, they are **L**, **R** and **M**. Now, let's look at these commands briefly:

* L (Turn Left): Turns the rover left.
* R (Turn Right): Turns the rover right.
* M (Move): Move to the next grid on the current route. For example: a rover whose location is (0,0) with route **N** will move to (0,1) with a single **M**.

Also, please note that the commands **L** and **R** won't change the location, they have just affect on the rover's route. To sum up all the scenario, we can say:

* On the initialization, user enters the width and length for the land (if anything is out of bound, then the user is warned and step is repeated),
* And then, user enters the count of rovers which will be sent to the land (if the count is greater than the size or less than 1, which is the product of the width and height, then the step is repeated),
* After these steps are succeed, the rovers are initialized on a same random point with a same random route.
* Then the rovers will be waiting for command, turn by turn.
* After all the rovers have done their movements, the application will warn the user to press a key to leave.
