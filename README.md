# Battleships
Battleships game made in unity

You can set the size of the Field and the GameObject that should be a field inside a FieldSettingsModel.
-> to create a new FieldSettingsModel right click inside a folder, go to create and click on Field Settings Model

You can create new Ships by right clicking, go to create and click on Ship Settings Model
-> inside this file you can set the ID, Name, Size and GameObject of the Ship
-> the ship GameObject has to contain a ShipFactory

You can setup a Game mode by right clicking, go to create and click on Game Settings Model
-> inside this file you put a Field Settings Model file and the Ship Settings files that should be in your game mode

A game has to contain a GameObject with a GameController script attached, as well as a Ship Choosing Field and a Battlefield with their factory script attached.

All the scripts should be self explanatory.

To play the game, you can either open the project inside unity and click on the play button, or you create a build by clicking on File -> Build Settings -> Build and open the created EXE file.

Enjoy :)
