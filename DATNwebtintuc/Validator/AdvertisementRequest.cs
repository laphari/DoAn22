using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class AdvertisementRequestValidator : AbstractValidator<AdvertisementRequest>
    {
        public AdvertisementRequestValidator()
        {
            RuleFor(AdvertisementRequest => AdvertisementRequest.linkAdvertisement).NotNull().WithMessage("Please enter name Link Advertisment");
        }
    }
}