using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameStateMachine : BaseStateMachine<IGameState>
    {
        public GameStateMachine(GameEngine engine)
        {
            AddState(typeof(GameInitializationState), new GameInitializationState(this, engine.LevelGenerator));
            AddState(typeof(GamePreparingState), new GamePreparingState(this, engine));
            AddState(typeof(GameLoopState), new GameLoopState(this, engine));
            AddState(typeof(GameEndingState), new GameEndingState());
        }
    }
}