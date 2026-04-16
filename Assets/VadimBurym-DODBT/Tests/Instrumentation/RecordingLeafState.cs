//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System;
using Unity.Entities;

namespace VadimBurym.DodBehaviourTree.Tests
{
    [Serializable]
    [InternalBufferCapacity(0)]
    public struct RecordingLeafState : IBufferElementData
    {
        public byte IsEntered;
        public ushort BufferIndex;
        public byte StatusCursor;
        public byte EnterCount;
        public byte ExitCount;
        public byte TickCount;
        public byte AbortCount;
        public NodeStatus LastStatus;
    }
}
