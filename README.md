# COP-3003-FinalProject
This is a game I am making in Unity using C#. Source code is found in Proj/Assets/Scripts.

After becoming a little more comfortable with Unity and C#, I started over with a new project.
This project is a third-person adventure game where the player can move around more freely and cast spells.

**Project requirements:**
  Comments at bottom of Enemy1: The comments explain the inheritence of the enemy classes and dynamic dispatch.
  Bottom of PlayerMovement: The comments explain the use of generics.
  Top of Stats: The comments explain encapsulation.

**Movement Controls:**

The player can move with either WASD or the arrow keys. Press space to jump. While in mid-air, pressing space again will allow the player to use a paraglider. This makes the player move faster while reducing their fall speed. Use the mouse to move the camera.

**Stats:**

Because the player has the script PlayerMovement, which is a subclass to CharacterStats, the player inherits the members from CharacterStats.
The player has HP, MP, Attack, and Defense stats.
Casting spells consumes MP. MP can be restored by colliding with the glowing circle. This would also restore HP.
Attack can be increased by collecting red capsules.
Gold can be gained by collecting gold capsules.

**Spells:**

The player can cast 2 spells currently.

Press "F" to shoot a fire ball forward. This costs 10 MP. This deals damage equal to the player's attack stat minus the enemy's defense stat.

Press "I" to surround the player in ice. This costs 20 MP. This is a close-range spell that deals damage equal to half of the player's attack stat, and ignores the enemy's defense. This is useful against the larger enemies with high defense.

Casting a spell will toggle the able variable in GeneralFunctions to false for a short duration. This is to create a bit of endlag to the player's actions.

**Enemies:**

There are 2 types of enemies for the player to attack. They can be identified as red boxes.
The smaller enemies have less health and defense, and upon death have a 25% chance to drop a red capsule.
The larger enemies have more health and defense, and upon death have a 100% chance to drop a red capsule.
The enemies use the classes Enemy1 and Enemy2, which are both subclasses to the same superclass EnemyParent, which is a subclass to CharacterStats.
This allows both Enemy1 and Enemy2 to inherit all members from EnemyParent and from CharacterStats, while adding and overriding other members.

![unity_game_screenshot](https://user-images.githubusercontent.com/42978071/143307384-f6c11d69-c05b-48ad-bc3e-a70a9ab56fa1.PNG)
