using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Application
{
    /// <summary>
    /// コード生成器
    /// </summary>
    public static class CodeGenerator
    {
        public static void Generate(IEnumerable<IConfig> configs)
        {
            foreach (var config in configs)
            {
                Generate(config);
            }
            
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static void Generate(IConfig config)
        {
            (string template, string generate) fullPath = (Path.GetFullPath(config.TemplateFilePath), Path.GetFullPath(config.GenerateFilePath));
            if (!File.Exists(fullPath.template))
            {
                Debug.LogError($"<color=red>Error:</color> Template file does not exist at '{fullPath.template}'. Please check the file path.");
                return;
            }

            if (File.Exists(fullPath.generate))
            {
                Debug.LogError($"<color=red>Error:</color> Generation aborted. The target file '{fullPath.generate}' already exists.");
                return;
            }

            try
            {
                var dirName = Path.GetDirectoryName(fullPath.generate);
                if (!string.IsNullOrEmpty(dirName) && !Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                var content = File.ReadAllText(fullPath.template);
                foreach (var rule in config.Rules)
                {
                    content = content.Replace(rule.Key, rule.Value);
                }

                File.WriteAllText(fullPath.generate, content);
                Debug.Log($"<color=green>Success:</color> Code generated successfully at '{fullPath.generate}'.");
            }
            catch (Exception e)
            {
                Debug.LogError($"<color=red>Error:</color> An unexpected error occurred during code generation: {e.Message}{Environment.NewLine}{e}");
            }
        }
    }
}
