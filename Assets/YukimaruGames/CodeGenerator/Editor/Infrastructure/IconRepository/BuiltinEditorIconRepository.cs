using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace YukimaruGames.Editor
{
    internal sealed class BuiltinEditorIconRepository : IIconRepository, IDisposable
    {
        private Dictionary<string, Texture> _textures;

        internal BuiltinEditorIconRepository()
        {
            Reset();
        }

        ~BuiltinEditorIconRepository()
        {
            if (this is IDisposable self)
            {
                self.Dispose();
            }
        }
        
        Texture IIconRepository.GetIcon(string iconName)
        {
            return GetOrAdd(iconName);
        }

        private Texture GetOrAdd(string iconName)
        {
            if (_textures.TryGetValue(iconName, out var texture))
            {
                if (texture != null)
                {
                    return texture;
                }
                else
                {
                    _textures.Remove(iconName);
                }
            }

            var content = EditorGUIUtility.IconContent(iconName);

            {
                // fallback
                if (content == null)
                {
                    const string fallbackIcon = "d_BuildSettings.Broadcom";
                    content = EditorGUIUtility.IconContent(fallbackIcon);
                }

                // throw exception
                //if (content == null) throw new FileNotFoundException("Not found icon image.", iconName);
            }

            texture = content.image;
            _textures.Add(iconName, texture);
            return texture;
        }

        void IDisposable.Dispose()
        {
            Clear();
            GC.SuppressFinalize(this);
        }
        
        private void Clear()
        {
            foreach (var texture in _textures)
            {
                if (Application.isPlaying)
                {
                    UnityEngine.Object.Destroy(texture.Value);
                }
                else
                {
                    UnityEngine.Object.DestroyImmediate(texture.Value);
                }
            }

            _textures?.Clear();
            _textures = null;
        }

        private void Reset()
        {
            Clear();
            _textures = new Dictionary<string, Texture>();
        }
    }
}
