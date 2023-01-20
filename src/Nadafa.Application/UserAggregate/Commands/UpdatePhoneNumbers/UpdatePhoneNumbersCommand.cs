using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;
using System.Text.Json.Serialization;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdatePhoneNumbers
{
    public class UpdatePhoneNumbersCommand: IRequest<Unit>
    {
        [JsonIgnore][BindNever] public Guid UserId { get; set; }
        public List<PhoneEntityDto> Phones { get; set; } = new();
    }
}
