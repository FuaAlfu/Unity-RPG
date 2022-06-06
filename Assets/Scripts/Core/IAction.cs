using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.6.5
/// </summary>

namespace RPG.Core
{
    public interface IAction
    {
        //any interface is a contract.. so anything that implements this interface, has to have a certain method

        void Cancel();

    }
}
