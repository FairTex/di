﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public class CloudCreator : ICloudCreator
    {
        private IWordReader WordReader;
        private readonly Config config;
        private IWordHandler WordHandler;
        private IDrawer Drawer;
        private ITagMaker TagMaker;

        public CloudCreator(Config config, IWordReader reader, IWordHandler handler, IDrawer drawer, ITagMaker tagMaker)
        {
            this.config = config;
            WordHandler = handler;
            WordReader = reader;
            Drawer = drawer;
            TagMaker = tagMaker;
        }

        public void Create()
        {
            var result = WordReader.read(config.InputFileName);
            if (!result.IsSuccess)
            {
                throw new FileLoadException(result.Error);
            }

            var handledWords = WordHandler.Handle(result.Value);
            var rectangles = TagMaker.Make(handledWords);

            Drawer.Draw(rectangles);
        }
    }
}
