﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishApi.Models;

namespace EnglishApi.Data.Interfaces
{
    public interface IDictionaryWordRepository
    {
        IEnumerable<Word> GetWordsFromDictionary(Dictionary dictionary);
        Task AddWordToDictionary(Word word, Dictionary dictionary);
        Task RemoveWordFromDictionary(Word word, Dictionary dictionary);
        bool IsWordInDictionary(Word word, Dictionary dictionary);
    }
}
