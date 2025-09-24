using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YukimaruGames.CodeGenerator.Domain;
using YukimaruGames.CodeGenerator.Infrastructure;
using YukimaruGames.Editor.CodeGenerator.Domain;

namespace YukimaruGames.Editor.CodeGenerator.Infrastructure
{
    public sealed class GenerateItemRepository : IGenerateItemRepository
    {
        private readonly List<GenerateItem> _list = new();
        public IList Items => _list;
        public void AddItem(IConfig config)
        {
            _list.Add(new GenerateItem(config));
        }

        public void RemoveItem(IConfig config)
        {
            _list.RemoveAll(item =>
                item.TemplateFile == config.TemplateFilePath &&
                item.GenerateFile == config.GenerateFilePath);
        }
    }
}
