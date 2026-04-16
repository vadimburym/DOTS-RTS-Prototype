//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System.Runtime.CompilerServices;

namespace VadimBurym.DodBehaviourTree.Tests
{
    internal static class LeafTables_TestContext
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NodeStatus TickLeaf(byte leafId, ref RunnerState_TestContext state)
        {
            switch (leafId)
            {
                case RecordingLeaf.LeafId:
                    return RecordingLeaf.OnTick(ref state);
                default:
                    return NodeStatus.Failure;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnterLeaf(byte leafId, ref RunnerState_TestContext state)
        {
            switch (leafId)
            {
                case RecordingLeaf.LeafId:
                    RecordingLeaf.OnEnter(ref state);
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExitLeaf(byte leafId, ref RunnerState_TestContext state)
        {
            switch (leafId)
            {
                case RecordingLeaf.LeafId:
                    RecordingLeaf.OnExit(ref state);
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbortLeaf(byte leafId, ref RunnerState_TestContext state)
        {
            switch (leafId)
            {
                case RecordingLeaf.LeafId:
                    RecordingLeaf.OnAbort(ref state);
                    break;
            }
        }
    }
}
