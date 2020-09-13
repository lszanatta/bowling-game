# Bowling game

## Simple ten-pin bowling game with [traditional](https://en.wikipedia.org/wiki/Ten-pin_bowling#Scoring) score system

* Game is played in 10 frames (rounds)
* Frames 1 through 9 have two throws (attempts), with the points for each frame calculated as:
  * Scoring a strike (knocking over 10 pins in the first throw) grants 10 plus the number of pins downed in next 2 throws
  * Scoring a spare (knocking over 10 pins with 2 throws) grants 10 plus the number of pins downed in next throw
* 10th frame has a maximum of 3 throws, with no bonus points, but the 3rd attempt is only possible if either a strike or a spare was made in the first two throws
* The final score is the sum of each frame
