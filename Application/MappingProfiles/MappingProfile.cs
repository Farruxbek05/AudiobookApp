using Application.Model.Bookmark;
using Application.Model.Books;
using Application.Model.Category;
using Application.Model.Review;
using Application.Model.Setting;
using Application.Model.Subscription;
using Application.Model.User;
using AutoMapper;
using Domain.Entity;

namespace Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookCM, Book>();
        CreateMap<BookUM, Book>();
        CreateMap<Book, BookRM>();

        CreateMap<CategoryCM, Category>();
        CreateMap<CategoryUM, Category>();
        CreateMap<Category, CategoryRM>();

        CreateMap<BookmarkCM, Bookmark>();
        CreateMap<BookmarkUM, Bookmark>();
        CreateMap<Bookmark, BookmarkRM>();

        CreateMap<ReviewCM, Review>();
        CreateMap<ReviewUM, Review>();
        CreateMap<Review, ReviewRM>();

        CreateMap<SubscriptionCM, Subscription>();
        CreateMap<SubscriptionUM, Subscription>();
        CreateMap<Subscription, SubscriptionRM>();

        CreateMap<SettingCM, Setting>();
        CreateMap<SettingUM, Setting>();
        CreateMap<Setting, SettingRM>();

        CreateMap<CreateUserModel, User>().ReverseMap();
        CreateMap<LoginUserModel, User>().ReverseMap();
        CreateMap<User, ProfileDTO>().ReverseMap();
        CreateMap<CreateUserModel, TemporaryUser>().ReverseMap();
    }
}

