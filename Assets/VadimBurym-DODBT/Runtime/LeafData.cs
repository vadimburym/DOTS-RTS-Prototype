//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System;
using Unity.Collections;

namespace VadimBurym.DodBehaviourTree
{
    [Serializable]
    public struct LeafData
    {
        public byte LeafId;
        public int Int0;
        public float Float0;
        public byte Byte0;
        public FixedList32Bytes<byte> Bytes;
    }
}
