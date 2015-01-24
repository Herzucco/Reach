using UnityEngine;
using System.Collections;

public class FSM<T> where T : MonoBehaviour
{
    public FSMState<T> current;
    private T owner;

    public void Configure(T o, FSMState<T> initial)
    {
        owner = o;
        ChangeState(initial);
        owner.StartCoroutine(Executing());
    }

    private IEnumerator Executing()
    {
        while (true)
        {
            if (current != null)
            {
                current.Execute(owner, this);
                current.Transition(owner, this);
            }
            yield return null;
        }
    }

    public void Execute()
    {
        if (current != null)
        {
            current.Execute(owner, this);
        }
    }

    public void ChangeState(FSMState<T> newState)
    {
        if (newState != null)
        {
            if (current != null) current.End(owner, this);
            current = newState;
            current.Begin(owner, this);
        }
    }

}
