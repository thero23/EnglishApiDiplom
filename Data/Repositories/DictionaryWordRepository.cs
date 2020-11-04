﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishApi.Data.Interfaces;
using EnglishApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishApi.Data.Repositories
{
    public class DictionaryWordRepository:IDictionaryWordRepository
    {
        private readonly EnglishContext _context;

        public DictionaryWordRepository(EnglishContext context)
        {
            _context = context;
        }
        public  IEnumerable<Word> GetWordsFromDictionary(Dictionary dictionary)
        {
            var wordsId = _context.DictionaryWords.Where(p => p.DictionaryId == dictionary.Id).ToList().Select(p => p.WordId).ToList();


            return _context.Words.Where(p => wordsId.Contains(p.Id)).ToList();
        }

        public async Task AddWordToDictionary(Word word, Dictionary dictionary)
        {
            
                var item = new DictionaryWord
                {
                    WordId = word.Id,
                    DictionaryId = dictionary.Id,
                    Word = word,
                    Dictionary = dictionary
                };

                await _context.DictionaryWords.AddAsync(item);
                await _context.SaveChangesAsync();

        }

        public async Task RemoveWordFromDictionary(Word word, Dictionary dictionary)
        {
            var item = _context.DictionaryWords.FirstOrDefault(p => p.Dictionary == dictionary && p.Word == word);
           
            _context.DictionaryWords.Remove(item);
            await _context.SaveChangesAsync();

        }

        public bool IsWordInDictionary(Word word, Dictionary dictionary)
        {
            return _context.DictionaryWords.Any(p => p.DictionaryId == dictionary.Id && p.WordId == word.Id);


           
        }
    }
}