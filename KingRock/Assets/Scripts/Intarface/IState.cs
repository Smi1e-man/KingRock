using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface IState
    {
        void InitState(int speed, float distance,Shooter shooter, IState state);
        void UpdateState();
    }
}
