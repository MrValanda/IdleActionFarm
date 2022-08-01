using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public abstract class State : MonoBehaviour
{
   [SerializeField] private List<Transition> _transitions;

   public void Enter()
   {
      if (enabled) return;

      enabled = true;
      foreach (var transition in _transitions)
      {
         transition.enabled = true;
      }
      OnEnter();
   }

   public void Exit()
   {
      if(enabled==false) return;

      enabled = false;
      foreach (var transition in _transitions)
      {
         transition.enabled = false;
      }
      
      OnExit();
   }

   public State GetNextState()
   {
      return _transitions.FirstOrDefault(x => x.NeedTransit)?.NextState;
   }

   protected abstract void OnEnter();
   
   protected abstract void OnExit();
}
