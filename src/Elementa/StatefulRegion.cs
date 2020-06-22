using System;

namespace Elementa
{
    public class StatefulRegion<TState, TInitIn, TUpdateOut, TNotifyIn, TNotifyOut> : IDisposable
        where TState : class
    {
        Func<TState> create;
        Func<TState, TInitIn, TState> init;
        Func<TState, Tuple<TState, TUpdateOut>> update;
        Func<TState, TNotifyIn, Tuple<TState, TNotifyOut>> notify;
        TState state;

        public void Update(
            Func<TState> create, 
            Func<TState, TInitIn, TState> init, 
            Func<TState, Tuple<TState, TUpdateOut>> update,
            Func<TState, TNotifyIn, Tuple<TState, TNotifyOut>> notify)
        {
            this.create = create;
            this.init = init;
            this.update = update;
            this.notify = notify;

            if (this.state is null)
                this.state = create();
        }

        public void InvokeInit(TInitIn input)
        {
            var newState = init(state, input);
            state = newState;
        }

        public TUpdateOut InvokeUpdate()
        {
            var (newState, output) = update(state);
            state = newState;
            return output;
        }

        public TNotifyOut InvokeNotify(TNotifyIn input)
        {
            var (newState, output) = notify(state, input);
            state = newState;
            return output;
        }

        public void Reset()
        {
            if (state is IDisposable d)
                d.Dispose();
            state = create();
        }

        public void Dispose()
        {
            if (state is IDisposable d)
                d.Dispose();
        }
    }
}
