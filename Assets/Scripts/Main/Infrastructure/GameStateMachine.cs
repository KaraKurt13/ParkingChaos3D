using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameStateMachine : BaseStateMachine<IGameState>
    {
        public GameStateMachine()
        {
            AddState(typeof(GamePreparingState), new GamePreparingState());
            AddState(typeof(GameLoopState), new GameLoopState());
            AddState(typeof(GameEndingState), new GameEndingState());
        }
    }
}