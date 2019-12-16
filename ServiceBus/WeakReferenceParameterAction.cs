using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.LernkartenApp001.Services.ServiceBus
{
    class WeakReferenceParameterAction<ParameterType> : WeakReferenceAction
    {
        private Action<ParameterType> action;
        public WeakReferenceParameterAction(object target, Action<ParameterType> action)
            : base(target, null)
        {
            this.action = action;
        }
        public override void Execute()
        {
            if (action != null && Target != null && Target.IsAlive)
                action(default(ParameterType));
        }
        public void Execute(ParameterType parameter)
        {
            if (action != null && Target != null && Target.IsAlive)
                this.action(parameter);
        }
        public Action<ParameterType> Action
        {
            get
            {
                return action;
            }
        }
    }
}
