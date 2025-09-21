using System;
using UnityEditor;
using YukimaruGames.Editor;

namespace YukimaruGames.CodeGenerator
{
    public sealed class CodeGenWindow : EditorWindow
    {
        private readonly IIconRepository _iconRepository;
        
        private const string kToolName = "CodeGen";

        [MenuItem("YukimaruGames/" + kToolName)]
        public static void ShowWindow()
        {
            GetWindow<CodeGenWindow>(kToolName);
        }

        private void OnGUI()
        {
            
        }
    }
}
