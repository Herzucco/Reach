using UnityEngine;
using System.Collections;

public class FSMState<T> where T : MonoBehaviour
{
    public virtual void Begin(T o, FSM<T> fsm) { }
    public virtual void Execute(T o, FSM<T> fsm) { }
    public virtual void Transition(T o, FSM<T> fsm) { }
    public virtual void End(T o, FSM<T> fsm) { }
	public virtual void MysterySolved(T o, FSM<T> fsm, Mysteries id) { }
}
