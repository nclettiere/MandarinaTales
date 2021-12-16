using System;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Author: Nicolas Cabrera Lettiere
/// Github: https://github.com/nclettiere
/// </summary>

class Build
{
    private static string PathCombine(string path1, string path2)
    {
        if (Path.IsPathRooted(path2))
        {
            path2 = path2.TrimStart(Path.DirectorySeparatorChar);
            path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
        }

        return Path.Combine(path1, path2);
    }
	
    //private static string PathDeploy =>
    //    PathCombine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "/MandarinoBuilds/MandarinaTales.exe");

    static void build() {
		string PathDeploy = Application.dataPath;
        PathDeploy = PathDeploy.Replace("/Assets", "");
		
		PathDeploy = PathCombine(PathDeploy, "/MandarinoBuilds/MandarinaTales.exe");
		
        Debug.Log($"Build de MandarinaTales se generara en: {PathDeploy}");
        
        string[] scenes = {
            "Assets/Scenes/MenuPrincipal.unity",
            "Assets/Scenes/Nivel1.unity",
            "Assets/Scenes/GameOver.unity",
            "Assets/Scenes/LevelWon.unity"
        };  

        BuildPipeline.BuildPlayer(scenes, PathDeploy, BuildTarget.StandaloneWindows64, BuildOptions.None);      
    }
}