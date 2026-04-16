//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System.IO;
using UnityEditor;

internal static class BtEditorPaths
{
    internal static string GetAssetsFolderPath()
    {
        return "Assets/VadimBurym-DODBT/Local/Assets";
        //string editorFolder = GetEditorWindowFolderPath();
        //string parentUnityPath = Path.GetDirectoryName(editorFolder)?.Replace('\\', '/');
        //string parentPath = Path.GetDirectoryName(parentUnityPath)?.Replace('\\', '/');
        //if (string.IsNullOrEmpty(parentPath))
        //    return "Assets/Assets";
        //return $"{parentPath}/Assets";
    }

    internal static string GetEditorAssetsFolderPath()
    {
        return "Assets/VadimBurym-DODBT/Local/Assets";
        //string editorFolder = GetEditorWindowFolderPath();
        //string parentUnityPath = Path.GetDirectoryName(editorFolder)?.Replace('\\', '/');
        //if (string.IsNullOrEmpty(parentUnityPath))
        //    return "Assets/Editor/Assets";
        //return $"{parentUnityPath}/Assets";
    }

    internal static string GetEditorWindowFolderPath()
    {
        string[] guids = AssetDatabase.FindAssets("BtEditorWindow t:MonoScript");
        if (guids == null || guids.Length == 0)
            return "Assets";
        string scriptPath = AssetDatabase.GUIDToAssetPath(guids[0]);
        return Path.GetDirectoryName(scriptPath)?.Replace('\\', '/') ?? "Assets";
    }

    internal static void EnsureFolderExists(string folderPath)
    {
        if (AssetDatabase.IsValidFolder(folderPath))
            return;
        string parent = Path.GetDirectoryName(folderPath).Replace('\\', '/');
        string folderName = Path.GetFileName(folderPath);
        if (!AssetDatabase.IsValidFolder(parent))
            EnsureFolderExists(parent);
        AssetDatabase.CreateFolder(parent, folderName);
    }
}
