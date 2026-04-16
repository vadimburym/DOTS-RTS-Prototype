//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System;

namespace VadimBurym.DodBehaviourTree.Tests
{
    [Serializable]
    internal static class RecordingLeaf
    {
        public const byte LeafId = 0;

        public static NodeStatus OnTick(ref RunnerState_TestContext state)
        {
            state.LeafState.TickCount++;
            var cursor = state.LeafState.StatusCursor;

            var statusIndex = cursor < state.LeafData.Bytes.Length
                ? cursor
                : state.LeafData.Bytes.Length - 1;

            var status = (NodeStatus)state.LeafData.Bytes[statusIndex];
            state.LeafState.StatusCursor = (byte)(cursor + 1);

            state.Context.Events.Add("tick:" + state.Context.GetLeafName(state.LeafState.BufferIndex) + ":" + status);
            state.LeafState.LastStatus = status;
            return status;
        }

        public static void OnEnter(ref RunnerState_TestContext state)
        {
            state.LeafState.EnterCount++;
            state.Context.Events.Add("enter:" + state.Context.GetLeafName(state.LeafState.BufferIndex));
        }

        public static void OnExit(ref RunnerState_TestContext state)
        {
            state.LeafState.ExitCount++;
            state.Context.Events.Add("exit:" + state.Context.GetLeafName(state.LeafState.BufferIndex));
        }

        public static void OnAbort(ref RunnerState_TestContext state)
        {
            state.LeafState.AbortCount++;
            state.Context.Events.Add("abort:" + state.Context.GetLeafName(state.LeafState.BufferIndex));
        }
    }
}
