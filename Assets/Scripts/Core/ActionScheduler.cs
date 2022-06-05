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
        MonoBehaviour currentAction;

        //substitution principle
        public void StartAction(MonoBehaviour Action)
        {
            if (currentAction == Action) return;
            if(currentAction != null)
            {
                print("cancelling.. " + currentAction);
            }
            currentAction = Action;
        }
    }
}