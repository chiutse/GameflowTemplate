using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameflow
{
    public class GameState : MonoBehaviour
    {
        public UnityEvent onStartEvent;
        public UnityEvent onUpdateEvent;
        public UnityEvent onEndEvent;
        public float roundtime;
        float timer;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void OnStateStart()
        {
            onStartEvent.Invoke();
            timer = Time.time + roundtime;
        }

        public virtual void OnStateUpdate()
        {
            onUpdateEvent.Invoke();
            if(roundtime > 0)
            {
                if(Time.time >= timer)
                {
                    Gameflow.NextState();
                }
            }
        }

        public virtual void OnStateEnd()
        {
            onEndEvent.Invoke();
        }
    }
}