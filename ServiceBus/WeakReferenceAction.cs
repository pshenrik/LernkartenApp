using System;
using System.Collections.Generic;
using System.Text;

namespace De.HsFlensburg.LernkartenApp001.Services.ServiceBus
{
    class WeakReferenceAction
    {
        private WeakReference target;
        private Action action;

        public WeakReferenceAction(object target, Action action)
        {
            this.target = new WeakReference(target);
            this.action = action;
        }
        public WeakReference Target
        {
            get
            {
                return target;
            }
        }
        public virtual void Execute()
        {
            if (action != null && target != null && target.IsAlive)
                action.Invoke();
        }

        public void Unload()
        {
            if (this.action != null)
            {
                target = null;
                action = null;
            }
        }
    }
}
