﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<BookEntity> GetInLibraryBooks()
        {
            var inLibrary = _context.Books.Where(e => e.InLibrary).ToList();
            return inLibrary;
        }

        public void CreateBook(BookEntity book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public BookEntity? FindBookByID(int? bookId)
        {
           return _context.Books.Find(bookId);
        }
            
        public void UpdateBook(BookEntity book)
        {
			_context.Books.Update(book);
			_context.SaveChanges();
		}

        public void DeleteBook(BookEntity book)
        {
			_context.Books.Remove(book);
			_context.SaveChanges();
		}
    }
 }

