using BlogSiteNancy.Views.Blog.ViewModels;
using FluentValidation;
using Utilities;

namespace BlogSiteNancy.Modules.Blog.New
{
    public class NewBlogValidator : AbstractValidator<NewBlogModel>
    {
        public NewBlogValidator()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage(Constants.Messages.Blog.New.EmptyTitleError);
            RuleFor(model => model.Content).NotEmpty().WithMessage(Constants.Messages.Blog.New.EmptyContentError);
            RuleFor(model => model.CategoryId).GreaterThan(0).WithMessage(Constants.Messages.Blog.New.SelectCategoryError);
        }
    }
}