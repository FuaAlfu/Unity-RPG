using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.6.3
/// </summary>

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        // MonoBehaviour currentAction;
        IAction currentAction;

        //substitution principle
      //  public void StartAction(MonoBehaviour Action)
        public void StartAction(IAction Action)
        {
            if (currentAction == Action) return;
            if(currentAction != null)
            {
                print("cancelling.. " + currentAction);
                currentAction.Cancel();
            }
            currentAction = Action;
        }
    }
}