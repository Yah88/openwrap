﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenWrap.Collections;

namespace OpenWrap.Commands.Cli.Locators
{
    public class DefaultForNounCommandLocator : ICommandLocator
    {
        readonly ICommandRepository _commandRepository;

        public DefaultForNounCommandLocator(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public ICommandDescriptor Execute(ref string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            var firstToken = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            if (string.IsNullOrEmpty(firstToken)) return null;

            var noun = firstToken.SelectHumps(_commandRepository.Nouns).OneOrDefault();
            return noun == null 
                ? null
                : _commandRepository.Where(x => x.Noun.EqualsNoCase(noun) && x.IsDefault).OneOrDefault();
        }
    }
}
