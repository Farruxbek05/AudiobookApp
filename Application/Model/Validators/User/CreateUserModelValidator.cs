using Application.Model.User;
using FluentValidation;
using Infrastructure.Persistence;
using System.Text.RegularExpressions;

namespace Application.Model.Validators.User;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    public readonly AudiobookDbContext _dbContext;

    public CreateUserModelValidator(AudiobookDbContext dbContext)
    {
        _dbContext = dbContext;

        //RuleFor(u => u.Password)
        //    .MinimumLength(UserValidatorConfiguration.MinimumPasswordLength)
        //    .WithMessage($"Password should have minimum {UserValidatorConfiguration.MinimumPasswordLength} characters")
        //    .MaximumLength(UserValidatorConfiguration.MaximumPasswordLength)
        //    .WithMessage($"Password should have maximum {UserValidatorConfiguration.MaximumPasswordLength} characters");

        RuleFor(u => u.Email)
            //.EmailAddress()
            //.WithMessage("Email address is not valid")
            .Must(EmailIsUnique)
            .WithMessage("Email address is already in use");

        RuleFor(u => u.Lastname)
        .Must(l => !string.IsNullOrWhiteSpace(l));

        RuleFor(u => u.Firstname)
       .Must(l => !string.IsNullOrWhiteSpace(l));

        //RuleFor(u => u.PhoneNumber)
        //    .Must(PhoneNumberIsUnique)
        //    .WithMessage("Phone number address is already in use")
        //    .Must(IsValidPhoneNumber)
        //    .WithMessage("Phone number is not valid.");
    }


    private bool EmailIsUnique(string email)
    {
        bool emailExist = _dbContext.Users.Any(u => u.Email == email);
        return !emailExist;
    }

    private bool PhoneNumberIsUnique(string phoneNumber)
    {
        bool phoneNumberExist = _dbContext.Users.Any(u => u.PhoneNumber == phoneNumber);
        return !phoneNumberExist;
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        var phoneNumberRegex = new Regex(@"^998\d{9}$", RegexOptions.Compiled);

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return false;
        }

        return phoneNumberRegex.IsMatch(phoneNumber);
    }
}

