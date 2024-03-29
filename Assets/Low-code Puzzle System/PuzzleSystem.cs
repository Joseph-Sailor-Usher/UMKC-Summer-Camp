using System.Collections.Generic;

/*
*   PuzzleSystem is a tool for creating puzzle games without writing much code.
*   It is based on the concept of a puzzle being a set of conditions which must be met.
*   The conditions are defined by the user in the Unity editor and can be anything from:
*       "Player's coins are greater than 10" to 
*       "Player's coins are greater than 10 and player is standing on a red tile".
*   States like player's coins are stored as monobehaviors on gameobjects.
*/
namespace PuzzleSystem {
    public interface ICondition {
        public bool GetCondition();
        public void SetCondition(bool value);
        public void SetConditionTrue();
        public void SetConditionFalse();
        public void ToggleCondition();
    }

    public interface ITrigger {
        public void Trigger();
    }
}
