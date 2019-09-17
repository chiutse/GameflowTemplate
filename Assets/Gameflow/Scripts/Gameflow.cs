using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameflow
{
    public class Gameflow : MonoBehaviour
    {
        static Gameflow instance;
        [SerializeField]
        List<GameState> gamestates;
        GameState currentState;
        int currentStateIdx;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            if (gamestates.Count > 0)
            {
                currentStateIdx = 0;
                currentState = gamestates[currentStateIdx];
                currentState.OnStateStart();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState != null)
                currentState.OnStateUpdate();
        }

        public static void PrevState()
        {
            if (instance == null)
                return;
            instance.InnerPrevState();
        }

        void InnerPrevState()
        {
            if (gamestates.Count == 0 || currentState == null)
                return;

            currentState.OnStateEnd();
            currentStateIdx--;
            if (currentStateIdx < 0)
                currentStateIdx = 0;
            currentState = gamestates[currentStateIdx];
            currentState.OnStateStart();
        }

        public static void NextState()
        {
            if (instance == null)
                return;
            instance.InnerNextState();
        }

        void InnerNextState()
        {
            if (gamestates.Count == 0 || currentState == null)
                return;
            currentState.OnStateEnd();
            currentStateIdx++;
            if (currentStateIdx >= gamestates.Count)
                currentStateIdx = 0;
            currentState = gamestates[currentStateIdx];
            currentState.OnStateStart();
        }

        GameState InnerGetGameState()
        {
            return currentState;
        }

        public static GameState GetGameState()
        {
            return instance.InnerGetGameState();
        }
    }
}