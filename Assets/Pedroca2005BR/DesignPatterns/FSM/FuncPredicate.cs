using UnityEngine;
using System;

namespace Pedroca2005BR.DesignPatterns.FSM
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> func;

        public FuncPredicate(Func<bool> func)
        {
            this.func = func;
        }
        public bool Evaluate()
        {
            return func.Invoke();
        }
    }
}
