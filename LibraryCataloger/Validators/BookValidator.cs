using FluentValidation;
using LibraryCataloger.Data;

namespace LibraryCataloger.Validators
{
    internal class BookValidator : AbstractValidator<BookEntity>
    {
        public BookValidator() 
        { 
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.Description).MinimumLength(10).When(book => !string.IsNullOrEmpty(book.Description));
        }

    }
}
