using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Namespace
{
    public class SimpleAsyncFSM : MonoBehaviour
    {
        CancellationToken ct;

        delegate UniTask<StateFunc> StateFunc();
        StateFunc currentState;

        public void Start()
        {
            ct = this.GetCancellationTokenOnDestroy();
            _ = FSMLoop();
        }

        async UniTask FSMLoop()
        {
            currentState = Idle;

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    var newState = await currentState();
                    Debug.Log($"[{GetType().Name}] New State: {newState.Method.Name}");
                    currentState = newState;
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception e)
                {
                    Debug.Log($"[{GetType().Name}] Error({currentState.Method.Name}): {e.Message}");
                    Debug.LogException(e);
                    currentState = Idle;
                }
            }
        }

        async UniTask<StateFunc> Idle()
        {
            while (true)
            {
                ct.ThrowIfCancellationRequested();

                if (UnityEngine.Random.value > 0.5f)
                {
                    return Act;
                }

                await UniTask.Yield();
            }
        }

        async UniTask<StateFunc> Act()
        {
            while (true)
            {
                ct.ThrowIfCancellationRequested();

                if (UnityEngine.Random.value > 0.5f)
                {
                    return Idle;
                }

                await UniTask.Yield();
            }
        }
    }
}
