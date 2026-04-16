//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

internal enum BtNodeKind
{
    None = 0,
    Root = 1,
    Leaf = 2,
    Sequence = 3,
    Selector = 4,
    MemorySequence = 5,
    MemorySelector = 6,
    Parallel = 7
}
